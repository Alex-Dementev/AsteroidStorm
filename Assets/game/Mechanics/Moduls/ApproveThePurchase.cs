using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ApproveThePurchase : MonoBehaviour
{
    public Animator BuyPanel;
    public int Index;
    public int Coins;
    public int Price;
    public Text PriceText;
    public AudioSource Fail;
    public AudioSource Approved;
    public Text Name;


    public void Open()
    {
        Index = PlayerPrefs.GetInt("IndexToBuyBox", 0);
        Price = PlayerPrefs.GetInt("PriceToBuyBox", 0);
        PriceText.text = "" + Price;
        Name.text = "" + PlayerPrefs.GetString("NameBuyBox");
    }

    public void Close()
    {
        BuyPanel.Play("End");
    }
    public void Buy()
    {
        Coins = PlayerPrefs.GetInt("coins", 0);
        
        if(Coins >= Price)
        {
            BuyPanel.Play("End");
            Coins -= Price;
            PlayerPrefs.SetInt("coins", Coins);

            if(Index == 8 || Index == 6 || Index == 4 || Index == 2)
            {
                if(PlayerPrefs.GetInt("2BuyBoxes", 0) == 2 && PlayerPrefs.GetInt("4BuyBoxes", 0) == 4 && PlayerPrefs.GetInt("6BuyBoxes", 0) == 6)
                {
                    PlayerPrefs.SetInt(8 + "BuyBoxes", 8);
                }
                else if(PlayerPrefs.GetInt("2BuyBoxes", 0) == 2 && PlayerPrefs.GetInt("4BuyBoxes", 0) == 4)
                {
                    PlayerPrefs.SetInt(6 + "BuyBoxes", 6);
                }
                else if(PlayerPrefs.GetInt("2BuyBoxes", 0) == 2)
                {
                    PlayerPrefs.SetInt(4 + "BuyBoxes", 4);
                }
                else
                {
                    PlayerPrefs.SetInt(2 + "BuyBoxes", 2);
                }
            }
            else
                PlayerPrefs.SetInt(Index + "BuyBoxes", Index);

            BoxEvents.TriggerBoxesUpdated();
                
            Approved.Play();

        }
        else
        {
            Fail.Play();
        }
    }
}
