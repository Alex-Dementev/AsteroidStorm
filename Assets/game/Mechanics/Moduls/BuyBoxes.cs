using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyBoxes : MonoBehaviour
{
    public int Price;
    public Animator BuyPanel;
    public int Index;
    public GameObject IsBuy;
    public int IndexEnd;
    public string Name;
    private Coroutine loop;


    void OnEnable()
    {
        loop = StartCoroutine(TimerLoop());
    }

    void OnDisable()
    {
        if (loop != null)
            StopCoroutine(loop);
    }

    private IEnumerator TimerLoop()
    {
        while (true)
        {
            if(PlayerPrefs.GetInt(Index + "BuyBoxes", 0) == Index)
            {
                IsBuy.SetActive(false);
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    public void Buy()
    {
            PlayerPrefs.SetInt("IndexToBuyBox", Index);

            if(Index == 8 || Index == 6 || Index == 4 || Index == 2)
            {
                if(PlayerPrefs.GetInt("2BuyBoxes", 0) == 2 && PlayerPrefs.GetInt("4BuyBoxes", 0) == 4 && PlayerPrefs.GetInt("6BuyBoxes", 0) == 6)
                    PlayerPrefs.SetInt("PriceToBuyBox", 3085);
                else if(PlayerPrefs.GetInt("2BuyBoxes", 0) == 2 && PlayerPrefs.GetInt("4BuyBoxes", 0) == 4)
                    PlayerPrefs.SetInt("PriceToBuyBox", 1635);
                else if(PlayerPrefs.GetInt("2BuyBoxes", 0) == 2)
                    PlayerPrefs.SetInt("PriceToBuyBox", 620);
                else
                    PlayerPrefs.SetInt("PriceToBuyBox", 155);
            }
            else
                PlayerPrefs.SetInt("PriceToBuyBox", Price);

            PlayerPrefs.SetString("NameBuyBox", Name);
            BuyPanel.CrossFade("Start", 0.1f);
    }
}
