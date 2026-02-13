using UnityEngine;
using UnityEngine.UI;

public class ShakeToCoins : MonoBehaviour
{
    private int Coins;
    public Text CoinsText;
    public Slider ShakeSlider;
    private float Shake;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Coins = PlayerPrefs.GetInt("ShakeCoins", 0);
        CoinsText.text = "" + Coins;
        ShakeSlider.value = Shake;

        if(PlayerPrefs.GetInt("ShakePhone", 0) == 1)
        {
            Shake += Time.deltaTime;
        }

        if(Shake >= 4)
        {
            Shake = 0;
            Coins++;
            PlayerPrefs.SetInt("ShakeCoins", Coins);
        }
    }

    public void GetCoins()
    {
        int AllCoins = PlayerPrefs.GetInt("coins", 0);
        AllCoins += Coins;
        PlayerPrefs.SetInt("coins", AllCoins);
        AllCoins = PlayerPrefs.GetInt("allcoins", 0);
        AllCoins += Coins;
        PlayerPrefs.SetInt("allcoins", AllCoins);
        PlayerPrefs.SetInt("ShakeCoins", 0);
    }
}
