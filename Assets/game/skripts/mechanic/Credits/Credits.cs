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
    private float StatusFloat;
    private int Coins;
    private int AllCoins;
    private int PayOffint;
    private float PercentCalc;
    public Text Trables;
    public Animator TrablesAnim;
    private float DisCount;

    public GameObject Casino;

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
            Status.text = "Рейтинг: " + StatusInt + "%";
        }

        if(PlayerPrefs.GetInt("NumCredits", 0) >= 1)
        {
            if(PlayerPrefs.GetInt("CreditsDialogue", 0) == 0)
            {
                Casino.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Trables.text = "Следующий кредит можно взять через: " + PlayerPrefs.GetString("DelayCredits_Text", "");

        if(PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            CoinsPayOff.text = "" + PayOffSlider.value;
            CoinsSet.text = "" + PlayerPrefs.GetInt("CreditNumber", 0) + " монет";
            PayOffint = (int)PayOffSlider.value;

            if(PlayerPrefs.GetInt("coins", 0) <= PlayerPrefs.GetInt("CreditNumber", 0))
                PayOffSlider.maxValue = PlayerPrefs.GetInt("coins", 0);
            else
                PayOffSlider.maxValue = PlayerPrefs.GetInt("CreditNumber", 0);

            if(PlayerPrefs.GetInt("CreditsTrables", 0) == 0)
            {
                Timer.text = PlayerPrefs.GetString("CreditsTimerStatus_Text", "");
                Timer.color = new Color(1, 61/255f, 245/255f);
            }
            if(PlayerPrefs.GetInt("CreditsTrables", 0) == 1)
            {
                Timer.text = PlayerPrefs.GetString("CreditsTimerNegtive1_Text", "");
                Timer.color = new Color(1, 61/255f, 149/255f);
            }
            if(PlayerPrefs.GetInt("CreditsTrables", 0) == 2)
            {
                Timer.text = PlayerPrefs.GetString("CreditsTimerNegtive2_Text", "");
                Timer.color = new Color(1, 61/255f, 110/255f);
            }
            if(PlayerPrefs.GetInt("CreditsTrables", 0) == 3)
            {
                Timer.text = "Стоимость металов -25%";
                Timer.color = new Color(1, 61/255f, 110/255f);
            }
        }

        if(PlayerPrefs.GetInt("CreditsActivee", 0) == 0)
        {
            PercentToSlider = PlayerPrefs.GetFloat("CreditMaxCoins", 1);
            StatusFloat = StatusInt;
            StatusFloat = StatusFloat / 50;
            GetSlider.minValue = ((int)(800 * PercentToSlider * (StatusFloat + ((1 - StatusFloat) * 0.25)))) / 3;
            GetSlider.maxValue = (int)(800 * PercentToSlider * (StatusFloat + ((1 - StatusFloat) * 0.25)));
            CoinsGive.text = "" + GetSlider.value;
            Percent.text = "проценты: " + Mathf.RoundToInt(PlayerPrefs.GetInt("CreditsPercent", 7) * (1f + ((50f - PlayerPrefs.GetInt("StatusPercent", 50)) / 100f))) + "%";
            Debug.Log(PlayerPrefs.GetInt("CreditsPercent", 7));
            Debug.Log(PlayerPrefs.GetInt("StatusPercent", 50));
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

            PlayerPrefs.SetInt("CreditsTimerNegtive1True", 0);
            PlayerPrefs.SetInt("CreditsTimerNegtive2True", 0);
            PlayerPrefs.SetInt("CreditsTimerStatusTrue", 0);

            PlayerPrefs.SetInt("DelayCredits", 1);

            if(PlayerPrefs.GetInt("CreditsTimerStatus_SecondsLeft") >= 8640)
            {
                StatusInt = PlayerPrefs.GetInt("StatusPercent", 50);
                
                if(StatusInt <= 98)
                    StatusInt += 2;
                else
                    StatusInt = 100;

                PlayerPrefs.SetInt("StatusPercent", StatusInt);
            }
            else if(PlayerPrefs.GetInt("CreditsTimerStatus_SecondsLeft") >= 5040)
            {
                StatusInt = PlayerPrefs.GetInt("StatusPercent", 50);
                
                if(StatusInt <= 99)
                    StatusInt += 1;
                else
                    StatusInt = 100;

                PlayerPrefs.SetInt("StatusPercent", StatusInt);
            }

            int NumCredits = PlayerPrefs.GetInt("NumCredits", 0);
            NumCredits++;
            PlayerPrefs.SetInt("NumCredits", NumCredits);

            if(PlayerPrefs.GetInt("NumCredits", 0) >= 1)
            {
                if(PlayerPrefs.GetInt("CreditsDialogue", 0) == 0)
                {
                    Casino.SetActive(true);
                }
            }

            StatusInt = PlayerPrefs.GetInt("StatusPercent", 50);
            Status.text = "Рейтинг: " + StatusInt + "%";
        }
    }
    public void Get()
    {
        if(PlayerPrefs.GetInt("DelayCredits", 0) != 4 && PlayerPrefs.GetInt("IndexDialogue", 0) != 5)
        {
            PlayerPrefs.SetInt("CreditsActivee", 1);
            PercentCalc = PlayerPrefs.GetInt("CreditsPercent", 7);
            PercentCalc = Mathf.RoundToInt((PercentCalc * (1f + ((50f - PlayerPrefs.GetInt("StatusPercent", 50)) / 100f)) / 100f) * GetSlider.value);
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
            PlayerPrefs.SetInt("DelayCredits", 0);
        }
        else if(PlayerPrefs.GetInt("DelayCredits", 0) != 4 && PlayerPrefs.GetInt("IndexDialogue", 0) == 5 && GetSlider.value >= 799)
        {
            PlayerPrefs.SetInt("CreditsActivee", 1);
            PercentCalc = PlayerPrefs.GetInt("CreditsPercent", 7);
            PercentCalc = Mathf.RoundToInt((PercentCalc * (1f + ((50f - PlayerPrefs.GetInt("StatusPercent", 50)) / 100f)) / 100f) * GetSlider.value);
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
            PlayerPrefs.SetInt("DelayCredits", 0);
        }
        else if(PlayerPrefs.GetInt("IndexDialogue", 0) != 5)
        {
            TrablesAnim.Play("Start4");
        }
    }
}
