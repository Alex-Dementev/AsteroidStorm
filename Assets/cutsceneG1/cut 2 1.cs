using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cutsceneg2 : MonoBehaviour
{
    public AudioSource ad;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void isclick()
    {
        anim.Play("end");
    }
    public void nextScene()
    {
        SceneManager.LoadScene("main");
    }
    public void humanoid()
    {
        ad.Play();
    }
    
}
