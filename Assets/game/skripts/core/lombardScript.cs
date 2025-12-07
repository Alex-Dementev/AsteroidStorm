using System;
using UnityEngine;
using UnityEngine.UI;

public class lombardScript : MonoBehaviour
{
    [Header("Всего тон (текст)")]
    public Text ton1, ton2, ton3, ton4;

    [Header("Всего тон (число)")]
    private float floatton1, floatton2, floatton3, floatton4;

    [Header("Базовые цены за тонну")]
    private float basePrice1 = 7;
    private float basePrice2 = 12;
    private float basePrice3 = 25;
    private float basePrice4 = 120;

    [Header("Сколько продаём (из слайдера)")]
    public Slider SliderSell1, SliderSell2, SliderSell3, SliderSell4;
    public Text tonsell1, tonsell2, tonsell3, tonsell4;

    [Header("Процент рынка")]
    public Text percent1, percent2, percent3, percent4;

    [Header("Итог монет")]
    public Text allcoins1, allcoins2, allcoins3, allcoins4;

    [Header("Звуки")]
    public AudioSource sellSound;
    public AudioSource errorSound;

    private int pricePercent1, pricePercent2, pricePercent3, pricePercent4;

    void Start()
    {
        basePrice1 = basePrice1 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);
        basePrice2 = basePrice2 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);
        basePrice3 = basePrice3 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);
        basePrice4 = basePrice4 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);

        UpdatePercents();
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("MetalsIsActivateTask", 0) == 1)
        {
            basePrice1 = basePrice1 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);
            basePrice2 = basePrice2 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);
            basePrice3 = basePrice3 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);
            basePrice4 = basePrice4 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);
            PlayerPrefs.SetInt("MetalsIsActivateTask", 0);
        }

        // Загружаем количество тонн
        floatton1 = PlayerPrefs.GetFloat("bronzeMass", 0);
        floatton2 = PlayerPrefs.GetFloat("silverMass", 0);
        floatton3 = PlayerPrefs.GetFloat("goldMass", 0);
        floatton4 = PlayerPrefs.GetFloat("diamondMass", 0);

        ton1.text = floatton1.ToString("F1") + " т";
        ton2.text = floatton2.ToString("F1") + " т";
        ton3.text = floatton3.ToString("F1") + " т";
        ton4.text = floatton4.ToString("F1") + " т";

        // Ограничиваем слайдеры
        SliderSell1.maxValue = floatton1;
        SliderSell2.maxValue = floatton2;
        SliderSell3.maxValue = floatton3;
        SliderSell4.maxValue = floatton4;

        // Сколько тонн выбрано (с десятыми)
        tonsell1.text = SliderSell1.value.ToString("F1") + " тонн";
        tonsell2.text = SliderSell2.value.ToString("F1") + " тонн";
        tonsell3.text = SliderSell3.value.ToString("F1") + " тонн";
        tonsell4.text = SliderSell4.value.ToString("F1") + " тонн";

        // Итоговые монеты
        allcoins1.text = CalcCoins(SliderSell1.value, basePrice1, pricePercent1).ToString() + " монет";
        allcoins2.text = CalcCoins(SliderSell2.value, basePrice2, pricePercent2).ToString() + " монет";
        allcoins3.text = CalcCoins(SliderSell3.value, basePrice3, pricePercent3).ToString() + " монет";
        allcoins4.text = CalcCoins(SliderSell4.value, basePrice4, pricePercent4).ToString() + " монет";

        // Цвет процентов
        SetPercentText(percent1, pricePercent1);
        SetPercentText(percent2, pricePercent2);
        SetPercentText(percent3, pricePercent3);
        SetPercentText(percent4, pricePercent4);
    }

    int CalcCoins(float tons, float basePrice, int percent)
    {
        float realPrice = basePrice * percent / 100f;
        return Mathf.RoundToInt(tons * realPrice);
    }

    void SetPercentText(Text txt, int percent)
    {
        txt.text = percent + "%";

        Color green, red, standard;
        ColorUtility.TryParseHtmlString("#00DB7C", out green);
        ColorUtility.TryParseHtmlString("#DB004C", out red);
        ColorUtility.TryParseHtmlString("#FA32FF", out standard);

        if (percent <= 90) txt.color = red;
        else if (percent >= 110) txt.color = green;
        else txt.color = standard;
    }

    void UpdatePercents()
    {
        // Загружаем или создаём
        pricePercent1 = PlayerPrefs.GetInt("percent1", 100);
        pricePercent2 = PlayerPrefs.GetInt("percent2", 100);
        pricePercent3 = PlayerPrefs.GetInt("percent3", 100);
        pricePercent4 = PlayerPrefs.GetInt("percent4", 100);

        string lastTime = PlayerPrefs.GetString("lastUpdateLombard", "");
        DateTime lastUpdate;
        if (DateTime.TryParse(lastTime, out lastUpdate))
        {
            TimeSpan diff = DateTime.Now - lastUpdate;
            if (diff.TotalHours >= 1)
            {
                int hours = (int)diff.TotalHours;
                for (int i = 0; i < hours; i++)
                {
                    pricePercent1 = ChangePercent(pricePercent1);
                    pricePercent2 = ChangePercent(pricePercent2);
                    pricePercent3 = ChangePercent(pricePercent3);
                    pricePercent4 = ChangePercent(pricePercent4);
                }
                PlayerPrefs.SetString("lastUpdateLombard", DateTime.Now.ToString());
            }
        }
        else
        {
            PlayerPrefs.SetString("lastUpdateLombard", DateTime.Now.ToString());
        }

        SavePercents();
    }

    int ChangePercent(int oldValue)
    {
        int change = UnityEngine.Random.Range(-20, 21);
        int newValue = Mathf.Clamp(oldValue + change, 50, 250);
        return newValue;
    }

    void SavePercents()
    {
        PlayerPrefs.SetInt("percent1", pricePercent1);
        PlayerPrefs.SetInt("percent2", pricePercent2);
        PlayerPrefs.SetInt("percent3", pricePercent3);
        PlayerPrefs.SetInt("percent4", pricePercent4);
        PlayerPrefs.Save();
    }

    // ===== Кнопки продажи =====
    public void voidsell1() { TrySell(ref floatton1, SliderSell1, basePrice1, pricePercent1); }
    public void voidsell2() { TrySell(ref floatton2, SliderSell2, basePrice2, pricePercent2); }
    public void voidsell3() { TrySell(ref floatton3, SliderSell3, basePrice3, pricePercent3); }
    public void voidsell4() { TrySell(ref floatton4, SliderSell4, basePrice4, pricePercent4); }

    void TrySell(ref float tonsOwned, Slider slider, float basePrice, int percent)
    {
        // Округляем слайдер до десятых
        float tonsToSell = (float)Math.Round(slider.value, 1);

        // Округляем количество тонн владельца до десятых
        tonsOwned = (float)Math.Round(tonsOwned, 1);

        if (tonsOwned >= tonsToSell && tonsToSell > 0f)
        {
            tonsOwned -= tonsToSell;

            // Если после продажи остаётся меньше 0.05, обнуляем
            if (tonsOwned < 0.05f) tonsOwned = 0f;

            // Сохраняем с PlayerPrefs с округлением
            PlayerPrefs.SetFloat(GetMassKey(slider), (float)Math.Round(tonsOwned, 1));

            int coins = PlayerPrefs.GetInt("coins", 0);
            coins += CalcCoins(tonsToSell, basePrice, percent);
            PlayerPrefs.SetInt("coins", coins);

            PlayerPrefs.Save();

            if (sellSound) sellSound.Play();
        }
        else
        {
            if (errorSound) errorSound.Play();
        }
    }

    // ===== Функция для ключей PlayerPrefs =====
    string GetMassKey(Slider slider)
    {
        if (slider == SliderSell1) return "bronzeMass";
        if (slider == SliderSell2) return "silverMass";
        if (slider == SliderSell3) return "goldMass";
        return "diamondMass";
    }
}
