using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using RDG;
using System.Net.Mail;
using JetBrains.Annotations;

public class menu : MonoBehaviour
{
    public Animator lombard;
    public Text n1;
    public Text n2;
    public Text n3;
    public Text n4;
    public Text d1;
    public Text d2;
    public Text d3;
    public Text d4;
    public float sliderlightfloat;
    public Slider lightgameplay;
    private int one;
    public int prefs;
    public bool rocketfall;
    public Image but;
    public Image but1;
    public Image but2;
    public Image but3;
    public Image controller;
    public Image controller2;
    public Image controller3;
    public Image controller4;
    public Image controller5;
    public GameObject butfall;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    public GameObject panel8;
    public GameObject panelCustomizate;
    public GameObject panelLom;
    public GameObject panelBank;
    public GameObject image;
    public AudioSource ad1;
    public AudioSource ad2;
    public AudioSource ad3;
    public AudioSource ad4;
    public AudioSource ad5;
    public AudioSource ad6;
    public AudioSource ad7;
    public AudioSource ad8;
    public AudioSource ad9;
    public AudioSource SMS;
    public AudioSource yesad;
    public AudioSource noad;
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
    public bool isBankPanel;
    public bool isLomPanel;
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
    public Animator lompanel;
    public Animator Bank;
    public Animator bankpanel;

    public ParticleSystem ps16;
    public ParticleSystem ps17;
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
    public ParticleSystem ps34;
    public ParticleSystem ps35;
    public ParticleSystem ps36;
    public ParticleSystem ps37;
    public ParticleSystem ps38;
    public ParticleSystem ps39;
    public ParticleSystem ps40;
    public ParticleSystem ps41;
    public ParticleSystem ps42;
    public ParticleSystem ps43;
    public ParticleSystem ps44;
    public ParticleSystem ps45;
    public ParticleSystem ps46;
    public ParticleSystem ps47;
    public ParticleSystem ps48;
    public ParticleSystem ps49;
    public ParticleSystem ps50;
    public ParticleSystem ps51;
    public ParticleSystem ps52;
    public ParticleSystem ps53;
    public ParticleSystem ps54;
    public ParticleSystem ps55;
    public ParticleSystem ps56;
    public ParticleSystem ps57;
    public ParticleSystem ps58;
    public ParticleSystem ps59;

    public ParticleSystem rocketstart1;
    public ParticleSystem rocketstart2;
    public ParticleSystem rocketstart3;
    public ParticleSystem rocketstart4;

    public bool ison;
    public bool ison1;
    public bool ison2;
    public bool ison3;
    public bool isCustomPanel;
    public int allgames;
    public int is11;
    public int is12;
    public int is13;
    public int is14;
    public int is15;
    public int maxcoins;
    public int allgamesPermanentTask;

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
    public Text logo2;
    public Text logo3;
    public Text logo4;
    public Text t1;
    public Text t3;
    public Text t4;
    public Text t5;
    public Text PashalTextError1;
    public Text PashalTextError2;
    public Text PashalTextError3;
    public bool isfall;
    public GameObject surwive;
    public int intsurwive;
    public bool isbsurwive;
    public Animator Dificite;
    private float Dificitefloat;

    public GameObject DialogueStart;

    public RocketBehavior move1;
    public RocketBehavior move2;
    public RocketBehavior move3;
    public RocketBehavior move4;





