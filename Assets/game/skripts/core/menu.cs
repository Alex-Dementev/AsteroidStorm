using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using RDG;
using System.Net.Mail;

public class menu : MonoBehaviour
{
    public Text n1;
    public Text n2;
    public Text n3;
    public Text n4;
    public Text d1;
    public Text d2;
    public Text d3;
    public Text d4;
    private int one;
    public int prefs;
    public bool isprolog;
    public bool rocketfall;
    public bool Bbackstarted;
    public float Dbackstarted;
    public Image but;
    public Image but1;
    public Image but2;
    public Image but3;
    public Image controller;
    public Image controller2;
    public GameObject butfall;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    public GameObject panel8;
    public GameObject panelCustomizate;
    public GameObject achp1;
    public GameObject achp2;
    public GameObject image;
    public AudioSource ad1;
    public AudioSource ad2;
    public AudioSource ad3;
    public AudioSource ad4;
    public AudioSource ad5;
    public AudioSource ad6;
    public AudioSource ad7;
    public float isdelay;
    private float isdelay1 = 1.5f;
    private float isdelay2 = 0.85f;
    private float isdelay5;
    public bool isanim1;
    public bool isanim2;
    public bool isanim3;
    public bool isanim4;
    public bool isanim5;
    public bool isanim6;
    public bool isanim7;
    public Animator header;
    public RocketBehavior r;
    public RocketBehavior r2;
    [SerializeField]private int coins;
    public Animator anim;
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim5;
    public Animator anim6;
    public Animator anim7;
    public Animator anim8;
    public Animator anim9;
    public Animator anim11;
    public Animator anim12;
    public Animator anim13;
    public Animator anim14;
    public Animator anim15;
    public Animator anim16;
    public Animator anim17;
    public Animator anim18;
    public Animator anim19;
    public Animator anim20;
    public Animator anim21;
    public Animator skins;
    public Animator skinspanel;
    public Animator components;
    public Animator componentsp;

    public ParticleSystem ps;
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;
    public ParticleSystem ps5;
    public ParticleSystem ps6;
    public ParticleSystem ps7;
    public ParticleSystem ps8;
    public ParticleSystem ps11;
    public ParticleSystem ps12;
    public ParticleSystem ps13;
    public ParticleSystem ps14;
    public ParticleSystem ps15;
    public ParticleSystem ps16;
    public ParticleSystem ps17;
    public ParticleSystem ps18;
    public ParticleSystem ps19;
    public ParticleSystem ps20;
    public ParticleSystem ps21;
    public ParticleSystem ps22;
    public ParticleSystem ps23;
    public ParticleSystem ps24;
    public ParticleSystem ps25;
    public ParticleSystem ps26;
    public ParticleSystem ps27;
    public ParticleSystem ps31;
    public ParticleSystem ps32;
    public ParticleSystem ps33;
    public ParticleSystem ps34;
    public ParticleSystem ps35;
    public ParticleSystem ps36;
    public ParticleSystem ps37;
    public ParticleSystem ps38;
    public ParticleSystem ps39;
    public ParticleSystem ps40;
    public ParticleSystem ps41;
    public ParticleSystem ps42;

    public ParticleSystem rocketstart1;
    public ParticleSystem rocketstart2;
    public ParticleSystem rocketstart3;
    public ParticleSystem rocketstart4;

    public bool ison;
    public bool ison1;
    public bool ison2;
    public bool ison3;
    public bool isCustomPanel;
    public bool isshop;
    public bool ispref;
    public bool isachi;
    public bool isstat;
    public bool istask;
    public bool isstart = false;
    public float shop;
    public float pref;
    public float achi;
    public float task;
    public float ach1;
    public float ach2;
    public float stat;
    public float compopf;
    public int allgames;
    public bool is7;
    public int is11;
    public int is12;
    public int maxcoins;
    public float customFloatPanel;

