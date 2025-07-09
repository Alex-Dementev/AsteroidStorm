using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimationSceneChanger : MonoBehaviour
{
    public AudioSource ad1;


    public void Start()
    {
        if (PlayerPrefs.GetInt("audio") == 0)
        {
            ad1.enabled = true;
        }
        else if (PlayerPrefs.GetInt("audio") == 1)
        {
            ad1.enabled = false;
        }

    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene("cutsceneG1_2");
    }
}