    void Start()
    {   
        PlayerPrefs.SetInt("isstopmusictocutscene", 0);
        audios = PlayerPrefs.GetFloat("audios", 0.5f);
        musics = PlayerPrefs.GetFloat("musics", 0.5f);
        PlayerPrefs.SetInt("isfinal1g", 0);
        PlayerPrefs.SetInt("youcheat", 1);
        PlayerPrefs.SetInt("youdead", 0);
        PlayerPrefs.SetInt("GoToFinalGlav", 0);


        if (PlayerPrefs.GetInt("fall") == 1)
            rocketfall = true;

        lightgameplay.value = PlayerPrefs.GetFloat("lightgameplay");

        Sm.value = musics;
        Sa.value = audios;
        ad1.volume = audios / 2;
        ad2.volume = audios / 2;
        ad3.volume = audios / 18f;
        ad4.volume = audios / 1.2f;
        ad5.volume = audios / 1.2f;
        ad6.volume = audios;
        ad7.volume = audios;
        ad8.volume = audios / 1.5f;
        ad9.volume = audios;
        yesad.volume = audios / 2;
        SMS.volume = audios / 1.4f;
        noad.volume = audios / 2;

        ps16.Stop();
        ps17.Stop();
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
        ps34.Stop();
        ps35.Stop();
        ps44.Stop();
        ps45.Stop();
        ps46.Stop();
        ps47.Stop();
        ps48.Stop();
        ps49.Stop();
        ps50.Stop();
        ps51.Stop();
        ps52.Stop();
        ps53.Stop();
        ps54.Stop();
        ps55.Stop();
        ps56.Stop();
        ps57.Stop();
        ps58.Stop();
        ps59.Stop();


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
            intsurwive = 200;
            ps35.Stop();
        }

        anim5.Play("anim 2 0");
        anim6.Play("anim 18");
        anim7.Play("anim1");
        anim8.Play("anim12");
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
        isdelay5 -= Time.deltaTime;


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
        ad8.volume = audios / 1.5f;
        ad9.volume = audios;
        yesad.volume = audios / 2;
        SMS.volume = audios / 1.4f;
        noad.volume = audios / 2;

        Dificitefloat = PlayerPrefs.GetFloat("Generators1Energy", 0);
        Dificitefloat += PlayerPrefs.GetFloat("Generators2Energy", 0);
        Dificitefloat += PlayerPrefs.GetFloat("Generators3Energy", 0);
        Dificitefloat += PlayerPrefs.GetFloat("Generators4Energy", 0);
        Dificitefloat -= PlayerPrefs.GetFloat("TurbinsEnergy", 0);

