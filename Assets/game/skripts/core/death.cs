using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RDG;

public class death : MonoBehaviour
{
    [SerializeField] public GameObject losePanel;
    [SerializeField] public Transform player;
    public int coins;
    public bool b;
    public DoubleTapHandler d;
    private float isdelay = 9999999;
    public Animator anim;
    public Animator anim1;
    public GameObject image;
    public AudioSource ad;
    private float f = 9999999;
    private float isdelay1 = 2;
    private float isdelay2 = 9999999;
    public ParticleSystem ps;


    void Start()
    {
        b = false;
        isdelay = 9999999;
    }

    // Update is called once per frame
    void Update()
    {
        isdelay -= Time.deltaTime;
        f -= Time.deltaTime;
        isdelay1 -= Time.deltaTime;
        isdelay2 -= Time.deltaTime;

        if(isdelay <= 0)
        {
            isdelay = 99999999;
            SceneManager.LoadScene("main");
        }

        if(b == true)
        {
            if(f <= 0)
            {
                restart();
                f = 9999999;
            }
        }

        if(isdelay1 >= 0)
        {
            ps.Stop();
        }
        if(isdelay2 <= 0)
        {
            isdelay1 = 1;
        }
    }

    public void restart()
    {
        image.SetActive(!image.activeSelf);
        anim.Play("anim10 0");
        isdelay = 1.2f;
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if(Collision.gameObject.CompareTag("obstacle"))
        {
            if(b == false)
            {
                if(d.b == false)
                {
                    losePanel.SetActive(true);
                    anim1.Play("anim11");
                    coins = PlayerPrefs.GetInt("coins");
                    coins += ((int)(player.position.z / 10));
                    PlayerPrefs.SetInt("coins", coins); 
                    if (PlayerPrefs.GetInt("vibration") == 0)
                    {
                        Vibration.Vibrate(80, 100);
                    }  
                    ad.Play();
                    b = true;
                    f = 7;
                    ps.Play();
                    isdelay2 = 2;
                }
                else if(d.b == true)
                {
                    Debug.Log("вау еееееее");
                }
            }
        }
    }
}
