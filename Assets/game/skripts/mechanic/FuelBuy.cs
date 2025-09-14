using System;
using UnityEngine;
using UnityEngine.UI;

public class FuelBuy : MonoBehaviour
{
    public AudioSource buySound;
    public AudioSource errorSound;

    public Text priceText;
    public Text percentText;
    public Text cansText;

    private int currentPrice;
    private int basePrice = 10;

    void Start()
    {
        UpdatePrice();
        UpdateUI();
    }

    void UpdatePrice()
    {
        // Загружаем сохранённую цену
        currentPrice = PlayerPrefs.GetInt("fuelPrice", basePrice);

        // Проверяем последнее обновление
        string lastTime = PlayerPrefs.GetString("lastFuelUpdate", "");
        DateTime lastUpdate;

        if (DateTime.TryParse(lastTime, out lastUpdate))
        {
            TimeSpan diff = DateTime.Now - lastUpdate;

            if (diff.TotalHours >= 1)
            {
                int hours = (int)diff.TotalHours;

                for (int i = 0; i < hours; i++)
                {
                    // случайный процент 15–35
                    int percent = UnityEngine.Random.Range(15, 36);

                    // вверх или вниз
                    bool increase = UnityEngine.Random.value > 0.5f;

                    float factor = 1f + (increase ? percent : -percent) / 100f;

                    currentPrice = Mathf.RoundToInt(currentPrice * factor);

                    // ограничиваем от 3 до 30
                    currentPrice = Mathf.Clamp(currentPrice, 3, 30);
                }

                PlayerPrefs.SetString("lastFuelUpdate", DateTime.Now.ToString());
            }
        }
        else
        {
            // первый запуск
            currentPrice = basePrice;
            PlayerPrefs.SetString("lastFuelUpdate", DateTime.Now.ToString());
        }

        PlayerPrefs.SetInt("fuelPrice", currentPrice);
        PlayerPrefs.Save();
    }

    void UpdateUI()
    {
        // Цена
        priceText.text = currentPrice.ToString();

        // Проценты относительно 10
        float percentChange = ((float)currentPrice - basePrice) / basePrice * 100f;
        string sign = percentChange >= 0 ? "+" : "";
        percentText.text = sign + Mathf.RoundToInt(percentChange) + "%";

        // Цвет процентов
        Color baseColor;
        ColorUtility.TryParseHtmlString("#FD70FA", out baseColor);
        if (percentChange > 0)
            percentText.color = Color.Lerp(baseColor, Color.red, 0.5f);
        else if (percentChange < 0)
            percentText.color = Color.Lerp(baseColor, Color.green, 0.5f);
        else
            percentText.color = baseColor;

        // Канистры (только число)
        int cans = PlayerPrefs.GetInt("fuel", 0);
        cansText.text = cans.ToString();
    }

    public void Click()
    {
        int coins = PlayerPrefs.GetInt("coins", 0);

        if (coins >= currentPrice)
        {
            coins -= currentPrice;
            PlayerPrefs.SetInt("coins", coins);

            int cans = PlayerPrefs.GetInt("fuel", 0);
            cans++;
            PlayerPrefs.SetInt("fuel", cans);

            PlayerPrefs.Save();

            if (buySound) buySound.Play();
        }
        else
        {
            if (errorSound) errorSound.Play();
        }

        UpdateUI();
    }
}
