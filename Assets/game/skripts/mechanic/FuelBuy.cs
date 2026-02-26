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

    private int basePrice = 7;
    private int currentPrice;
    private int plusFuelBuy;

    public ActivateDisActivatePanels ads;
    public menu menu;

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

        // Загружаем последний сохранённый коэффициент
        dynamicDiscount = PlayerPrefs.GetFloat("dynamicDiscount", 1f);

        if (DateTime.TryParse(lastTime, out lastUpdate))
        {
            TimeSpan diff = DateTime.Now - lastUpdate;

            if (diff.TotalHours >= 1)
            {
                int hours = (int)diff.TotalHours;

                for (int i = 0; i < hours; i++)
                {
                    // Дельта изменения (от -15% до +15%)
                    float delta = UnityEngine.Random.Range(-0.15f, 0.15f);

                    // Применяем изменение
                    dynamicDiscount += dynamicDiscount * delta;

                    // Ограничиваем общие рамки 30%–180%
                    dynamicDiscount = Mathf.Clamp(dynamicDiscount, 0.3f, 1.8f);
                }

                PlayerPrefs.SetString("lastFuelUpdate", DateTime.Now.ToString());
                PlayerPrefs.SetFloat("dynamicDiscount", dynamicDiscount);
            }
        }
        else
        {
            // Первый запуск
            dynamicDiscount = 1f;
            PlayerPrefs.SetString("lastFuelUpdate", DateTime.Now.ToString());
            PlayerPrefs.SetFloat("dynamicDiscount", dynamicDiscount);
        }
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
        if(PlayerPrefs.GetInt("IndexDialogue", 0) <= 20)
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            if (coins >= currentPrice)
            {
                if(PlayerPrefs.GetInt("fuel", 0) <= 4)
                {
                    coins -= currentPrice;
                    PlayerPrefs.SetInt("coins", coins);

                    int cans = PlayerPrefs.GetInt("fuel", 0) + 1;
                    PlayerPrefs.SetInt("fuel", cans);
                    int allCans = PlayerPrefs.GetInt("AllTanks", 0) + 1;
                    PlayerPrefs.SetInt("AllTanks", allCans);

                    plusFuelBuy = PlayerPrefs.GetInt("PermanentTaskFuel", 0) + 1;
                    PlayerPrefs.SetInt("PermanentTaskFuel", plusFuelBuy);

                    PlayerPrefs.Save();
                    buySound?.Play();
                }
            }
            else
            {
                errorSound?.Play();
                ads.Activate();
                menu.activatepanel2();
            }
            UpdateUI();
        }
        else
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            if (coins >= currentPrice)
            {
                coins -= currentPrice;
                PlayerPrefs.SetInt("coins", coins);

                int cans = PlayerPrefs.GetInt("fuel", 0) + 1;
                PlayerPrefs.SetInt("fuel", cans);
                int allCans = PlayerPrefs.GetInt("AllTanks", 0) + 1;
                PlayerPrefs.SetInt("AllTanks", allCans);

                plusFuelBuy = PlayerPrefs.GetInt("PermanentTaskFuel", 0) + 1;
                PlayerPrefs.SetInt("PermanentTaskFuel", plusFuelBuy);

                PlayerPrefs.Save();
                buySound?.Play();
            }
            else
            {
                errorSound?.Play();
                ads.Activate();
                menu.activatepanel2();
            }
            UpdateUI();
        }
    }

    public void Click10()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) >= 21)
        {
            int coins = PlayerPrefs.GetInt("coins", 0);
            int cost10 = currentPrice * 10;

            if (coins >= cost10)
            {
                coins -= cost10;
                PlayerPrefs.SetInt("coins", coins);

                int cans = PlayerPrefs.GetInt("fuel", 0) + 10;
                PlayerPrefs.SetInt("fuel", cans);
                int allCans = PlayerPrefs.GetInt("AllTanks", 0) + 10;
                PlayerPrefs.SetInt("AllTanks", allCans);

                plusFuelBuy = PlayerPrefs.GetInt("PermanentTaskFuel", 0) + 10;
                PlayerPrefs.SetInt("PermanentTaskFuel", plusFuelBuy);

                PlayerPrefs.Save();
                buySound?.Play();
            }
            else
            {
                errorSound?.Play();
                ads.Activate();
                menu.activatepanel2();
            }
            UpdateUI();
        }
    }

    void Update()
    {
        UpdateDynamicDiscount();
        UpdatePrice();
        UpdateUI();
    }
}
