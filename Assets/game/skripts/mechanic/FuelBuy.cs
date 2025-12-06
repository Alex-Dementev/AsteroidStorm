using System;
using UnityEngine;
using UnityEngine.UI;

public class FuelBuy : MonoBehaviour
{
    public AudioSource buySound;
    public AudioSource errorSound;

    public Text priceText;
    public Text price10Text;
    public Text percentText;
    public Text cansText;

    private int basePrice = 10;
    private int currentPrice;
    private int plusFuelBuy;

    private float dynamicDiscount = 1f; // Динамическая скидка (меняется каждый час)

    void Start()
    {
        UpdateDynamicDiscount();
        UpdatePrice();
        UpdateUI();
    }

    void UpdateDynamicDiscount()
    {
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
                    dynamicDiscount = 1f + (increase ? percent : -percent) / 100f;
                    
                    // Ограничение от 30% до 200%
                    dynamicDiscount = Mathf.Clamp(dynamicDiscount, 0.3f, 2f);
                }
                PlayerPrefs.SetString("lastFuelUpdate", DateTime.Now.ToString());
            }
        }
        else
        {
            dynamicDiscount = 1f;
            PlayerPrefs.SetString("lastFuelUpdate", DateTime.Now.ToString());
        }
        PlayerPrefs.SetFloat("dynamicDiscount", dynamicDiscount);
    }

    void UpdatePrice()
    {
        float manualDiscount = PlayerPrefs.GetInt("DiscountOnFuel", 10) / 10f; // Ручная скидка
        float price = basePrice * manualDiscount * dynamicDiscount;
        currentPrice = Mathf.RoundToInt(price);
    }

    void UpdateUI()
    {
        priceText.text = currentPrice.ToString();
        if (price10Text != null) price10Text.text = (currentPrice * 10).ToString();

        // Динамическая скидка текстом
        float percentTextValue = Mathf.Round((1f - dynamicDiscount) * 100f);
        if (percentTextValue == 0) percentText.text = "0%";
        else percentText.text = (percentTextValue < 0 ? "+" : "-") + Mathf.Abs((int)percentTextValue) + "%";

        ColorUtility.TryParseHtmlString("#FD70FA", out Color baseColor);
        percentText.color = dynamicDiscount < 1f ? Color.green : (dynamicDiscount > 1f ? Color.red : baseColor);

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

            int cans = PlayerPrefs.GetInt("fuel", 0) + 1;
            PlayerPrefs.SetInt("fuel", cans);

            plusFuelBuy = PlayerPrefs.GetInt("PermanentTaskFuel", 0) + 1;
            PlayerPrefs.SetInt("PermanentTaskFuel", plusFuelBuy);

            PlayerPrefs.Save();
            buySound?.Play();
        }
        else
        {
            errorSound?.Play();
        }
        UpdateUI();
    }

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

            plusFuelBuy = PlayerPrefs.GetInt("PermanentTaskFuel", 0) + 10;
            PlayerPrefs.SetInt("PermanentTaskFuel", plusFuelBuy);

            PlayerPrefs.Save();
            buySound?.Play();
        }
        else
        {
            errorSound?.Play();
        }
        UpdateUI();
    }

    void Update()
    {
        UpdateDynamicDiscount();
        UpdatePrice();
        UpdateUI();
    }
}
