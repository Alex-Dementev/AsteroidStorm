using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using RDG;

public class menu : MonoBehaviour
{
    public Image but;
    public Image but1;
    public Image but2;
    public Image but3;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject achp1;
    public GameObject achp2;
    public GameObject image;
    public AudioSource ad1;
    public AudioSource ad2;
    public float isdelay;
    private float isdelay1 = 1.5f;
    private float isdelay2 = 2f;
    public bool isanim1;
    public bool isanim2;
    public bool isanim3;
    public bool isanim4;
    public RocketBehavior r;
    public RocketBehavior r2;
    [SerializeField]private int coins;
    public Animator anim;
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim5;
    public Animator anim6;
    public Animator anim7;
    public Animator anim8;
    public Animator anim9;
    public Animator anim10;
    public Animator anim11;
    public Animator anim12;
    public Animator anim13;
    public Animator anim14;
    public Animator anim15;

    public ParticleSystem ps;
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;
    public ParticleSystem ps5;
    public ParticleSystem ps6;
    public ParticleSystem ps7;
    public ParticleSystem ps8;
    public ParticleSystem ps10;
    public ParticleSystem ps11;
    public ParticleSystem ps12;
    public ParticleSystem ps13;

    public bool ison;
    public bool ison1;
    public bool ison2;
    public bool ison3;
    public bool isshop;
    public bool ispref;
    public bool isachi;
    public bool isstat;
    public bool isstart = false;
    public float shop;
    public float pref;
    public float achi;
    public float ach1;
    public float ach2;
    public float stat;

    public float RR;
    public Slider S;

    



    void Start()
    {
        ach1 = PlayerPrefs.GetInt("1.5kscore", 0);
        ach2 = PlayerPrefs.GetInt("450score", 0);

        if(ach1 == 1)
        {
            achp1.SetActive(true);
        }
        if(ach2 == 1)
        {
            achp2.SetActive(true);
        }

        coins = PlayerPrefs.GetInt("coins", coins);
        ps.Stop();
        ps1.Stop();
        ps2.Stop();
        ps3.Stop();
        ps4.Stop();
        ps5.Stop();
        ps6.Stop();
        ps7.Stop();
        ps8.Stop();
        ps10.Stop();
        ps11.Stop();
        ps12.Stop();
        ps13.Stop();

        RR = PlayerPrefs.GetFloat("R Rotate Speed", 100);
        S.value = RR;

        anim5.Play("anim 2 0");
        anim6.Play("anim 18");
        anim7.Play("anim1");
        anim8.Play("anim12");
        anim9.Play("anim14");
        anim10.Play("anim3");
        anim11.Play("4t");
        anim12.Play("anim5t");
        anim13.Play("anim13");
        anim14.Play("anim 22");
    }


