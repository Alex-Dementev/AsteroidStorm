using UnityEngine;
using UnityEngine.UI;

public class CreditsNegative : MonoBehaviour
{
    public int StatusInt;
    public Text Trables;
    public GameObject goTrables;
    public float DisCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("CreditsTimerStatus") == 2 && PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            PlayerPrefs.SetInt("CreditsTimerNegtive1", 1);
            PlayerPrefs.SetInt("CreditsTimerStatus", 0);
            PlayerPrefs.SetInt("CreditsTrables", 1);

            StatusInt = PlayerPrefs.GetInt("StatusPercent", 50);
            if(StatusInt >= 4)
                StatusInt -= 3;
            else
                StatusInt = 1;

            PlayerPrefs.SetInt("StatusPercent", StatusInt);

            goTrables.SetActive(true);
            Trables.text = "Ты задержал выплату кредита, втоимость металов пониженна на 8%";
        }
        if(PlayerPrefs.GetInt("CreditsTimerNegtive1") == 2 && PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            PlayerPrefs.SetInt("CreditsTimerNegtive2", 1);
            PlayerPrefs.SetInt("CreditsTimerNegtive1", 0);
            PlayerPrefs.SetInt("CreditsTrables", 2);

            StatusInt = PlayerPrefs.GetInt("StatusPercent", 50);
            if(StatusInt >= 6)
                StatusInt -= 5;
            else
                StatusInt = 1;

            PlayerPrefs.SetInt("StatusPercent", StatusInt);

            if(PlayerPrefs.GetInt("CreditsTimerNegtive1True", 0) == 0 && PlayerPrefs.GetInt("CreditsActivee", 0) == 1);
            {
                PlayerPrefs.SetInt("CreditsTimerNegtive1True", 1);

                StatusInt = PlayerPrefs.GetInt("StatusPercent", 50);
                if(StatusInt >= 3)
                    StatusInt -= 2;
                else
                    StatusInt = 1;

                PlayerPrefs.SetInt("StatusPercent", StatusInt);
            }

            goTrables.SetActive(true);
            Trables.text = "Ты задержал выплату кредита на 3 дня, втоимость металов пониженна на 15%";
        }
        if(PlayerPrefs.GetInt("CreditsTimerNegtive2") == 2 && PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            PlayerPrefs.SetInt("CreditsTimerNegtive2", 0);
            PlayerPrefs.SetInt("CreditsTrables", 3);


            StatusInt = PlayerPrefs.GetInt("StatusPercent", 50);
            if(StatusInt >= 9)
                StatusInt -= 8;
            else
                StatusInt = 1;

            PlayerPrefs.SetInt("StatusPercent", StatusInt);

            if(PlayerPrefs.GetInt("CreditsTimerNegtive2True", 0) == 0 && PlayerPrefs.GetInt("CreditsActivee", 0) == 1);
            {
                PlayerPrefs.SetInt("CreditsTimerNegtive2True", 1);

                StatusInt = PlayerPrefs.GetInt("StatusPercent", 50);
                if(StatusInt >= 6)
                    StatusInt -= 5;
                else
                    StatusInt = 1;

                PlayerPrefs.SetInt("StatusPercent", StatusInt);
            }

            goTrables.SetActive(true);
            Trables.text = "Ты задержал выплату кредита на 6 дней, втоимость металов пониженна на 25%";
        }

        if(PlayerPrefs.GetInt("CreditsTimerNegtive1_SecondsLeft") <= 2160 && PlayerPrefs.GetInt("CreditsTimerNegtive1_SecondsLeft") >= 1 && PlayerPrefs.GetInt("CreditsTimerNegtive1True", 0) == 0 && PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            PlayerPrefs.SetInt("CreditsTimerNegtive1True", 1);

            StatusInt = PlayerPrefs.GetInt("StatusPercent", 50);
            if(StatusInt >= 3)
                StatusInt -= 2;
            else
                StatusInt = 1;

            PlayerPrefs.SetInt("StatusPercent", StatusInt);

            goTrables.SetActive(true);
            Trables.text = "Пожалуйста, выплатите кредит, вы задержали выплату на полтора дня!";
        }
        if(PlayerPrefs.GetInt("CreditsTimerNegtive2_SecondsLeft") <= 2160 && PlayerPrefs.GetInt("CreditsTimerNegtive2_SecondsLeft") >= 1 && PlayerPrefs.GetInt("CreditsTimerNegtive2True", 0) == 0 && PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            PlayerPrefs.SetInt("CreditsTimerNegtive2True", 1);

            StatusInt = PlayerPrefs.GetInt("StatusPercent", 50);
            if(StatusInt >= 6)
                StatusInt -= 5;
            else
                StatusInt = 1;

            PlayerPrefs.SetInt("StatusPercent", StatusInt);

            goTrables.SetActive(true);
            Trables.text = "Пожалуйста, выплатите кредит, вы задержали выплату на четыре с половиной дня!";
        }
        if(PlayerPrefs.GetInt("CreditsTimerStatus_SecondsLeft") <= 4320 && PlayerPrefs.GetInt("CreditsTimerStatus") == 4 && PlayerPrefs.GetInt("CreditsTimerStatusTrue", 0) == 0 && PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            PlayerPrefs.SetInt("CreditsTimerStatusTrue", 1);

            PlayerPrefs.SetInt("StatusPercent", StatusInt);

            goTrables.SetActive(true);
            Trables.text = "У вас осталось 3 дня для того чтобы выплатить кредит!";
        }
    }
}
