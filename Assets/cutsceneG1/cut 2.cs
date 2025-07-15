using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationSceneChanger : MonoBehaviour
{
    public AudioSource ad1;
    private float currentVolume;
    private float maxVolume;

    public bool stop;
    public bool start;

    void Start()
    {
        PlayerPrefs.SetInt("isstopmusictocutscene", 1);
        maxVolume = PlayerPrefs.GetFloat("audios", 0.5f);
        currentVolume = maxVolume;

        if (PlayerPrefs.GetInt("audio") == 0)
            ad1.enabled = true;
        else
            ad1.enabled = false;
    }

    public void ad1stop()
    {
        stop = true;
        start = false;
    }

    public void ad1start()
    {
        start = true;
        stop = false;
    }

    void Update()
    {
        if (stop && currentVolume > 0f)
        {
            currentVolume -= 0.02f * Time.deltaTime * 60f;
            currentVolume = Mathf.Clamp(currentVolume, 0f, maxVolume);
            ad1.volume = currentVolume / 50f;

            if (currentVolume <= 0f)
                stop = false;
        }

        if (start)
        {
            currentVolume += 0.02f * Time.deltaTime * 60f;
            currentVolume = Mathf.Clamp(currentVolume, 0f, maxVolume);
            ad1.volume = currentVolume / 50f;

            if (currentVolume >= maxVolume)
                start = false;
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("cutsceneG1_2");
    }
}
