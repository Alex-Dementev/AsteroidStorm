using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bs2 : MonoBehaviour
{
    public Text t;
    public AudioSource ad;

    void Start()
    {
        if(t != null)
        {
            if(PlayerPrefs.GetInt("fall", 0) == 1)
                t.text = "ПОРНО";
        }

        if(ad != null)
        {
            ad.volume = PlayerPrefs.GetFloat("musics", 0.5f);

            if(PlayerPrefs.GetInt("music") == 1)
                ad.enabled = false;
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("cutsceneG1_2");
    }
    public void nextScene()
    {
        SceneManager.LoadScene("final glav 1");
    }
}
