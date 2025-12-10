using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public GameObject goGet;
    public GameObject goPayOff;


    [Header("UI")]
    public Text CoinsGive;
    public Text CoinsSet;
    public Text CoinsPayOff;
    public Text Percent;
    public Text Status;
    public Slider GetSlider;
    public Slider PayOffSlider;
    public Text Timer;
    public AudioSource No;
    public AudioSource Yes;
    private float PercentToSlider;
    private int StatusInt;
    private int Coins;
    private int AllCoins;
    private int PayOffint;
    public float PercentCalc;

    void Start()
    {
        if(PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            goGet.SetActive(false);
            goPayOff.SetActive(true);
        }
        else
        {
            StatusInt = PlayerPrefs.GetInt("StatusPercent", 50);
            Status.text = "Статус: " + StatusInt + "%";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            CoinsPayOff.text = "" + PayOffSlider.value;
            CoinsSet.text = "" + PlayerPrefs.GetInt("CreditNumber", 0) + " монет";
            PayOffint = (int)PayOffSlider.value;

            if(PlayerPrefs.GetInt("coins", 0) <= PlayerPrefs.GetInt("CreditNumber", 0))
                PayOffSlider.maxValue = PlayerPrefs.GetInt("coins", 0);
            else
                PayOffSlider.maxValue = PlayerPrefs.GetInt("CreditNumber", 0);

            Timer.text = PlayerPrefs.GetString("CreditsTimerStatus_Text", "");

            if(PlayerPrefs.GetInt("CreditsTrables", 0) == 1)
            {
                Timer.text = PlayerPrefs.GetString("CreditsTimerNegtive1_Text", "");

                if(PlayerPrefs.GetInt("CreditsTrables", 0) == 2)
                {
                    Timer.text = PlayerPrefs.GetString("CreditsTimerNegtive2_Text", "");

                    if(PlayerPrefs.GetInt("CreditsTrables", 0) == 3)
                    {
                        Timer.text = "";
                    }
                }
            }
        }

        if(PlayerPrefs.GetInt("CreditsActivee", 0) == 0)
        {
            PercentToSlider = PlayerPrefs.GetFloat("CreditMaxCoins", 1);
            GetSlider.maxValue = 800 * PercentToSlider * (StatusInt / 50);
            CoinsGive.text = "" + GetSlider.value;
            Percent.text = "проценты: " + PlayerPrefs.GetInt("CreditsPercent", 7) + "%";
        }
    }

    public void PayOff()
    {
        if(PayOffint >= 1)
        {
            Yes.Play();
            Coins = PlayerPrefs.GetInt("coins", 0);
            Coins -= (int)PayOffint;
            PlayerPrefs.SetInt("coins", Coins);
            PercentCalc = PlayerPrefs.GetInt("CreditNumber", 0);
            PercentCalc -= (int)PayOffint;
            PlayerPrefs.SetInt("CreditNumber", (int)PercentCalc);
        }
        else
            No.Play();

        if(PlayerPrefs.GetInt("CreditNumber", 0) <= 0)
        {
            PlayerPrefs.SetInt("CreditsActivee", 0);
            PlayerPrefs.SetInt("CreditsTimerStatus", 3);
            PlayerPrefs.SetInt("CreditsTimerNegtive1", 3);
            PlayerPrefs.SetInt("CreditsTimerNegtive2", 3);
            PlayerPrefs.SetInt("CreditsTrables", 0);
            goGet.SetActive(true);
            goPayOff.SetActive(false);
        }
    }
    public void Get()
    {
        PlayerPrefs.SetInt("CreditsActivee", 1);
        PercentCalc = PlayerPrefs.GetInt("CreditsPercent", 7);
        PercentCalc = PercentCalc / 100 * GetSlider.value;
        int sum = (int)(PercentCalc + GetSlider.value);
        PlayerPrefs.SetInt("CreditNumber", sum);
        goGet.SetActive(false);
        goPayOff.SetActive(true);
        Coins = PlayerPrefs.GetInt("coins", 0);
        Coins += (int)GetSlider.value;
        AllCoins = PlayerPrefs.GetInt("allcoins", 0);
        AllCoins += (int)GetSlider.value;
        PlayerPrefs.SetInt("coins", Coins);
        PlayerPrefs.SetInt("allcoins", AllCoins);
        Yes.Play();
        PlayerPrefs.SetInt("CreditsTimerStatus", 1);
    }
}
