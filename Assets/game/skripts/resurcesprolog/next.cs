using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class next : MonoBehaviour
{
    public AudioSource ad;
    public Animator anim;


    public void nextscene()
    {
        if(PlayerPrefs.GetInt("isfinal", 0) == 0)
            PlayerPrefs.SetInt("FirstEnjoy", 1);
        else
            PlayerPrefs.SetInt("FirstEnjoy", 2);

        SceneManager.LoadScene("logos");
    }
    public void nextscenes()
    {
        if(PlayerPrefs.GetInt("3GlavStarted", 0) == 1 && PlayerPrefs.GetInt("isfinal", 0) == 0)
            SceneManager.LoadScene("3GlavStart");
        else
            SceneManager.LoadScene("main");
    }
    public void nextscenep()
    {
        if(PlayerPrefs.GetInt("isfinal", 0) == 0)
        {
            if(PlayerPrefs.GetInt("FirstEnjoy", 0) == 0)
                return;
        }
        else
        {
            if(PlayerPrefs.GetInt("FirstEnjoy", 0) <= 1)
                return;
        }
        anim.Play("nextp");
    }
    public void nextscenesed()
    {
        anim.Play("nexts");
    }
    public void sound()
    {
        ad.Play();
    }
}
