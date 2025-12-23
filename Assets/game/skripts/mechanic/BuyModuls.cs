using UnityEngine;
using UnityEngine.UI;

public class BuyModuls : MonoBehaviour
{
    public string NamePP;
    public string Index;
    public int IndexStatus;
    public Text CoinsTextToBuy;
    public int CoinsToBuy;
    public GameObject YouBuy;
    public int coins;
    public int Quantity;
    public AudioSource ad;
    public AudioSource adfail;

    
    void Start()
    {
        CoinsTextToBuy.text = "" + CoinsToBuy;

        IndexStatus = PlayerPrefs.GetInt(Index, 0);
        if(IndexStatus == 1)
            YouBuy.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("ResetBuyModuls", 0) == 1)
        {
            PlayerPrefs.SetInt(Index, 0);
            YouBuy.SetActive(false);
        }
    }

    public void Buy()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        if(coins >= CoinsToBuy)
        {
            coins -= CoinsToBuy;
            PlayerPrefs.SetInt("coins", coins);
            IndexStatus = 1;
            PlayerPrefs.SetInt(Index, IndexStatus);
            Quantity = PlayerPrefs.GetInt(NamePP, 0);
            Quantity++;
            PlayerPrefs.SetInt(NamePP, Quantity);
            YouBuy.SetActive(true);
            ad.Play();

            if(NamePP == "P1")
                PlayerPrefs.SetInt("P1Buy", 1);
            if(NamePP == "P2")
                PlayerPrefs.SetInt("P2Buy", 1);
            if(NamePP == "P3")
                PlayerPrefs.SetInt("P3Buy", 1);
            if(NamePP == "P4")
                PlayerPrefs.SetInt("P4Buy", 1);
            if(NamePP == "P5")
                PlayerPrefs.SetInt("P5Buy", 1);
        }
        else
            adfail.Play();
    }
}
