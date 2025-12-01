using System;
using UnityEngine;
using UnityEngine.UI;

public class FuelBuy : MonoBehaviour
{
    public AudioSource buySound;
    public AudioSource errorSound;

    public Text priceText;
    public Text price10Text;   // 💥 ЦЕНА ЗА 10
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
        currentPrice = PlayerPrefs.GetInt("fuelPrice", basePrice);

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
                    int percent = UnityEngine.Random.Range(15, 36);
                    bool increase = UnityEngine.Random.value > 0.5f;
                    float factor = 1f + (increase ? percent : -percent) / 100f;

                    currentPrice = Mathf.RoundToInt(currentPrice * factor);
                    currentPrice = Mathf.Clamp(currentPrice, 3, 30);
                }

                PlayerPrefs.SetString("lastFuelUpdate", DateTime.Now.ToString());
            }
        }
        else
        {
            currentPrice = basePrice;
            PlayerPrefs.SetString("lastFuelUpdate", DateTime.Now.ToString());
        }

        PlayerPrefs.SetInt("fuelPrice", currentPrice);
        PlayerPrefs.Save();
    }

    void UpdateUI()
    {
        // Цена за 1
        priceText.text = currentPrice.ToString();

        // Цена за 10 💥
        if (price10Text != null)
            price10Text.text = (currentPrice * 10).ToString();

        // Проценты
        float percentChange = ((float)currentPrice - basePrice) / basePrice * 100f;
        string sign = percentChange >= 0 ? "+" : "";
        percentText.text = sign + Mathf.RoundToInt(percentChange) + "%";

        Color baseColor;
        ColorUtility.TryParseHtmlString("#FD70FA", out baseColor);

        if (percentChange > 0)
            percentText.color = Color.Lerp(baseColor, Color.red, 0.5f);
        else if (percentChange < 0)
            percentText.color = Color.Lerp(baseColor, Color.green, 0.5f);
        else
            percentText.color = baseColor;

        // Канистры
        int cans = PlayerPrefs.GetInt("fuel", 0);
        cansText.text = cans.ToString();
    }

    // ----------- ПОКУПКА 1 -----------
    public void Click()
    {
        int coins = PlayerPrefs.GetInt("coins", 0);

        if (coins >= currentPrice)
        {
            coins -= currentPrice;
            PlayerPrefs.SetInt("coins", coins);

            int cans = PlayerPrefs.GetInt("fuel", 0) + 1;
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

    // ----------- ПОКУПКА 10 💥 -----------
    public void Click10()
    {
        int coins = PlayerPrefs.GetInt("coins", 0);
        int cost10 = currentPrice * 10;

        if (coins >= cost10)
        {
            coins -= cost10;
            PlayerPrefs.SetInt("coins", coins);

            int cans = PlayerPrefs.GetInt("fuel", 0) + 10;
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
