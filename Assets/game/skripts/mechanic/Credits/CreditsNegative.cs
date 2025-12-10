using UnityEngine;

public class CreditsNegative : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("CreditsTimerStatus") == 2)
        {
            PlayerPrefs.SetInt("CreditsTimerNegtive1", 1);
            PlayerPrefs.SetInt("CreditsTimerStatus", 0);
            PlayerPrefs.SetInt("CreditsTrables", 1);
        }
        if(PlayerPrefs.GetInt("CreditsTimerNegtive1") == 2)
        {
            PlayerPrefs.SetInt("CreditsTimerNegtive2", 1);
            PlayerPrefs.SetInt("CreditsTimerNegtive1", 0);
            PlayerPrefs.SetInt("CreditsTrables", 2);
        }
        if(PlayerPrefs.GetInt("CreditsTimerNegtive2") == 2)
        {
            PlayerPrefs.SetInt("CreditsTimerNegtive2", 1);
            PlayerPrefs.SetInt("CreditsTrables", 3);
        }
    }
}
