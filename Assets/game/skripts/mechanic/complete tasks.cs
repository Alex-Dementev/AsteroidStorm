using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class completetasks : MonoBehaviour
{
    public Animator anim;
    public AudioSource ad;

    void Start()
    {
        if (PlayerPrefs.GetInt("audio") == 0)
        {
            ad.enabled = true;
        }
        else if (PlayerPrefs.GetInt("audio") == 1)
        {
            ad.enabled = false;
        }
    }
    public void voidcompletetasks()
    {
        ad.Play();
        anim.Play("anim31");
    }

}
