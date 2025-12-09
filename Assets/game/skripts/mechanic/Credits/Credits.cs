using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public GameObject goGet;
    public GameObject goPayOff;

    public Text CoinsGive;
    public Text CoinsSet;
    public Text CoinsPayOff;
    public Text Percent;
    public Text Status;
    public Slider GetSlider;
    public Slider PayOffSlider;
    public Text Timer;
    public AudioSource Yes;

    void Start()
    {
        if(PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            goGet.SetActive(false);
            goPayOff.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("CreditsActivee", 0) == 1 && PlayerPrefs.GetInt("CreditsTimerStatus", 0) == 2)
        {
            if(PlayerPrefs.GetInt("CreditsTimerNegtive1", 0) == 2)
            {
                if(PlayerPrefs.GetInt("CreditsTimerNegtive2", 0) == 2)
                {
                    
                }
            }
        }

        if(PlayerPrefs.GetInt("CreditsActivee", 0) == 0)
        {
            
        }
    }

    public void PayOff()
    {
        
    }
    public void Get()
    {
        
    }
}
