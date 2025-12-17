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
            PlayerPrefs.SetInt("PriceToBuyBox", Price);
            PlayerPrefs.SetString("NameBuyBox", Name);
            BuyPanel.Play("Start");
    }
}
