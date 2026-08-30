using UnityEngine;
using UnityEngine.UI;

public class PanelsBuySell : MonoBehaviour
{
    public PrefPets pets1;
    public Animator SellPanel;
    public Animator BuyPanel;
    private int Coll;
    private int Slot;
    public Text Coins;
    public AudioSource Yes;
    public AudioSource No;
    public GameObject BuySlot1;
    public GameObject BuySlot2;
    public GameObject BuySlot3;
    public GameObject BuySlot4;
    private int CoinsInt;

    public void VBuyPanel()
    {
        BuyPanel.CrossFade("Start", 0.1f);
        
        if(PlayerPrefs.GetInt("BuySlots", 0) == 3)
        {
            Coins.text = "3500";
        }
        if(PlayerPrefs.GetInt("BuySlots", 0) == 2)
        {
            Coins.text = "2500";
        }
        else if(PlayerPrefs.GetInt("BuySlots", 0) == 1)
        {
            Coins.text = "1500";
        }
        else if(PlayerPrefs.GetInt("BuySlots", 0) == 0)
        {
            Coins.text = "500";
        }
    }
    public void VBuy()
    {
        if(PlayerPrefs.GetInt("BuySlots", 0) == 3 && PlayerPrefs.GetInt("coins", 0) >= 3500)
        {
            BuySlot1.SetActive(false);
            BuySlot2.SetActive(false);
            BuySlot3.SetActive(false);
            BuySlot4.SetActive(false);
            PlayerPrefs.SetInt("BuySlots", 4);
            Yes.Play();
            VBuyPanelExit();
        }
        if(PlayerPrefs.GetInt("BuySlots", 0) == 2 && PlayerPrefs.GetInt("coins", 0) >= 2500)
        {
            BuySlot1.SetActive(false);
            BuySlot2.SetActive(false);
            BuySlot3.SetActive(false);
            PlayerPrefs.SetInt("BuySlots", 3);
            Yes.Play();
            VBuyPanelExit();
        }
        else if(PlayerPrefs.GetInt("BuySlots", 0) == 1 && PlayerPrefs.GetInt("coins", 0) >= 1500)
        {
            BuySlot1.SetActive(false);
            BuySlot2.SetActive(false);
            PlayerPrefs.SetInt("BuySlots", 2);
            Yes.Play();
            VBuyPanelExit();
        }
        else if(PlayerPrefs.GetInt("BuySlots", 0) == 0 && PlayerPrefs.GetInt("coins", 0) >= 500)
        {
            BuySlot1.SetActive(false);
            PlayerPrefs.SetInt("BuySlots", 1);
            Yes.Play();
            VBuyPanelExit();
        }
        else
            No.Play();
    }
    public void VBuyPanelExit()
    {
        BuyPanel.CrossFade("End", 0.1f);
    }
    public void VSellPanel()
    {
        SellPanel.CrossFade("Start", 0.1f);
    }
    public void VSell()
    {
        Slot = PlayerPrefs.GetInt("PetsSlot", 0);
        Coll = PlayerPrefs.GetInt(PlayerPrefs.GetString("BackPet" + Slot, ""), 0);
        Coll -= 1;
        PlayerPrefs.SetInt(PlayerPrefs.GetString("BackPet" + Slot, ""), Coll);

        CoinsInt = PlayerPrefs.GetInt("coins", 0);
        CoinsInt += 1650;
        PlayerPrefs.SetInt("coins", CoinsInt);
        CoinsInt = PlayerPrefs.GetInt("allcoins", 0);
        CoinsInt += 1650;
        PlayerPrefs.SetInt("allcoins", CoinsInt);

        pets1.UpdateSlots();
        Yes.Play();
        SellPanel.CrossFade("End", 0.1f);
    }
    public void VSellPanelExit()
    {
        SellPanel.CrossFade("End", 0.1f);
    }


    void Start()
    {
        if(PlayerPrefs.GetInt("BuySlots", 0) == 4)
        {
            BuySlot1.SetActive(false);
            BuySlot2.SetActive(false);
            BuySlot3.SetActive(false);
            BuySlot4.SetActive(false);
        }
        if(PlayerPrefs.GetInt("BuySlots", 0) == 3)
        {
            BuySlot1.SetActive(false);
            BuySlot2.SetActive(false);
            BuySlot3.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("BuySlots", 0) == 2)
        {
            BuySlot1.SetActive(false);
            BuySlot2.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("BuySlots", 0) == 1)
        {
            BuySlot1.SetActive(false);
        }
    }
}
