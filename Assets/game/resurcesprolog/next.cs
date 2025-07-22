using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class next : MonoBehaviour
{
    public Animator anim;

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
}
