using UnityEngine;
using UnityEngine.UI;

public class AdsBoosts : MonoBehaviour
{
    [Header("Texts")]
    public Text CoinsText;
    private int Coins;
    public Text NotText;
    public Text NotTextYes;
    private int Not;

    [Header("AudioSources")]
    public AudioSource Yes;
    public AudioSource No;

    void Update()
    {
        Coins = (int)(40 * PlayerPrefs.GetFloat("CreditMaxCoins", 1));
        CoinsText.text = "За рекламу: +" + Coins;
    }
    void Start()
    {
        Not = PlayerPrefs.GetInt("AdsNot", 0);

        if(Not >= 1 && Not <= 3)
            NotText.text = "Спасибо!";
        if(Not >= 4 && Not <= 6)
            NotText.text = "Большое спасибо!";
        if(Not >= 7 && Not <= 10)
            NotText.text = "Огромное спасибо!";
        if(Not >= 11 && Not <= 15)
            NotText.text = "МЕГА спасибо!";
        if(Not >= 16)
            NotText.text = "УЛЬТРА спасибо!";

        if(Not >= 1)
            NotTextYes.text = "Помочь проекту!";
    }

    public void BuyCoins()
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + Coins);

        Yes.Play();
    }
    public void BuyNot()
    {
        Not++;
        PlayerPrefs.SetInt("AdsNot", Not);

        if(Not >= 1 && Not <= 3)
            NotText.text = "Спасибо!";
        if(Not >= 4 && Not <= 6)
            NotText.text = "Большое спасибо!";
        if(Not >= 7 && Not <= 10)
            NotText.text = "Огромное спасибо!";
        if(Not >= 11 && Not <= 15)
            NotText.text = "МЕГА спасибо!";
        if(Not >= 16)
            NotText.text = "УЛЬТРА спасибо!";

        if(Not >= 1)
            NotTextYes.text = "Помочь проекту!";

        Yes.Play();
    }
}