        if(rocketfall && !isfall)
        {
            isfall = true;
            logo.text = "ШОК Контент!";
            logo2.text = "ШОК Контент!";
            logo3.text = "ШОК Контент!";
            logo4.text = "ШОК Контент!";
            t1.text = "Чёрный рынок";
            t3.text = "График страданий";
            t4.text = "Сделай или забудь";
            t5.text = "Говно, но моё";
            PashalTextError2.text = "Турбины нет, также как и твоей девушки";
            PashalTextError1.text = "Твоя турбина слишком прожорливая....";
            PashalTextError3.text = "И куда ты будешь заливать топливо?";
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

        if(intsurwive >= 200 && !isbsurwive)
        {
            PlayerPrefs.SetInt("yousurwive", 1);
            isbsurwive = true;
            surwive.SetActive(true);
        }



        sliderlightfloat = lightgameplay.value;
        PlayerPrefs.SetFloat("lightgameplay", sliderlightfloat);
        


        if (PlayerPrefs.GetInt("music") == 0)
        {
            ison = true;
            but.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else if (PlayerPrefs.GetInt("music") == 1)
        {
            ison = false;
            but.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }

        if (PlayerPrefs.GetInt("audio") == 0)
        {
            ad1.enabled = true;
            ad2.enabled = true;
            ad3.enabled = true;
            ad4.enabled = true;
            ad5.enabled = true;
            ad6.enabled = true;
            ad7.enabled = true;
            ad8.enabled = true;
            ad9.enabled = true;
            yesad.enabled = true;
            noad.enabled = true;
            SMS.enabled = true;
            ison1 = true;
            but1.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else if(PlayerPrefs.GetInt("audio") == 1)
        {
            ad1.enabled = false;
            ad2.enabled = false;
            ad3.enabled = false;
            ad4.enabled = false;
            ad5.enabled = false;
            ad6.enabled = false;
            ad7.enabled = false;
            ad8.enabled = false;
            ad9.enabled = false;
            yesad.enabled = false;
            noad.enabled = false;
            SMS.enabled = false;
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
        if(!rocketfall)
            ad2.Play();
        else
            ad7.Play();
        
        ps16.Stop();
        ps17.Stop();
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
        ps34.Stop();
        ps35.Stop();
        ps36.Stop();
        ps37.Stop();
        ps38.Stop();
        ps39.Stop();
        ps40.Stop();
        ps41.Stop();
        ps42.Stop();
        ps43.Stop();
        ps44.Stop();
        ps45.Stop();
        ps46.Stop();
        ps47.Stop();
        ps48.Stop();
        ps49.Stop();
        ps50.Stop();
        ps51.Stop();
        ps52.Stop();
        ps53.Stop();
        ps54.Stop();
        ps55.Stop();
        ps56.Stop();
        ps57.Stop();
        ps58.Stop();
        ps59.Stop();
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
        logo2.text = "Астероидный Шторм";
        logo3.text = "Астероидный Шторм";
        logo4.text = "Астероидный Шторм";
        butfall.SetActive(false);
        PlayerPrefs.SetInt("fall", 0);
        t1.text = "Магазин";
        t3.text = "Статистика";
        t4.text = "Задания";
        t5.text = "Кастомизация";
        PashalTextError2.text = "Чтобы начать нужно установить турбину в космический аппарат";
        PashalTextError1.text = "Недостаточная выроботка энергии: генераторы не обеспечивают работу выбранной турбине";
        PashalTextError3.text = "Чтобы набрать топливо нужно установить топливный бак в космический аппарат";
        n1.text = "SUS";
        n2.text = "Ёлки-Палки";
        n3.text = "Лунолет";
        n4.text = "Ракета";
        d1.text = "Постоянно подозревает все астероиды в саботаже, а её главный двигатель работает на чистом «эх, импостор, ну ты и…». Красная, быстрая и всегда готова нажать на кнопку. просто сделай чтоб было норм";
        d2.text = "Эта ракета — как новогоднее чудо: горит, летит и иногда взрывается так, что Санта нервно курит в сторонке. Игрушки держатся на честном слове, гирлянда питается от ядерного реактора, а запах хвои — это, возможно, дым.";
        d3.text = "Долетел до Луны, плюнул в кратер и вернулся. Теперь уверен, что Земля круглая, а сыр всё-таки твёрдый.";
        d4.text = "Обычная ракета для необычных ситуаций. Летит прямо… пока не решит, что прямо — это в стену.";
        
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

    public void isps15()
    {
        ps16.Play();
        ps17.Play();
        ps19.Play();
        ps40.Play();
        ps46.Play();
        ps47.Play();
        ps52.Play();
        ps56.Play();
    }
    public void isps16()
    {
        ps20.Play();
        ps21.Play();
        ps22.Play();
        ps23.Play();
        ps24.Play();
        ps41.Play();
        ps48.Play();
        ps49.Play();
        ps53.Play();
        ps57.Play();
    }
    public void isps17()
    {
        ps25.Play();
        ps26.Play();
        ps27.Play();
        ps42.Play();
        ps54.Play();
        ps58.Play();
    }
    public void isps18()
    {
        ps36.Play();
        ps37.Play();
        ps38.Play();
        ps39.Play();
        ps55.Play();
        ps59.Play();
    }
    public void isps19()
    {
        ps31.Play();
    }
    public void isps20()
    {
        ps32.Play();
    }
    public void isps22()
    {
        ps34.Play();
    }
    public void isps23()
    {
        ps35.Play();
    }
    public void isps24()
    {
        ps43.Play();
    }
    public void isps25()
    {
        ps44.Play();
    }
    public void isps26()
    {
        ps45.Play();
    }
    public void isps27()
    {
        ps50.Play();
    }
    public void isps28()
    {
        ps51.Play();
    }


    public void ViewProlog()
    {
        image.SetActive(true);
        anim.Play("anim9 2");
    }



    public void offsound(){PlayerPrefs.SetInt("music", ison ? 1 : 0);}

    public void offaudio(){PlayerPrefs.SetInt("audio", ison1 ? 1 : 0);}

    public void offvibration(){PlayerPrefs.SetInt("vibration", ison2 ? 1 : 0);}


    public void Aftors()
    {
        image.SetActive(true);
        anim.Play("anim9 0 0");
    }

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
        isdelay2 = 0.85f;
        }
    }
    public void is1g()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) != 19)
        {
            float turbinsMinus;
            turbinsMinus = PlayerPrefs.GetFloat("TurbinsEnergy", 0);
            turbinsMinus += PlayerPrefs.GetFloat("TurbinsFuel", 0);

            if (r.isdelayb == true && PlayerPrefs.GetInt("coins", 0) >= 10 && PlayerPrefs.GetInt("fueltostart", 0) >= 1 && Dificitefloat >= 0 && turbinsMinus > 0 || PlayerPrefs.GetInt("yousurwive", 0) == 1)
            {
                PlayerPrefs.SetInt("start", 1);
                int fuel = PlayerPrefs.GetInt("fuel");
                int fuelstart = PlayerPrefs.GetInt("fueltostart");
                fuel -= fuelstart;
                PlayerPrefs.SetInt("fuel", fuel);
                coins = PlayerPrefs.GetInt("coins");

                move1.LaunchRocket();
                move2.LaunchRocket();
                move3.LaunchRocket();
                move4.LaunchRocket();

                if(PlayerPrefs.GetInt("yousurwive", 0) == 0)
                {
                    coins -= 10;
                    allgames = PlayerPrefs.GetInt("allgames", 0);
                    allgames++;
                    PlayerPrefs.SetInt("allgames", allgames);
                    allgamesPermanentTask = PlayerPrefs.GetInt("PermanentTaskLife", 0);
                    allgamesPermanentTask++;
                    PlayerPrefs.SetInt("PermanentTaskLife", allgamesPermanentTask);
                }
                
                PlayerPrefs.SetInt("coins", coins);
                image.SetActive(!image.activeSelf);
                anim.Play("anim9 1");
            }
            else if(turbinsMinus == 0)
            {
                Dificite.Play("Start2");
                noad.Play();
            }
            else if(Dificitefloat <= 0)
            {
                Dificite.Play("Start");
                noad.Play();
            }
            else if(PlayerPrefs.GetInt("coins", 0) <= 9)
            {
                Dificite.Play("Start");
                noad.Play();
            }
        }
        else if(PlayerPrefs.GetInt("IndexDialogue", 0) == 19 && PlayerPrefs.GetInt("fueltostart", 0) >= 1)
        {
            DialogueStart.SetActive(true);
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
                isanim1 = false;
                prefs = 0;
            }

