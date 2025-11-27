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

    public void Start()
    {
        StartCoroutine(TimerLoop());
    }

    private IEnumerator TimerLoop()
    {
        while (true)
        {
            Index = PlayerPrefs.GetInt("IndexToBuyBox", 0);
            Price = PlayerPrefs.GetInt("PriceToBuyBox", 0);
            PriceText.text = "" + Price;
            Coins = PlayerPrefs.GetInt("coins", 0);
            Name.text = "" + PlayerPrefs.GetString("NameBuyBox");


            yield return new WaitForSeconds(0.5f);
        }
    }

    public void Close()
    {
        BuyPanel.Play("End");
    }
    public void Buy()
    {
        if(Coins >= Price)
        {
            BuyPanel.Play("End");
            Coins -= Price;
            PlayerPrefs.SetInt("coins", Coins);
            PlayerPrefs.SetInt(Index + "BuyBoxes", Index);
            Approved.Play();
        }
        else
        {
            Fail.Play();
        }
    }
}
