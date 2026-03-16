using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationSceneChanger : MonoBehaviour
{
    public AudioSource ad1;
    private float currentVolume;
    private float maxVolume;

    public bool stop;
    public bool start;
    public Animator anim;
    public Animator webSite;

    void Start()
    {
        maxVolume = PlayerPrefs.GetFloat("audios", 0.5f);
        currentVolume = maxVolume;

        if (PlayerPrefs.GetInt("audio") == 0)
            ad1.enabled = true;
        if (PlayerPrefs.GetInt("audio") == 1)
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
            ad1.volume = currentVolume / 18f;

            if (currentVolume <= 0f)
                stop = false;
        }

        if (start)
        {
            currentVolume += 0.02f * Time.deltaTime * 60f;
            currentVolume = Mathf.Clamp(currentVolume, 0f, maxVolume);
            ad1.volume = currentVolume / 18f;

            if (currentVolume >= maxVolume)
                start = false;
        }
    }

    public void AnimNextScene()
    {
        anim.Play("bs2");
    }
    public void NextScene()
    {
        SceneManager.LoadScene("main");
    }
    public void WebSite()
    {
        webSite.Play("WebSite");
    }
    
}
