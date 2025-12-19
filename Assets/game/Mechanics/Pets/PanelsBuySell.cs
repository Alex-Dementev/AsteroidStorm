using UnityEngine;

public class PanelsBuySell : MonoBehaviour
{
    public PrefPets pets1;
    public Animator SellPanel;
    public Animator BuyPanel;
    private int Coll;
    private int Slot;

    public void VBuyPanel()
    {
        BuyPanel.Play("Start");
    }
    public void VBuy()
    {
        BuyPanel.Play("End");
    }
    public void VBuyPanelExit()
    {
        BuyPanel.Play("End");
    }
    public void VSellPanel()
    {
        SellPanel.Play("Start");
    }
    public void VSell()
    {
        Slot = PlayerPrefs.GetInt("PetsSlot", 0);
        Coll = PlayerPrefs.GetInt(PlayerPrefs.GetString("BackPet" + Slot, ""), 0);
        Coll -= 1;
        PlayerPrefs.SetInt(PlayerPrefs.GetString("BackPet" + Slot, ""), Coll);
        pets1.UpdateSlots();
        SellPanel.Play("End");
    }
    public void SellPanelExit()
    {
        SellPanel.Play("End");
    }
}
