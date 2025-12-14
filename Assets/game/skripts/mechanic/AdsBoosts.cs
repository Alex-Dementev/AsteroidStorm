using UnityEngine;
using UnityEngine.UI;

public class AdsBoosts : MonoBehaviour
{
    public Text CoinsText;
    public int Coins;
    public Text NotText;
    public Text NotTextYes;
    public int Not;

    void Update()
    {
        Coins = (int)(40 * PlayerPrefs.GetFloat("CreditMaxCoins", 1));
        CoinsText.text = "За рекламу:" + Coins;
    }
    void Start()
    {
        Not = PlayerPrefs.GetInt("AdsNot", 0);

        if(Not >=1 && Not <= 3)
            NotText.text = "Спасибо!";
        if(Not >=4 && Not <= 6)
            NotText.text = "Большое спасибо!";
        if(Not >=7)
            NotText.text = "Огромное спасибо!";

        if(Not >= 1)
            NotTextYes.text = "Помочь проекту!";
    }

    public void BuyCoins()
    {
        
    }
    public void BuyNot()
    {
        Not++;
        PlayerPrefs.SetInt("AdsNot", Not);

        if(Not >=1 && Not <= 3)
            NotText.text = "Спасибо!";
        if(Not >=4 && Not <= 6)
            NotText.text = "Большое спасибо!";
        if(Not >=7)
            NotText.text = "Огромное спасибо!";

        if(Not >= 1)
            NotTextYes.text = "Помочь проекту!";
    }
}
