using System;
using UnityEngine;
using UnityEngine.UI;

public class lombardScript : MonoBehaviour
{
    [Header("Всего тон, текст")]
    public Text ton1, ton2, ton3, ton4;

    [Header("Всего тон, число")]
    public float floatton1, floatton2, floatton3, floatton4;

    private float basePrice1, basePrice2, basePrice3, basePrice4;
    private float BasePrice1 = 14;
    private float BasePrice2 = 21;
    private float BasePrice3 = 45;
    private float BasePrice4 = 110;

    [Header("Сколько продаём, слайдер")]
    public Slider SliderSell1, SliderSell2, SliderSell3, SliderSell4;
    public Text tonsell1, tonsell2, tonsell3, tonsell4;

    [Header("Процент рынка")]
    public Text percent1, percent2, percent3, percent4;

    [Header("Итог монет")]
    public Text allcoins1, allcoins2, allcoins3, allcoins4;

    [Header("Звуки")]
    public AudioSource sellSound;
    public AudioSource errorSound;

    private int Trables;
    private int pricePercent1, pricePercent2, pricePercent3, pricePercent4;

    // Значения слайдера, делённые на 10
    private float SliderValue1, SliderValue2, SliderValue3, SliderValue4;

    void Start()
    {
        UpdatePrice();
        UpdatePercents();
    }

    void Update()
    {
        // Проверяем необходимость обновить цены
        if (PlayerPrefs.GetInt("MetalsIsActivateTask", 0) == 1 || PlayerPrefs.GetInt("CreditsTrables", 0) != Trables)
            UpdatePrice();

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
        SliderSell1.maxValue = floatton1 * 10;
        SliderSell2.maxValue = floatton2 * 10;
        SliderSell3.maxValue = floatton3 * 10;
        SliderSell4.maxValue = floatton4 * 10;

        // Делим значение слайдера на 10 для правильного отображения
        SliderValue1 = SliderSell1.value / 10f;
        SliderValue2 = SliderSell2.value / 10f;
        SliderValue3 = SliderSell3.value / 10f;
        SliderValue4 = SliderSell4.value / 10f;

        // Сколько тонн выбрано
        tonsell1.text = SliderValue1.ToString("F1") + " тонн";
        tonsell2.text = SliderValue2.ToString("F1") + " тонн";
        tonsell3.text = SliderValue3.ToString("F1") + " тонн";
        tonsell4.text = SliderValue4.ToString("F1") + " тонн";

        // Итоговые монеты
        allcoins1.text = CalcCoins(SliderValue1, basePrice1, pricePercent1).ToString() + " монет";
        allcoins2.text = CalcCoins(SliderValue2, basePrice2, pricePercent2).ToString() + " монет";
        allcoins3.text = CalcCoins(SliderValue3, basePrice3, pricePercent3).ToString() + " монет";
        allcoins4.text = CalcCoins(SliderValue4, basePrice4, pricePercent4).ToString() + " монет";

        // Цвет процентов
        SetPercentText(percent1, pricePercent1);
        SetPercentText(percent2, pricePercent2);
        SetPercentText(percent3, pricePercent3);
        SetPercentText(percent4, pricePercent4);
    }

    public void UpdatePrice()
    {
        basePrice1 = BasePrice1 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);
        basePrice2 = BasePrice2 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);
        basePrice3 = BasePrice3 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);
        basePrice4 = BasePrice4 * PlayerPrefs.GetFloat("DiscountOnLombart", 1f);
        Trables = 0;
        PlayerPrefs.SetInt("MetalsIsActivateTask", 0);

        int creditsTrables = PlayerPrefs.GetInt("CreditsTrables", 0);
        float discount = PlayerPrefs.GetFloat("DiscountOnLombart", 1f);

        if (creditsTrables == 1) { ApplyDiscount(-0.08f, discount, ref Trables, 1); }
        if (creditsTrables == 2) { ApplyDiscount(-0.15f, discount, ref Trables, 2); }
        if (creditsTrables == 3) { ApplyDiscount(-0.25f, discount, ref Trables, 3); }
    }

    void ApplyDiscount(float minus, float discount, ref int trables, int value)
    {
        basePrice1 = BasePrice1 * (minus + discount);
        basePrice2 = BasePrice2 * (minus + discount);
        basePrice3 = BasePrice3 * (minus + discount);
        basePrice4 = BasePrice4 * (minus + discount);
        trables = value;
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
        return Mathf.Clamp(oldValue + change, 50, 250);
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
    public void voidsell1() { TrySell(ref floatton1, SliderValue1, "bronzeMass", basePrice1, pricePercent1); }
    public void voidsell2() { TrySell(ref floatton2, SliderValue2, "silverMass", basePrice2, pricePercent2); }
    public void voidsell3() { TrySell(ref floatton3, SliderValue3, "goldMass", basePrice3, pricePercent3); }
    public void voidsell4() { TrySell(ref floatton4, SliderValue4, "diamondMass", basePrice4, pricePercent4); }

    void TrySell(ref float tonsOwned, float sliderValue, string key, float basePrice, int percent)
    {
        float tonsToSell = (float)Math.Round(sliderValue, 1);
        tonsOwned = (float)Math.Round(tonsOwned, 1);

        if (tonsOwned >= tonsToSell && tonsToSell > 0f)
        {
            tonsOwned -= tonsToSell;
            if (tonsOwned < 0.05f) tonsOwned = 0f;

            PlayerPrefs.SetFloat(key, (float)Math.Round(tonsOwned, 1));

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
}