    void Update()
    {
        isdelay2 -= Time.deltaTime;
        isdelay1 -= Time.deltaTime;
        isdelay -= Time.deltaTime;
        achi -= Time.deltaTime;
        pref -= Time.deltaTime;
        shop -= Time.deltaTime;

        if(pref <= 0)
        {
            if(ispref == true)
            {
                ispref = false;
                panel1.SetActive(!panel1.activeSelf);
            }
        }
        if(achi <= 0)
        {
            if(isachi == true)
            {
                isachi = false;
                panel3.SetActive(!panel3.activeSelf);
            }
        }
        if(shop <= 0)
        {
            if(isshop == true)
            {
                isshop = false;
                panel2.SetActive(!panel2.activeSelf);
            }
        }
        if(stat <= 0)
        {
            if(isstat == true)
            {
                isstat = false;
                panel4.SetActive(!panel4.activeSelf);
            }
        }
        
        if(isdelay1 <= 0)
        {
            image.SetActive(!image.activeSelf);
            isdelay1 = 99999;
        }



        if (PlayerPrefs.GetInt("partic") == 0)
        {
            ison3 = true;
            but3.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
        else if(PlayerPrefs.GetInt("partic") == 1)
        {
            ison3 = false;
            but3.GetComponent<Image>().color = new Color(255, 0, 255, 255);
        }
        if (PlayerPrefs.GetInt("music") == 0)
        {
            ison = true;
            but.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else if(PlayerPrefs.GetInt("music") == 1)
        {
            ison = false;
            but.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }

        if (PlayerPrefs.GetInt("audio") == 0)
        {
            ad1.enabled = true;
            ad2.enabled = true;
            ison1 = true;
            but1.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else if(PlayerPrefs.GetInt("audio") == 1)
        {
            ad1.enabled = false;
            ad2.enabled = false;
            ison1 = false;
            but1.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }

        if (PlayerPrefs.GetInt("vibration") == 0)
        {
            ison2 = true;
            but2.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else if(PlayerPrefs.GetInt("vibration") == 1)
        {
            ison2 = false;
            but2.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }


        if(isdelay <= 0)
        {
            if(isstart == true)
            {
                isstart = false;
                SceneManager.LoadScene("scenestart");
            }
        }

        Debug.Log(RR);
        RR = S.value;
        PlayerPrefs.SetFloat("R Rotate Speed", RR);
    }



    public void ad1in()
    {
        ad1.Play();
    }

    public void ad2end()
    {
        ps.Stop();
        ps1.Stop();
        ps2.Stop();
        ps3.Stop();
        ps4.Stop();
        ps5.Stop();
        ps6.Stop();
        ps7.Stop();
        ps8.Stop();
        ps10.Stop();
        ps11.Stop();
        ps12.Stop();
        ps13.Stop();

        ad2.Play();
    }


    public void isvibration()
    {
        if (PlayerPrefs.GetInt("vibration") == 0)
        {
            Vibration.Vibrate(80, 20);
        }  
        
    }

    public void isvibration1()
    {
        if (PlayerPrefs.GetInt("vibration") == 0)
        {
            Vibration.Vibrate(80, 100);
        }  
    }

    public void isps()
    {
        ps.Play();
    }
    public void isps1()
    {
        ps1.Play();
    }
    public void isps2()
    {
        ps2.Play();
    }
    public void isps3()
    {
        ps3.Play();
    }
    public void isps4()
    {
        ps4.Play();
    }
    public void isps5()
    {
        ps5.Play();
    }
    public void isps6()
    {
        ps6.Play();
    }
    public void isps7()
    {
        ps7.Play();
    }
    public void isps8()
    {
        ps8.Play();
    }
    public void isps10()
    {
        ps10.Play();
    }
    public void isps11()
    {
        ps11.Play();
    }
    public void isps12()
    {
        ps12.Play();
    }
    public void isps13()
    {
        ps13.Play();
    }


    public void offpartic(){PlayerPrefs.SetInt("partic", ison3 ? 1 : 0);}

    public void offsound(){PlayerPrefs.SetInt("music", ison ? 1 : 0);}

    public void offaudio(){PlayerPrefs.SetInt("audio", ison1 ? 1 : 0);}

    public void offvibration(){PlayerPrefs.SetInt("vibration", ison2 ? 1 : 0);}


    public void started()
    {
        if(r.isdelayb == true)
        {  
            isdelay = 1.33f;
            isstart = true;
            image.SetActive(!image.activeSelf);
            anim.Play("anim9 0");
            anim4.Play("anim3 0");
        }

        if(r2.isdelayb == true)
        {  
            isdelay = 1.33f;
            isstart = true;
        }
    }

    public void activatepanel1()
    {
        if(isdelay2 <= 0)
        {
            if(isanim1 == false)
            {
                panel1.SetActive(!panel1.activeSelf);
                anim1.Play("anim13 0");
                anim7.Play("anim 1 0");
                isanim1 = true;
            }
            else
            {
                anim1.Play("anim13 1");
                pref = 1.1f;
                ispref = true;
                isanim1 = false;
            }

        isdelay2 = 1.2f;
        
        ad2end();
        }
    }


    public void activatepanel3()
    {
        if(isdelay2 <= 0)
        {
            if (isanim3 == false)
            {
                panel3.SetActive(!panel3.activeSelf);
                isanim3 = true;
                anim6.Play("anim 18 0");
                anim3.Play("19 0");
            }
            else
            {
                anim6.Play("anim 18 0");
                anim3.Play("19 1");
                achi = 1.1f;
                isachi = true;
                isanim3 = false;
            }

        isdelay2 = 1.2f;

        }
    }
    

    public void activatepanel2()
    {
        if(isdelay2 <= 0)
        {
            if(isanim2 == false)
            {
                panel2.SetActive(!panel2.activeSelf);
                anim2.Play("anim12 1");
                isanim2 = true;
                anim5.Play("2");
            }
            else
            {
                anim2.Play("anim12 0");
                isanim2 = false;
                shop = 1.1f;
                isshop = true;
            }
        
        isdelay2 = 1.2f;

        ad2end();
        }
    }
    

    public void activatepanel4()
    {
        if (isdelay2 <= 0)
        {
            if (isanim4 == false)
            {
                panel4.SetActive(!panel4.activeSelf);
                anim14.Play("anim 22 0");
                isanim4 = true;
                anim15.Play("anim 23");
            }
            else
            {
                anim15.Play("anim 23");
                anim14.Play("anim 22 0");
                isanim4 = false;
                stat = 1.1f;
                isstat = true;
            }

            isdelay2 = 1.2f;

            ad2end();
        }
    }
}
