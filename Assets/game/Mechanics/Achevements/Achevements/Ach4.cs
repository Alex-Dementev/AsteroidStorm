using UnityEngine;
using UnityEngine.UI;

public class Ach4 : MonoBehaviour
{
    public Slider toPush;
    private int MinusPush;
    public Text TextToPush;
    public Text Rest;
    public Text Complete;
    public AudioSource Yes;
    public AudioSource No;
    public descriptionasglavs descriptionasglavs;

    public GameObject[] Dialogue;
    public GameObject DisActive;

    public GameObject[] To5G;


    void OnEnable()
    {
        if(PlayerPrefs.GetInt("g2passed", 0) == 1 && PlayerPrefs.GetInt("Ach4Start2", 0) == 0)
            Dialogue[2].SetActive(true);    

        if(PlayerPrefs.GetInt("Ach4Start", 0) == 0)
            Dialogue[0].SetActive(true);

        if(PlayerPrefs.GetInt("Rest", 12000) <= 0 && PlayerPrefs.GetInt("g2passed", 0) == 0 || PlayerPrefs.GetInt("Rest2", 14945) == 0)
            DisActive.SetActive(false);

        if(PlayerPrefs.GetInt("g2passed", 0) == 0)
        {
            if(PlayerPrefs.GetInt("coins", 0) >= PlayerPrefs.GetInt("Rest", 12000))
                toPush.maxValue = PlayerPrefs.GetInt("Rest", 12000);
            else
                toPush.maxValue = PlayerPrefs.GetInt("coins", 0);

            TextToPush.text = "" + toPush.value;

            if(PlayerPrefs.GetInt("CristalFirstOpen", 0) == 1)
                Dialogue[0].SetActive(true);

            Rest.text = "Собрать: " + PlayerPrefs.GetInt("Rest", 12000) + " из 12000";


            if(PlayerPrefs.GetInt("Rest", 12000) <= 0 && PlayerPrefs.GetInt("Ach4End", 0) == 0)
                Dialogue[1].SetActive(true);
            if(PlayerPrefs.GetInt("Rest", 12000) <= 0)
            {
                DisActive.SetActive(false);
                Complete.text = "Проход к черной дыре открыт! вы готовы?";
            }
        }
        else
        {
            if(PlayerPrefs.GetInt("coins", 0) >= PlayerPrefs.GetInt("Rest2", 14945))
                toPush.maxValue = PlayerPrefs.GetInt("Rest2", 14945);
            else
                toPush.maxValue = PlayerPrefs.GetInt("coins", 0);

            TextToPush.text = "" + toPush.value;

            if(PlayerPrefs.GetInt("CristalFirstOpen", 0) == 1)
                Dialogue[2].SetActive(true);

            Rest.text = "Собрать: " + PlayerPrefs.GetInt("Rest2", 14945) + " из 14945";


            if(PlayerPrefs.GetInt("Rest2", 14945) <= 0 && PlayerPrefs.GetInt("Ach4End2", 0) == 0)
                Dialogue[3].SetActive(true);
            if(PlayerPrefs.GetInt("Rest2", 14945) <= 0)
            {
                DisActive.SetActive(false);
                Complete.text = "Теперь ты точно готов!";
            }
        }
    }

    void Update()
    {
        TextToPush.text = "" + toPush.value;
    }

    public void Push()
    {
        if((int)toPush.value <= 0)
            No.Play();
        else
        {
            Yes.Play();

            if(PlayerPrefs.GetInt("g2passed", 0) == 0)
            {
                MinusPush = PlayerPrefs.GetInt("Rest", 12000);
                MinusPush -= (int)toPush.value;
                PlayerPrefs.SetInt("Rest", MinusPush);
                MinusPush = PlayerPrefs.GetInt("coins", 12000);
                MinusPush -= (int)toPush.value;
                PlayerPrefs.SetInt("coins", MinusPush);


                Rest.text = "Собрать: " + PlayerPrefs.GetInt("Rest", 12000) + " из 12000";

                if(PlayerPrefs.GetInt("Rest", 12000) <= 0 && PlayerPrefs.GetInt("Ach4End", 0) == 0)
                    Dialogue[1].SetActive(true);
                if(PlayerPrefs.GetInt("Rest", 12000) <= 0)
                {
                    DisActive.SetActive(false);
                    Complete.text = "Проход к черной дыре открыт! вы готовы?";

                    descriptionasglavs.UpdateControllers();
                }

                if(PlayerPrefs.GetInt("coins", 0) >= PlayerPrefs.GetInt("Rest", 12000))
                    toPush.maxValue = PlayerPrefs.GetInt("Rest", 12000);
                else
                    toPush.maxValue = PlayerPrefs.GetInt("coins", 0);
            }
            else
            {
                MinusPush = PlayerPrefs.GetInt("Rest2", 14945);
                MinusPush -= (int)toPush.value;
                PlayerPrefs.SetInt("Rest2", MinusPush);
                MinusPush = PlayerPrefs.GetInt("coins", 14945);
                MinusPush -= (int)toPush.value;
                PlayerPrefs.SetInt("coins", MinusPush);


                Rest.text = "Собрать: " + PlayerPrefs.GetInt("Rest2", 14945) + " из 14945";

                if(PlayerPrefs.GetInt("Rest2", 14945) <= 0 && PlayerPrefs.GetInt("Ach4End2", 0) == 0)
                    Dialogue[3].SetActive(true);
                if(PlayerPrefs.GetInt("Rest2", 14945) <= 0)
                {
                    DisActive.SetActive(false);
                    Complete.text = "Проход к черной дыре открыт! вы готовы?";
                    
                    foreach (GameObject msg in To5G)
                        msg.SetActive(false);

                    descriptionasglavs.UpdateControllers();
                }

                if(PlayerPrefs.GetInt("coins", 0) >= PlayerPrefs.GetInt("Rest2", 14945))
                    toPush.maxValue = PlayerPrefs.GetInt("Rest2", 14945);
                else
                    toPush.maxValue = PlayerPrefs.GetInt("coins", 0);
            }
        }
    }
}
