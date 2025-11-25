using UnityEngine;
using UnityEngine.SceneManagement;

public class AfScript : MonoBehaviour
{
    public Animator anim;

    public AudioSource ad1;
    public AudioSource ad2;

    public float audios;

    public void loadmain()
    {
        SceneManager.LoadScene("main");
    } 

    public void StartAnim()
    {
        anim.Play("bse");
    }

    void Start()
    {
        audios = PlayerPrefs.GetFloat("audios", 0.5f);
        ad1.volume = audios;
        ad2.volume = audios;

        if (PlayerPrefs.GetInt("audio") == 0)
        {
            ad1.enabled = true;
            ad2.enabled = true;
        }
        else if (PlayerPrefs.GetInt("audio") == 1)
        {
            ad1.enabled = false;
            ad2.enabled = false;
        }
    }
}
