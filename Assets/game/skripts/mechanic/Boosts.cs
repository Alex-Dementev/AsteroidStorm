using UnityEngine;
using UnityEngine.UI;

public class Boosts : MonoBehaviour
{
    public int Index;
    public Text Desc;
    public Text Timer;
    public Text DescTimerPrice;
    public Text Buy;
    public GameObject GoTimerPrice;
    public GameObject GoBuy;
    public GameObject GoSlider;
    public Slider Slider;
    public Image BuyImage;
    public GameObject GoMoney;


    void Start()
    {
        if(Index == 1 && PlayerPrefs.GetInt("Boost1", 0) == 0)
        {
            Timer.text = "";
        }
        if(Index == 2 && PlayerPrefs.GetInt("Boost2", 0) == 0)
        {
           Timer.text = "";
        }
        if(Index == 3 && PlayerPrefs.GetInt("Boost3", 0) == 0)
        {
            Timer.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDesc()
    {
        GoBuy.SetActive(true);
        GoSlider.SetActive(true);
        GoTimerPrice.SetActive(true);
        GoMoney.SetActive(false);

        if(Index == 0)
        {
            GoBuy.SetActive(false);
            GoSlider.SetActive(false);
            GoTimerPrice.SetActive(false);
            Desc.text = "Промах";
        }
        if(Index == 1)
        {
            Desc.text = "Канистры будут вмещать на 35% больше топлива на 1 час";

            if(PlayerPrefs.GetInt("Boost1", 0) >= 1)
            {
                Buy.text = "Купленно";
                BuyImage.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            else
            {
                GoSlider.SetActive(false);

                DescTimerPrice.text = "Цена: 775    ";
                GoMoney.SetActive(true);
                Buy.text = "Купить";

                if(PlayerPrefs.GetInt("coins", 0) >= 775)
                    BuyImage.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    BuyImage.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
        }
        if(Index == 2)
        {
            Desc.text = "Выработка энергии больше на 50%, на 2 часа";

            if(PlayerPrefs.GetInt("Boost2", 0) >= 1)
            {
                Buy.text = "Купленно";
                BuyImage.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            else
            {
                GoSlider.SetActive(false);

                DescTimerPrice.text = "Цена: 700    ";
                GoMoney.SetActive(true);
                Buy.text = "Купить";

                if(PlayerPrefs.GetInt("coins", 0) >= 775)
                    BuyImage.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    BuyImage.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
        }
        if(Index == 3)
        {
            Desc.text = "Масса астероидов больше на 70%, на 1 час";

            if(PlayerPrefs.GetInt("Boost3", 0) >= 1)
            {
                Buy.text = "Купленно";
                BuyImage.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            else
            {
                GoSlider.SetActive(false);

                DescTimerPrice.text = "Цена: 850    ";
                GoMoney.SetActive(true);
                Buy.text = "Купить";

                if(PlayerPrefs.GetInt("coins", 0) >= 775)
                    BuyImage.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    BuyImage.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
        }
    }
}