    public float RR;
    public int Vp;
    public Slider S;
    public Slider Sm;
    public Slider Sa;
    public Slider Sp;
    public float musics;
    public float audios;
    public bool is6;
    public Text logo;
    public Text t1;
    public Text t2;
    public Text t3;
    public Text t4;
    public Text t5;
    public bool isfall;
    public GameObject surwive;
    public int intsurwive;
    public bool isbsurwive;
    public bool isCloseCustomPanel;





    void Start()
    {   
        PlayerPrefs.GetFloat("isstartmusic", 1f);
        PlayerPrefs.SetInt("isstopmusictocutscene", 0);
        audios = PlayerPrefs.GetFloat("audios", 0.5f);
        musics = PlayerPrefs.GetFloat("musics", 0.5f);
        ach1 = PlayerPrefs.GetInt("1.5kscore", 0);
        ach2 = PlayerPrefs.GetInt("450score", 0);
        is11 = PlayerPrefs.GetInt("tis11", 0);
        is12 = PlayerPrefs.GetInt("tis12", 0);
        PlayerPrefs.SetInt("isfinal1g", 0);
        PlayerPrefs.SetInt("youcheat", 1);
        PlayerPrefs.SetInt("youdead", 0);


        if(PlayerPrefs.GetInt("fall") == 1)
        rocketfall = true;

        Sm.value = musics;
        Sa.value = audios;
        ad1.volume = audios / 2;
        ad2.volume = audios / 2;
        ad3.volume = audios / 2.5f;
        ad4.volume = audios / 1.2f;
        ad5.volume = audios / 1.2f;
        ad6.volume = audios;
        ad7.volume = audios;


        if (is11 == 0)
        {
            controller.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
        else
        {
            controller.GetComponent<Image>().color = new Color(0, 255, 0, 255);
        }
        if (is12 == 0)
        {
            controller2.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
        else
        {
            controller2.GetComponent<Image>().color = new Color(0, 255, 0, 255);
        }

        if (ach1 == 1)
        {
            achp1.SetActive(true);
        }
        if(ach2 == 1)
        {
            achp2.SetActive(true);
        }

        ps.Stop();
        ps1.Stop();
        ps2.Stop();
        ps3.Stop();
        ps4.Stop();
        ps5.Stop();
        ps6.Stop();
        ps7.Stop();
        ps8.Stop();
        ps11.Stop();
        ps12.Stop();
        ps13.Stop();
        ps14.Stop();
        ps15.Stop();
        ps16.Stop();
        ps17.Stop();
        ps18.Stop();
        ps19.Stop();
        ps20.Stop();
        ps21.Stop();
        ps22.Stop();
        ps23.Stop();
        ps24.Stop();
        ps25.Stop();
        ps26.Stop();
        ps27.Stop();
        ps31.Stop();
        ps32.Stop();
        ps33.Stop();
        ps34.Stop();
        ps35.Stop();

        if(!rocketfall)
        {
        RR = PlayerPrefs.GetFloat("R Rotate Speed", 100);
        S.value = RR;
        }
        else
        {
            RR = 1000;
            PlayerPrefs.SetFloat("R Rotate Speed", 1000);
        }

        Vp = PlayerPrefs.GetInt("maxParticles", 30);
        Sp.value = Vp;

        if(PlayerPrefs.GetInt("yousurwive", 0) == 1)
        {
            intsurwive = 100;
            ps35.Stop();
        }

        anim5.Play("anim 2 0");
        anim6.Play("anim 18");
        anim7.Play("anim1");
        anim8.Play("anim12");
        anim9.Play("anim14");
        anim11.Play("4t");
        anim12.Play("anim5t");
        anim13.Play("anim13");
        anim14.Play("anim 22");
        anim16.Play("anim 24");
        anim17.Play("anim 26");
        anim18.Play("audio 0");
        anim19.Play("anim30");
        header.Play("header");
        components.Play("componstart");
    }


    void Update()
    {
        isdelay2 -= Time.deltaTime;
        isdelay1 -= Time.deltaTime;
        isdelay -= Time.deltaTime;
        achi -= Time.deltaTime;
        pref -= Time.deltaTime;
        shop -= Time.deltaTime;
        stat -= Time.deltaTime;
        task -= Time.deltaTime;
        isdelay5 -= Time.deltaTime;
        Dbackstarted -= Time.deltaTime;
        compopf -= Time.deltaTime;
        customFloatPanel -= Time.deltaTime;



        musics = Sm.value;
        audios = Sa.value;
        PlayerPrefs.SetFloat("musics", musics);
        PlayerPrefs.SetFloat("audios", audios);
        ad1.volume = audios;
        ad2.volume = audios;
        ad3.volume = audios / 18;
        ad4.volume = audios;
        ad5.volume = audios;
        ad6.volume = audios;
        ad7.volume = audios;

        if(rocketfall && !isfall)
        {
            isfall = true;
            logo.text = "ШОК Контент!";
            t1.text = "Чёрный рынок";
            t2.text = "Список твоих понтов";
            t3.text = "График страданий";
            t4.text = "Сделай или забудь";
            t5.text = "Говно, но моё";
            n1.text = "SUS-1";
            n2.text = "Ёлки-Палки 3000";
            n3.text = "Лунный Порношутер";
            n4.text = "Обычная Ракета";
            d1.text = "Её выгнали за импостерство, и теперь она просто летает по космосу, подозревая всех вокруг.";
            d2.text = "Нового года не будет, Дед Мороз принял… обернись.";
            d3.text = "Иногда путает Луну с гиганским порно-партнёром и думает, что астероиды — это просто реквизит для свиданий.";
            d4.text = "Эта ракета слишком обычная, чтобы быть необычной, и слишком необычная, чтобы быть скучной… поэтому она просто обычная.";
            
            butfall.SetActive(true);
            PlayerPrefs.SetInt("fall", 1);
        }


        Vp = (int)Sp.value;
        PlayerPrefs.SetInt("maxParticles", Vp);

        if(compopf <= 0)
        {
            if(is7 == true)
            {
                is7 = false;
                panel8.SetActive(!panel8.activeSelf);
            }
        }
        if(customFloatPanel <= 0 && isCloseCustomPanel == true)
        {
            isCloseCustomPanel = false;
            panelCustomizate.SetActive(!panelCustomizate.activeSelf);
        }
        if (pref <= 0)
        {
            if (ispref == true)
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
        if(task <= 0)
        {
            if(istask == true)
            {
                istask = false;
                panel5.SetActive(!panel5.activeSelf);
            }
        }
        if(Dbackstarted <= 0 && Bbackstarted)
        {
            panel7.SetActive(!panel7.activeSelf);
            Bbackstarted = false;
        }

        if(isdelay1 <= 0)
        {
            image.SetActive(!image.activeSelf);
            isdelay1 = 99999;
        }

        if(isdelay5 <= 0 && is6 == true)
        {
            is6 = false;
            panel6.SetActive(!panel6.activeSelf);
        }

        if(intsurwive >= 100 && !isbsurwive)
        {
            PlayerPrefs.SetInt("yousurwive", 1);
            isbsurwive = true;
            surwive.SetActive(true);
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
            ad3.enabled = true;
            ison1 = true;
            but1.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else if(PlayerPrefs.GetInt("audio") == 1)
        {
            ad1.enabled = false;
            ad2.enabled = false;
            ad3.enabled = false;
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
            if(isprolog == true)
            {
                isprolog = false;
                SceneManager.LoadScene("scenetoproblem");
            }
        }


        if(!rocketfall)
        {
        RR = S.value;
        PlayerPrefs.SetFloat("R Rotate Speed", RR);
        }
        else
        {
            RR = 1000;
            PlayerPrefs.SetFloat("R Rotate Speed", 1000);
        }
    }



    public void ad1in()
    {
        if(!rocketfall)
        ad1.Play();
        else
        ad6.Play();
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
        ps11.Stop();
        ps12.Stop();
        ps13.Stop();
        ps14.Stop();
        ps15.Stop();
        ps16.Stop();
        ps17.Stop();
        ps18.Stop();
        ps19.Stop();
        ps20.Stop();
        ps21.Stop();
        ps22.Stop();
        ps23.Stop();
        ps24.Stop();
        ps25.Stop();
        ps26.Stop();
        ps27.Stop();
        ps31.Stop();
        ps32.Stop();
        ps33.Stop();
        ps34.Stop();
        ps35.Stop();
        ps36.Stop();
        ps37.Stop();
        ps38.Stop();
        ps39.Stop();
        ps40.Stop();
        ps41.Stop();
        ps42.Stop();

        if(!rocketfall)
        ad2.Play();
        else
        ad7.Play();

    }

    public void voidclosesurwive()
    {
        surwive.SetActive(false);
        intsurwive = 0;
        isbsurwive = false;
        PlayerPrefs.SetInt("yousurwive", 0);
        ps35.Stop();
    }
    public void voidintclosesurwive()
    {
        intsurwive++;
    }

    public void isclocefall()
    {
        rocketfall = false;
        isfall = false;
        logo.text = "Астероидный Шторм";
        butfall.SetActive(false);
        PlayerPrefs.SetInt("fall", 0);
        t1.text = "Магазин";
        t2.text = "Достижения";
        t3.text = "Статистика";
        t4.text = "Задания";
        t5.text = "Кастомизация";
        n1.text = "SUS";
        n2.text = "Ёлки-Палки";
        n3.text = "Лунолет";
        n4.text = "Ракета";
        d1.text = "Постоянно подозревает все астероиды в саботаже, а её главный двигатель работает на чистом «эх, импостор, ну ты и…». Красная, быстрая и всегда готова нажать на кнопку. просто сделай чтоб было норм";
        d2.text = "Эта ракета — как новогоднее чудо: горит, летит и иногда взрывается так, что Санта нервно курит в сторонке. Игрушки держатся на честном слове, гирлянда питается от ядерного реактора, а запах хвои — это, возможно, дым.";
        d3.text = "Долетел до Луны, плюнул в кратер и вернулся. Теперь уверен, что Земля круглая, а сыр всё-таки твёрдый.";
        d4.text = "Обычная ракета для необычных ситуаций. Летит прямо… пока не решит, что прямо — это в стену.";
        
    }


    public void isclickget()
    {
        if (is11 == 0 && ach1 == 1)
        {
            is11 = 1;
            PlayerPrefs.SetInt("tis11", 1);
            PlayerPrefs.SetInt("Skin3", 1);
            controller.GetComponent<Image>().color = new Color(0, 255, 0, 255);
        }

        if (is12 == 0 && ach2 == 1)
        {
            is12 = 1;
            PlayerPrefs.SetInt("tis12", 1);
            controller2.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            coins = PlayerPrefs.GetInt("coins", 0);
            coins += 500;
            PlayerPrefs.SetInt("coins", coins);
            maxcoins = PlayerPrefs.GetInt("allcoins", 0);
            maxcoins += 500;
            PlayerPrefs.SetInt("allcoins", maxcoins);
            
        }
    }


    public void startedrocketps()
{
    var m1 = rocketstart1.main; m1.startLifetime = 14f; m1.simulationSpeed = 30f;
    var m2 = rocketstart2.main; m2.startLifetime = 14f; m2.simulationSpeed = 30f;
    var m3 = rocketstart3.main; m3.startLifetime = 14f; m3.simulationSpeed = 30f;
    var m4 = rocketstart4.main; m4.startLifetime = 14f; m4.simulationSpeed = 30f;
}

public void destartedrocketps()
{
    var m1 = rocketstart1.main; m1.startLifetime = 7f; m1.simulationSpeed = 20f;
    var m2 = rocketstart2.main; m2.startLifetime = 7f; m2.simulationSpeed = 20f;
    var m3 = rocketstart3.main; m3.startLifetime = 7f; m3.simulationSpeed = 20f;
    var m4 = rocketstart4.main; m4.startLifetime = 7f; m4.simulationSpeed = 20f;
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
    public void isps14()
    {
        ps14.Play();
    }
    public void isps15()
    {
        ps15.Play();
        ps16.Play();
        ps17.Play();
        ps18.Play();
        ps19.Play();
        ps40.Play();
    }
    public void isps16()
    {
        ps20.Play();
        ps21.Play();
        ps22.Play();
        ps23.Play();
        ps24.Play();
        ps41.Play();
    }
    public void isps17()
    {
        ps25.Play();
        ps26.Play();
        ps27.Play();
        ps42.Play();
    }
    public void isps18()
    {
        ps36.Play();
        ps37.Play();
        ps38.Play();
        ps39.Play();
    }
    public void isps19()
    {
        ps31.Play();
    }
    public void isps20()
    {
        ps32.Play();
    }
    public void isps21()
    {
        ps33.Play();
    }
    public void isps22()
    {
        ps34.Play();
    }
    public void isps23()
    {
        ps35.Play();
    }


    public void ViewProlog()
    {
        isdelay = 1.33f;
        isprolog = true;
        image.SetActive(true);
        anim.Play("anim9 0");
    }



    public void offsound(){PlayerPrefs.SetInt("music", ison ? 1 : 0);}

    public void offaudio(){PlayerPrefs.SetInt("audio", ison1 ? 1 : 0);}

    public void offvibration(){PlayerPrefs.SetInt("vibration", ison2 ? 1 : 0);}


    public void started()
    {
        if(isdelay2 <= 2)
        {
        panel7.SetActive(!panel7.activeSelf);
        anim21.Play("anim 32");
        isdelay2 = 3.4f;
        }
    }
    public void backstarted()
    {
        if(isdelay2 <= 2)
        {
        anim21.Play("anim 32 1");
        Dbackstarted = 0.8f;
        Bbackstarted = true;
        isdelay2 = 0.85f;
        }
    }
    public void is1g()
    {
        if (r.isdelayb == true)
        {
            isdelay = 1.33f;
            isstart = true;
            image.SetActive(!image.activeSelf);
            anim.Play("anim9 0");
            allgames = PlayerPrefs.GetInt("allgames", 0);
            allgames++;
            PlayerPrefs.SetInt("allgames", allgames);
        }

        if(r2.isdelayb == true)
        {  
            isdelay = 1.33f;
            isstart = true;
        }
    }
    public void is2g()
    {
        
    }
    public void is3g()
    {
        
    }
    public void is4g()
    {

    }

    public void activatepanel1()
    {
        prefs++;
        if(prefs >= 4 && rocketfall == false)
        rocketfall = true;

        if(isdelay2 <= 0)
        {
            if (isanim1 == false)
            {
                panel1.SetActive(!panel1.activeSelf);
                anim1.Play("anim13 0");
                anim7.Play("anim 1 0");
                isanim1 = true;
                prefs = 0;
            }
            else
            {
                anim1.Play("anim13 1");
                pref = 1.1f;
                ispref = true;
                isanim1 = false;
                prefs = 0;
            }

        isdelay2 = 1f;
        
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

        isdelay2 = 0.85f;
        ad2end();

        }
    }

    public void activatepanel23()
    {
        if (isdelay2 <= 0)
        {
            if (isanim2 == false)
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
            ad2end();
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel24()
    {
        if (isdelay2 <= 0)
        {
            if (isanim2 == false)
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
            if (isanim4 == false)
            {
                panel4.SetActive(!panel4.activeSelf);
                anim14.Play("anim 22 0");
                isanim4 = true;
                anim15.Play("anim 23");
            }
            else
            {
                anim15.Play("anim 23 0");
                anim14.Play("anim 22 0");
                isanim4 = false;
                stat = 1.1f;
                isstat = true;
            }
            ad2end();
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel54()
    {
        if (isdelay2 <= 0)
        {
        if (isanim5 == false)
        {
            panel5.SetActive(!panel5.activeSelf);
            anim16.Play("anim 24 1");
            isanim5 = true;
            anim17.Play("anim 25");
        }
        else
        {
            anim17.Play("anim 25 0");
            anim16.Play("anim 24 1");
            isanim5 = false;
            task = 1.1f;
            istask = true;
        }
        if (isanim4 == false)
        {
            panel4.SetActive(!panel4.activeSelf);
            anim14.Play("anim 22 0");
            isanim4 = true;
            anim15.Play("anim 23");
        }
        else
        {
            anim15.Play("anim 23 0");
            anim14.Play("anim 22 0");
            isanim4 = false;
            stat = 1.1f;
            isstat = true;
        }
ad2end();
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel34()
    {
        if (isdelay2 <= 0)
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
            if (isanim4 == false)
            {
                panel4.SetActive(!panel4.activeSelf);
                anim14.Play("anim 22 0");
                isanim4 = true;
                anim15.Play("anim 23");
            }
            else
            {
                anim15.Play("anim 23 0");
                anim14.Play("anim 22 0");
                isanim4 = false;
                stat = 1.1f;
                isstat = true;
            }
            ad2end();
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel25()
    {
        if (isdelay2 <= 0)
        {
            if (isanim2 == false)
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
            if (isanim5 == false)
            {
                panel5.SetActive(!panel5.activeSelf);
                anim16.Play("anim 24 1");
                isanim5 = true;
                anim17.Play("anim 25");
            }
            else
            {
                anim17.Play("anim 25 0");
                anim16.Play("anim 24 1");
                isanim5 = false;
                task = 1.1f;
                istask = true;
            }
            ad2end();
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel28()
    {
        if (isdelay2 <= 0)
        {
            if (isanim2 == false)
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
            if (isanim7 == false)
            {
                panel8.SetActive(!panel8.activeSelf);
                componentsp.Play("componentsp");
                components.Play("componclick");
                isanim7 = true;
                isdelay2 = 2;
            }
            else if(isdelay2 <= 0)
            {
                componentsp.Play("componentsp1");
                isanim7 = false;
                compopf = 1;
                is7 = true;
            }
            ad2end();
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel29()
    {
        if (isdelay2 <= 0)
        {
            if (isanim2 == false)
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
            if (isCustomPanel == false)
            {
                panelCustomizate.SetActive(!panelCustomizate.activeSelf);
                skins.Play("anim 17 0");
                skinspanel.Play("customization");
                isCustomPanel = true;
                isdelay2 = 2;
            }
            else if(isdelay2 <= 0)
            {
                skinspanel.Play("customization 0");
                isCustomPanel = false;
                customFloatPanel = 1;
                isCloseCustomPanel = true;
            }
            ad2end();
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel35()
    {
        if (isdelay2 <= 0)
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
            if (isanim5 == false)
            {
                panel5.SetActive(!panel5.activeSelf);
                anim16.Play("anim 24 1");
                isanim5 = true;
                anim17.Play("anim 25");
            }
            else
            {
                anim17.Play("anim 25 0");
                anim16.Play("anim 24 1");
                isanim5 = false;
                task = 1.1f;
                istask = true;
            }
            ad2end();
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel85()
    {
        if (isdelay2 <= 0)
        {
            if (isanim7 == false)
            {
                panel8.SetActive(!panel8.activeSelf);
                componentsp.Play("componentsp");
                components.Play("componclick");
                isanim7 = true;
                isdelay2 = 2;
            }
            else if(isdelay2 <= 0)
            {
                componentsp.Play("componentsp1");
                isanim7 = false;
                compopf = 1;
                is7 = true;
            }
            if (isanim5 == false)
            {
                panel5.SetActive(!panel5.activeSelf);
                anim16.Play("anim 24 1");
                isanim5 = true;
                anim17.Play("anim 25");
            }
            else
            {
                anim17.Play("anim 25 0");
                anim16.Play("anim 24 1");
                isanim5 = false;
                task = 1.1f;
                istask = true;
            }
            ad2end();
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel89()
    {
        if (isdelay2 <= 0)
        {
            if (isCustomPanel == false)
            {
                panelCustomizate.SetActive(!panelCustomizate.activeSelf);
                skins.Play("anim 17 0");
                skinspanel.Play("customization");
                isCustomPanel = true;
                isdelay2 = 2;
            }
            else if(isdelay2 <= 0)
            {
                skinspanel.Play("customization 0");
                isCustomPanel = false;
                customFloatPanel = 1;
                isCloseCustomPanel = true;
            }
            if (isanim7 == false)
            {
                panel8.SetActive(!panel8.activeSelf);
                isanim7 = true;
                isdelay2 = 2;
                componentsp.Play("componentsp");
                components.Play("componclick");
            }
            else if (isanim7 == true)
            {
                isanim7 = false;
                compopf = 1;
                is7 = true;
                componentsp.Play("componentsp1");
            }
            ad2end();
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel95()
    {
        if (isdelay2 <= 0)
        {
            if (isCustomPanel == false)
            {
                panelCustomizate.SetActive(!panelCustomizate.activeSelf);
                skins.Play("anim 17 0");
                skinspanel.Play("customization");
                isCustomPanel = true;
                isdelay2 = 2;
            }
            else if(isdelay2 <= 0)
            {
                skinspanel.Play("customization 0");
                isCustomPanel = false;
                customFloatPanel = 1;
                isCloseCustomPanel = true;
            }
            if (isanim5 == false)
            {
                panel5.SetActive(!panel5.activeSelf);
                anim16.Play("anim 24 1");
                isanim5 = true;
                anim17.Play("anim 25");
            }
            else
            {
                anim17.Play("anim 25 0");
                anim16.Play("anim 24 1");
                isanim5 = false;
                task = 1.1f;
                istask = true;
            }
            ad2end();
            isdelay2 = 0.85f;
        }
    }
    

    public void activatepanel2()
    {
        one++;
        if(one >= 5)
        activatepanel6();

        if (isdelay2 <= 0)
        {
            if (isanim2 == false)
            {
                panel2.SetActive(!panel2.activeSelf);
                anim2.Play("anim12 1");
                isanim2 = true;
                anim5.Play("2");
                one = 0;
            }
            else
            {
                anim2.Play("anim12 0");
                isanim2 = false;
                shop = 1.1f;
                isshop = true;
                one = 0;
            }

            isdelay2 = 0.85f;

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
                anim15.Play("anim 23 0");
                anim14.Play("anim 22 0");
                isanim4 = false;
                stat = 1.1f;
                isstat = true;
            }

            isdelay2 = 0.85f;

            ad2end();
        }
    }


    public void activatepanel5()
    {
        if (isdelay2 <= 0)
        {
            if (isanim5 == false)
            {
                panel5.SetActive(!panel5.activeSelf);
                anim16.Play("anim 24 1");
                isanim5 = true;
                anim17.Play("anim 25");
            }
            else
            {
                anim17.Play("anim 25 0");
                anim16.Play("anim 24 1");
                isanim5 = false;
                task = 1.1f;
                istask = true;
            }

            isdelay2 = 0.85f;

            ad2end();
        }
    }
    public void activatepanel6()
    {
        one = 0;
            if (isanim6 == false)
            {
                panel6.SetActive(!panel6.activeSelf);
                anim20.Play("anim 45 1");
                isanim6 = true;
                isdelay2 = 2;
            }
            else if(isdelay2 <= 0)
            {
                anim20.Play("anim 45 0");
                isanim6 = false;
                isdelay5 = 1;
                is6 = true;
            }

            ad2end();
    }
    public void activatepanel8()
    {
            if (isanim7 == false)
            {
                panel8.SetActive(!panel8.activeSelf);
                componentsp.Play("componentsp");
                components.Play("componclick");
                isanim7 = true;
                isdelay2 = 2;
            }
            else if(isdelay2 <= 0)
            {
                componentsp.Play("componentsp1");
                isanim7 = false;
                compopf = 1;
                is7 = true;
            }

            ad2end();
    }
    public void activateCustomizatePanel()
    {
            if (isCustomPanel == false)
            {
                panelCustomizate.SetActive(!panelCustomizate.activeSelf);
                skins.Play("anim 17 0");
                skinspanel.Play("customization");
                isCustomPanel = true;
                isdelay2 = 1;
            }
            else if(isdelay2 <= 0)
            {
                skinspanel.Play("customization 0");
                isCustomPanel = false;
                customFloatPanel = 1;
                isCloseCustomPanel = true;
            }

            ad2end();
    }
}
