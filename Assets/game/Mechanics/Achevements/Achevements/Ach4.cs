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

    public GameObject[] Dialogue;
    public GameObject DisActive;


    void Start()
    {
        if(PlayerPrefs.GetInt("Ach4Start", 0) == 0)
            Dialogue[0].SetActive(true);

        if(PlayerPrefs.GetInt("Rest", 25000) <= 0)
        {
            DisActive.SetActive(false);
        }

        if(PlayerPrefs.GetInt("coins", 0) >= PlayerPrefs.GetInt("Rest", 25000))
            toPush.maxValue = PlayerPrefs.GetInt("Rest", 25000);
        else
            toPush.maxValue = PlayerPrefs.GetInt("coins", 0);

        TextToPush.text = "" + toPush.value;

        if(PlayerPrefs.GetInt("CristalFirstOpen", 0) == 1)
            Dialogue[0].SetActive(true);

        Rest.text = "Собрать: " + PlayerPrefs.GetInt("Rest", 25000) + " из 25000";


        if(PlayerPrefs.GetInt("Rest", 25000) <= 0 && PlayerPrefs.GetInt("Ach4End", 0) == 0)
            Dialogue[1].SetActive(true);
        if(PlayerPrefs.GetInt("Rest", 25000) <= 0)
        {
            DisActive.SetActive(false);
            Complete.text = "Проход к черной дыре открыт! вы готовы?";
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

            MinusPush = PlayerPrefs.GetInt("Rest", 25000);
            MinusPush -= (int)toPush.value;
            PlayerPrefs.SetInt("Rest", MinusPush);
            MinusPush = PlayerPrefs.GetInt("coins", 25000);
            MinusPush -= (int)toPush.value;
            PlayerPrefs.SetInt("coins", MinusPush);


            Rest.text = "Собрать: " + PlayerPrefs.GetInt("Rest", 25000) + " из 25000";

            if(PlayerPrefs.GetInt("Rest", 25000) <= 0 && PlayerPrefs.GetInt("Ach4End", 0) == 0)
                Dialogue[1].SetActive(true);
            if(PlayerPrefs.GetInt("Rest", 25000) <= 0)
            {
                DisActive.SetActive(false);
                Complete.text = "Проход к черной дыре открыт! вы готовы?";
            }

            if(PlayerPrefs.GetInt("coins", 0) >= PlayerPrefs.GetInt("Rest", 25000))
                toPush.maxValue = PlayerPrefs.GetInt("Rest", 25000);
            else
                toPush.maxValue = PlayerPrefs.GetInt("coins", 0);
        }
    }
}
