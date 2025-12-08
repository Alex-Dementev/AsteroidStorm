using UnityEngine;
using UnityEngine.UI;

public class BuyBoosts : MonoBehaviour
{
    public Boosts b1;
    public Boosts b2;
    public Boosts b3;
    private int Index;
    private int Coins;
    public AudioSource No;
    public AudioSource Yes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerPrefs.GetInt("Boost1Timer", 0) == 2)
        {
            PlayerPrefs.SetInt("Boost1Timer", 0);
            PlayerPrefs.SetInt("Boost1", 0);
            b1.UpdateDesc();
            No.Play();
            Debug.Log("ddf");
        }
        if(PlayerPrefs.GetInt("Boost2Timer", 0) == 2)
        {
            PlayerPrefs.SetInt("Boost2Timer", 0);
            PlayerPrefs.SetInt("Boost2", 0);
            b2.UpdateDesc();
            No.Play();
            Debug.Log("dsddf");
        }
        if(PlayerPrefs.GetInt("Boost3Timer", 0) == 2)
        {
            PlayerPrefs.SetInt("Boost3Timer", 0);
            PlayerPrefs.SetInt("Boost3", 0);
            b3.UpdateDesc();
            No.Play();
            Debug.Log("ddsf");
        }
    }

    public void Buy()
    {
        Index = PlayerPrefs.GetInt("IndexBoost", 0);

        if(Index == 1 && PlayerPrefs.GetInt("Boost1", 0) == 0 && PlayerPrefs.GetInt("coins", 0) >= 775)
        {
            Coins = PlayerPrefs.GetInt("coins", 0);
            Coins -= 775;
            PlayerPrefs.SetInt("coins", Coins);
            Yes.Play();
            PlayerPrefs.SetInt("Boost1", 1);
            PlayerPrefs.SetInt("Boost1Timer", 1);
            b1.UpdateDesc();
        }
        else if(Index == 1 && PlayerPrefs.GetInt("coins", 0) <= 775 || Index == 1 && PlayerPrefs.GetInt("Boost1", 0) == 1)
            No.Play();
        
        if(Index == 2 && PlayerPrefs.GetInt("Boost2", 0) == 0 && PlayerPrefs.GetInt("coins", 0) >= 700)
        {
            Coins = PlayerPrefs.GetInt("coins", 0);
            Coins -= 775;
            PlayerPrefs.SetInt("coins", Coins);
            Yes.Play();
            PlayerPrefs.SetInt("Boost2", 1);
            PlayerPrefs.SetInt("Boost2Timer", 1);
            b2.UpdateDesc();
        }
        else if(Index == 2 && PlayerPrefs.GetInt("coins", 0) <= 700 || Index == 2 && PlayerPrefs.GetInt("Boost2", 0) == 1)
            No.Play();

        if(Index == 3 && PlayerPrefs.GetInt("Boost3", 0) == 0 && PlayerPrefs.GetInt("coins", 0) >= 850)
        {
            Coins = PlayerPrefs.GetInt("coins", 0);
            Coins -= 775;
            PlayerPrefs.SetInt("coins", Coins);
            Yes.Play();
            PlayerPrefs.SetInt("Boost3", 1);
            PlayerPrefs.SetInt("Boost3Timer", 1);
            b3.UpdateDesc();
        }
        else if(Index == 3 && PlayerPrefs.GetInt("coins", 0) <= 850 || Index == 3 && PlayerPrefs.GetInt("Boost3", 0) == 1)
            No.Play();
    }
}