        isdelay2 = 1f;
        
        
        }
    }


    public void activatepanel3()
    {
        if(isdelay2 <= 0)
        {
            if (isanim3 == false)
            {
                isanim3 = true;
                anim6.Play("anim 18 0");
                anim3.Play("19 0");
            }
            else
            {
                anim6.Play("anim 18 0");
                anim3.Play("19 1");
                isanim3 = false;
            }

        isdelay2 = 0.85f;
        

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
            }
            if (isanim3 == false)
            {
                isanim3 = true;
                anim6.Play("anim 18 0");
                anim3.Play("19 0");
            }
            else
            {
                anim6.Play("anim 18 0");
                anim3.Play("19 1");
            }
            
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
            }
            
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
            }

            isdelay2 = 0.85f;
        }
    }
    public void activatepanel34()
    {
        if (isdelay2 <= 0)
        {
            if (isanim3 == false)
            {
                isanim3 = true;
                anim6.Play("anim 18 0");
                anim3.Play("19 0");
            }
            else
            {
                anim6.Play("anim 18 0");
                anim3.Play("19 1");
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
            }
            
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
            }
            
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
            }
            if (isanim7 == false)
            {
                panel8.SetActive(!panel8.activeSelf);
                componentsp.Play("componentsp");
                components.Play("componclick");
                isanim7 = true;
            }
            else if(isdelay2 <= 0)
            {
                componentsp.Play("componentsp1");
                isanim7 = false;
            }
            
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
            }
            if (isCustomPanel == false)
            {
                panelCustomizate.SetActive(!panelCustomizate.activeSelf);
                skins.Play("anim 17 0");
                skinspanel.Play("customization");
                isCustomPanel = true;
            }
            else if(isdelay2 <= 0)
            {
                skinspanel.Play("customization 0");
                isCustomPanel = false;
            }
            
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel35()
    {
        if (isdelay2 <= 0)
        {
            if (isanim3 == false)
            {
                isanim3 = true;
                anim6.Play("anim 18 0");
                anim3.Play("19 0");
            }
            else
            {
                anim6.Play("anim 18 0");
                anim3.Play("19 1");
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
            }
            
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
            }
            else if(isdelay2 <= 0)
            {
                componentsp.Play("componentsp1");
                isanim7 = false;
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
            }
            
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
            }
            else if(isdelay2 <= 0)
            {
                skinspanel.Play("customization 0");
                isCustomPanel = false;
            }
            if (isanim7 == false)
            {
                panel8.SetActive(!panel8.activeSelf);
                isanim7 = true;
                componentsp.Play("componentsp");
                components.Play("componclick");
            }
            else if (isanim7 == true)
            {
                isanim7 = false;
                componentsp.Play("componentsp1");
            }
            
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
            }
            else if(isdelay2 <= 0)
            {
                skinspanel.Play("customization 0");
                isCustomPanel = false;
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
            }
            
            isdelay2 = 0.85f;
        }
    }
    public void activatepanelbl()
    {
        if (isdelay2 <= 0)
        {
            if (isBankPanel == false)
            {
                panelBank.SetActive(!panelBank.activeSelf);
                Bank.Play("Bankclick");
                bankpanel.Play("Bank");
                isBankPanel = true;
            }
            else if(isdelay2 <= 0)
            {
                bankpanel.Play("Bank 0");
                isBankPanel = false;
            }
            
             if (isLomPanel == false)
            {
                panelLom.SetActive(!panelLom.activeSelf);
                lombard.Play("lombardclick");
                lompanel.Play("Lombard");
                isLomPanel = true;
            }
            else if (isdelay2 <= 0)
            {
                lompanel.Play("Lombard 0");
                isLomPanel = false;
            }
            
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
                one = 0;
            }

            isdelay2 = 0.85f;

            
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
            }

            isdelay2 = 0.85f;

            
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
            }

            isdelay2 = 0.85f;

            
        }
    }
    public void activatepanel6()
    {
        if(isdelay2 <= 0)
        {
            one = 0;
            if (isanim6 == false)
            {
                panel6.SetActive(!panel6.activeSelf);
                anim20.Play("anim 45 1");
                isanim6 = true;
            }
            else if(isdelay2 <= 0)
            {
                anim20.Play("anim 45 0");
                isanim6 = false;
            }

            
            isdelay2 = 0.85f;
        }
    }
    public void activatepanel8()
    {
        if(isdelay2 <= 0)
        {
            if (isanim7 == false)
            {
                panel8.SetActive(!panel8.activeSelf);
                componentsp.Play("componentsp");
                components.Play("componclick");
                isanim7 = true;
            }
            else if(isdelay2 <= 0)
            {
                componentsp.Play("componentsp1");
                isanim7 = false;
            }
            
            isdelay2 = 0.85f;
        }
    }
    public void activateCustomizatePanel()
    {
        if(isdelay2 <= 0)
        {
            if (isCustomPanel == false)
            {
                panelCustomizate.SetActive(!panelCustomizate.activeSelf);
                skins.Play("anim 17 0");
                skinspanel.Play("customization");
                isCustomPanel = true;
            }
            else if(isdelay2 <= 0)
            {
                skinspanel.Play("customization 0");
                isCustomPanel = false;
            }

            isdelay2 = 0.85f;
        }
    }
    public void activateLombardPanel()
    {
        if(isdelay2 <= 0)
        {
            if (isLomPanel == false)
            {
                panelLom.SetActive(!panelLom.activeSelf);
                lombard.Play("lombardclick");
                lompanel.Play("Lombard");
                isLomPanel = true;
            }
            else if(isdelay2 <= 0)
            {
                lompanel.Play("Lombard 0");
                isLomPanel = false;
            }
        
            isdelay2 = 0.85f;
        }
    }
    public void activateBankPanel()
    {
        if(isdelay2 <= 0)
        {
            if (isBankPanel == false)
            {
                panelBank.SetActive(!panelBank.activeSelf);
                Bank.Play("Bankclick");
                bankpanel.Play("Bank");
                isBankPanel = true;
            }
            else if(isdelay2 <= 0)
            {
                bankpanel.Play("Bank 0");
                isBankPanel = false;
            }
            
            isdelay2 = 0.85f;
        }
    }
}
