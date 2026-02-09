using UnityEngine;

public class Boom : MonoBehaviour
{
    public AudioSource ad1;
    private float audios;
    
    void Start()
    {
        audios = PlayerPrefs.GetFloat("audios", 0.5f);
        ad1.volume = audios;

        if (PlayerPrefs.GetInt("audio") == 0)
            ad1.enabled = true;
        else if(PlayerPrefs.GetInt("audio") == 1)
            ad1.enabled = false;
    }
}
