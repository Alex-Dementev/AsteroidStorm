using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class next : MonoBehaviour
{
    public AudioSource ad;
    public Animator anim;


    private void Start() 
    {
        if(PlayerPrefs.GetInt("prolog") == 1)
        SceneManager.LoadScene("logos");
    }


    public void nextscene()
    {
        SceneManager.LoadScene("logos");
    }
    public void nextscenes()
    {
        SceneManager.LoadScene("main");
    }
    public void nextscenep()
    {
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
