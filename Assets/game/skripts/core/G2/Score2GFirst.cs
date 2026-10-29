using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RDG;
using UnityEngine.SceneManagement;

public class Score2GFirst : MonoBehaviour
{
    [SerializeField] public Transform player;

    public ObstacleSpawner spawner;
    private float isdelay5;
    private bool isCloseHomePanel;
    private float homeFloatPanel;
    private bool isHomePanel;
    public Animator homepanel;
    public GameObject panelHome;
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;
    public Animator anim1;
    public int Vp;
    public Text scoreText;
    public sceneman s;
    public ParticleSystem ps;
    public ParticleSystem ps1;
    [HideInInspector]public int score;
    public AudioSource ad1;
    public AudioSource ad2;
    public AudioSource ad3;
    public AudioSource ad4;
    public AudioSource ad5;
    public AudioSource ad6;
    public AudioSource ad7;
    public AudioSource ad8;
    public AudioSource ad9;
    public AudioSource ad10;
    public AudioSource ad11;
    public AudioSource ad12;
    public AudioSource ad14;
    public AudioSource ad15;
    public AudioSource ad16;
    public AudioSource ad17;
    public AudioSource ad18;
    public AudioSource ad19;
    public AudioSource ad20;
    public ObstacleSpawner o;
    public ObstacleSpawner omini;
    public int spawn;
    private bool isbtotask;
    private float function;
    private float isdelay;
    private float isdelay1 = 1;
    private float isdelay2 = 1;
    public float isminus;
    private bool isbportal;
    private int ach6;
    public Animator achanim6;
    public Animator anim;
    public Animator anim2;
    private bool isbtonext;
    public Text text;
    public Animator anim4;
    public int MessagesID;
    private bool rocketfall;
    public Light l;
    private bool isstart;
    public Animator Disk1;
    public Animator Disk2;

    private float nextSpawnTime = 0f;
    private float baseSpawnInterval = 1.3f;
    private float spawnVariance = 0.5f;
    private float audios = 0.5f;

    [Header("Materials")]
    public Material Display;
    private float AlphaDisplay;
    private bool FirstPressBool;

    public bool Is3G;

    public static bool Is3Glav;
    public static float Quality = 80;

    public Text EndText;


    IEnumerator LoadParticlesWithDelay()
    {
        yield return new WaitForSeconds(0.1f);
        ps1.Play();
        Debug.Log("ps1 запущен!");
    }

    private string[] phrases = new string[]
    {
        "Гравитация усиливается",
        "Скорость держится в пределах нормы",
        "Двигатели работают ровно",
        "Системы охлаждения стабилизированы",
        "Сигнал с корабля чистый",
        "Траектория без отклонений",
        "Зафиксировали небольшие колебания",
        "Энергопотребление в норме",
        "Навигационный расчёт подтверждён",
        "Контрольные показатели без критических отклонений",
        "Обнаружены незначительные помехи",
        "Полёт проходит в пределах допустимых параметров",
        "Все модули функционируют корректно"
    };

    void Start()
    {
        Quality = 80;

        Is3Glav = Is3G;
        Display.SetFloat("_Alpha", 0);
        PlayerPrefs.SetInt("youdead", 0);
        PlayerPrefs.SetInt("start", 0);
        PlayerPrefs.SetInt("isfinal1g", 0);
        PlayerPrefs.SetInt("AchActive", 1);
        PlayerPrefs.SetInt("live", PlayerPrefs.GetInt("LifeToStart", 1));
        ach6 = PlayerPrefs.GetInt("ach7");

        if (PlayerPrefs.GetInt("isbtotask") == 1)
            isbtotask = true;
        
        l.intensity = PlayerPrefs.GetFloat("lightgameplay") / 2;

        RenderSettings.fog = false;
        StartCoroutine(LoadParticlesWithDelay());
        stopps();
        isminus = 25;

        if (s1 && s1.activeInHierarchy) player = s1.transform;
        else if (s2 && s2.activeInHierarchy) player = s2.transform;
        else if (s3 && s3.activeInHierarchy) player = s3.transform;
        else if (s4 && s4.activeInHierarchy) player = s4.transform;
        else if (s5 && s5.activeInHierarchy) player = s5.transform;

        Vp = PlayerPrefs.GetInt("maxParticles", 31);
        var main = ps1.main;
        main.maxParticles = Vp;
        ps1.Clear();
        ps1.Play();

        if (PlayerPrefs.GetInt("fall") == 1)
            rocketfall = true;

        anim.CrossFade("anim6", 0.1f);

        PlayerPrefs.SetInt("live", PlayerPrefs.GetInt("LifeToStart", 1));

        UpdateObstacleCount();

        ScheduleNextSpawn();
    }

    void Update()
    {
        if (s1 && s1.activeInHierarchy) player = s1.transform;
        else if (s2 && s2.activeInHierarchy) player = s2.transform;
        else if (s3 && s3.activeInHierarchy) player = s3.transform;
        else if (s4 && s4.activeInHierarchy) player = s4.transform;
        else if (s5 && s5.activeInHierarchy) player = s5.transform;

        if (player == null) return;

        isdelay1 -= Time.deltaTime;
        isdelay -= Time.deltaTime;
        isdelay2 -= Time.deltaTime;


        if(isdelay1 >= 0 && !isstart)
        {
            if(ps != null)
                ps.Stop();
            ps1.Stop();
        }
        else
        {
            isstart = true;
        }

        if(homeFloatPanel <= 0)
        {
            if(isCloseHomePanel == true)
            {
                isCloseHomePanel = false;
                panelHome.SetActive(!panelHome.activeSelf);
            }
        }

        homeFloatPanel -= Time.deltaTime;


        audios = PlayerPrefs.GetFloat("audios", 0.5f);
        ad1.volume = audios / 3.5f;
        ad2.volume = audios / 2;
        ad3.volume = audios / 2;
        ad4.volume = audios / 2.5f;
        ad5.volume = audios;
        ad6.volume = audios / 3;
        ad7.volume = audios / 3;
        ad8.volume = audios / 3.5f;
        ad9.volume = audios / 1.25f;
        ad10.volume = audios / 4f;
        if(ad11 != null)
            ad11.volume = audios;
        ad12.volume = audios / 1.5f;
        ad14.volume = audios;
        ad15.volume = audios / 1.8f;
        ad16.volume = audios;
        ad17.volume = audios;
        ad18.volume = audios;
        ad19.volume = audios;
        ad20.volume = audios;

        if (Is3G)
        {
            if (spawn >= 650 && MessagesID == 0)
            {
                text.text = "Достигнуто внешнее кольцо аккреционного диска";
                anim2.CrossFade("anim 26 1", 0.1f);
                ad9.Play();
                MessagesID++;
                Disk1.Play("DisksIncreases");
                PlayerPrefs.SetInt("youcheat", 0);
            }
            if (spawn >= 1300 && MessagesID == 1)
            {
                text.text = "Достигнуто внутреннее кольцо аккреционного диска";
                anim2.CrossFade("anim 26 1", 0.1f);
                ad9.Play();
                MessagesID++;
                Disk2.Play("DisksIncreases");
            }
            if (spawn >= 1730)
            {
                AlphaDisplay = Mathf.MoveTowards(AlphaDisplay, 0.9f, Time.deltaTime / 17);
                Display.SetFloat("_Alpha", AlphaDisplay);
                isbtonext = true;
            }
            if (spawn > 1850 && PlayerPrefs.GetInt("youdead", 0) == 0 && MessagesID == 2)
            {
                if(rocketfall)
                {
                    if(Quality >= 40)
                        EndText.text = "Полёт прошёл так идеально, что Чёрная Дыра только что поставила этому маршруту 5 звёзд на Яндекс Картах!";
                    else
                        EndText.text = "Мне этот полёт вообще не понравился, вернись и пролети заново!!!";
                }
                else
                {
                    if(Quality >= 40)
                        EndText.text = "Всё удалось! Полёт в черную дыру прошёл успешно!";
                    else
                        EndText.text = "Полёт был как у ребёнка. В любом случае, это несерьёзно. Просыпайся и лети.";
                }

                anim1.Play("anim10 4");
            }
        }
        else
        {
            if (spawn >= 400 && MessagesID == 0)
            {
                text.text = "Достигнуто внешнее кольцо аккреционного диска";
                anim2.CrossFade("anim 26 1", 0.1f);
                ad9.Play();
                MessagesID++;
                Disk1.Play("DisksIncreases");
                PlayerPrefs.SetInt("youcheat", 0);
            }
            if (spawn >= 920 && ach6 == 0 && PlayerPrefs.GetInt("yousurwive", 0) == 0)
            {
                ach6 = 1;
                PlayerPrefs.SetInt("ach7", 1);
                achanim6.CrossFade("anim20", 0.1f);
                ad5.Play();
            }
            if (spawn >= 565 && MessagesID == 1)
            {
                string selected = phrases[UnityEngine.Random.Range(0, phrases.Length)];
                text.text = "Сканирование: " + selected;
                anim2.CrossFade("anim 26 1", 0.1f);
                ad9.Play();
                MessagesID++;
            }
            if (spawn >= 730 && MessagesID == 2)
            {
                text.text = "Достигнуто внутреннее кольцо аккреционного диска";
                anim2.CrossFade("anim 26 1", 0.1f);
                ad9.Play();
                MessagesID++;
                Disk2.Play("DisksIncreases");
            }
            if (spawn >= 980 && MessagesID == 3)
            {
                text.text = "Сканирование: регистрация радиационных колебаний";
                anim2.CrossFade("anim 26 1", 0.1f);
                ad9.Play();
                MessagesID++;
            }
            if (spawn >= 1070 && MessagesID == 5 && PlayerPrefs.GetInt("youdead", 0) == 0)
            {
                MessagesID++;
                PlayerPrefs.SetInt("isfinal1g", 1);
                anim1.Play("anim10 4");
            }
            if (spawn >= 960)
            {
                AlphaDisplay = Mathf.MoveTowards(AlphaDisplay, 0.9f, Time.deltaTime / 17);
                Display.SetFloat("_Alpha", AlphaDisplay);
            }
            if (spawn > 900 && MessagesID == 4)
            {
                isbtonext = true;
                MessagesID++;
            }
        }

        if (spawn >= 700)
        {
            if (!isbtotask)
            {
                if (PlayerPrefs.GetInt("currentTask1", -1) == 2 && PlayerPrefs.GetInt("live") == PlayerPrefs.GetInt("LifeToStart", 1))
                {
                    isbtotask = true;
                    PlayerPrefs.SetInt("scoreNoDamage", 700);
                    PlayerPrefs.SetInt("isbtotask", 1);
                }
                else if (PlayerPrefs.GetInt("currentTask1", -1) == 3 && PlayerPrefs.GetInt("isabilityuse") == 0)
                {
                    isbtotask = true;
                    PlayerPrefs.SetInt("scoreNoAbility", 700);
                    PlayerPrefs.SetInt("isbtotask", 1);
                }
            }
        }
        if (!isbtotask)
        {
            if (PlayerPrefs.GetInt("currentTask1", -1) == 2 && PlayerPrefs.GetInt("live") == PlayerPrefs.GetInt("LifeToStart", 1))
            {
                PlayerPrefs.SetInt("scoreNoDamage", (int)(player.position.z / 3));
            }
            else if (PlayerPrefs.GetInt("currentTask1", -1) == 3 && PlayerPrefs.GetInt("isabilityuse") == 0)
            {
                PlayerPrefs.SetInt("scoreNoAbility", (int)(player.position.z / 3));
            }
        }

        if (isdelay1 <= 0)
        {
            isdelay1 = 99999;
            ps1.Play();
        }

        if (isdelay <= 0)
        {
            if (isminus >= 5)
            {
                isdelay = 25f;
                isminus -= 1f;
            }
        }

        score = (int)(player.position.z / 3);
        if(Is3G)
            scoreText.text = "Качество полета: " + Quality.ToString("0.#") + "%";
        spawn = ((int)(player.position.z) / 3);

        UpdateObstacleCount();

        if (Time.time >= nextSpawnTime && !isbportal)
        {
            if (!isbtonext)
            {
                function += isminus;
                o.SpawnObstacles();
                omini.SpawnObstacles();
                ScheduleNextSpawn();
            }
        }

        if(PlayerPrefs.GetInt("Ach5Level", 0) == 1 && spawn >= 300 && !FirstPressBool)
            PlayerPrefs.SetInt("Ach5Level", 2);

        if (score >= PlayerPrefs.GetInt("maxScore"))
        {
            PlayerPrefs.SetInt("maxScore", (int)(player.position.z / 3));
        }
        
        if(!Is3G)
            scoreText.text = "" + score;

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
            ad10.enabled = true;
            if(ad11 != null)
                ad11.enabled = true;
            ad12.enabled = true;
            ad14.enabled = true;
            ad16.enabled = true;
            ad17.enabled = true;
            ad18.enabled = true;
            ad19.enabled = true;
            ad20.enabled = true;
        }
        else if (PlayerPrefs.GetInt("audio") == 1)
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
            ad10.enabled = false;
            ad11.enabled = false;
            ad12.enabled = false;
            ad14.enabled = false;
            ad15.volume = 0;
            ad16.enabled = false;
            ad17.enabled = false;
            ad18.enabled = false;
            ad19.enabled = false;
            ad20.enabled = false;
        }
    }

    void ScheduleNextSpawn()
    {
        float randomOffset = UnityEngine.Random.Range(-spawnVariance, spawnVariance);
        nextSpawnTime = Time.time + baseSpawnInterval + randomOffset;
    }

    void UpdateObstacleCount()
    {
        if (spawn < 400)
        {
            spawner.SetObstacleCount(3);
        }
        else if (spawn < 730)
        {
            omini.SetObstacleCount(4);
        }
        else if (spawn < 1050)
        {
            omini.SetObstacleCount(5);
        }
        else
        {
            omini.SetObstacleCount(4);
        }

        if (spawn < 300)
        {
            spawner.SetObstacleCount(2);
        }
        else if (spawn < 700)
        {
            spawner.SetObstacleCount(3);
        }
        else if (spawn < 1200)
        {
            spawner.SetObstacleCount(4);
        }
        else
        {
            spawner.SetObstacleCount(3);
        }
    }

    public void startps()
    {
        if(ps == null) return;

        ps.Play();
    }

    public void stopps()
    {
        if(ps == null) return;

        ps.Stop();
    }

    public void isvibration()
    {
        if (PlayerPrefs.GetInt("vibration") == 0)
        {
            Vibration.Vibrate(80, 20);
            Debug.Log("sds");
        }
    }

    public void isvibration1()
    {
        if (PlayerPrefs.GetInt("vibration") == 0)
        {
            Vibration.Vibrate(80, 100);
        }
    }

    public void ad2in()
    {
        if (!rocketfall)
            ad2.Play();
        else
            ad11.Play();
    }

    public void ad3end()
    {
        if (!rocketfall)
            ad3.Play();
        else
            ad12.Play();
    }
    

    public void activateHomePanel()
    {
        if (isHomePanel == false)
        {
            panelHome.SetActive(!panelHome.activeSelf);
            homepanel.CrossFade("animat", 0.1f);
            isHomePanel = true;
            isdelay5 = 1;
        }
        else if (isdelay2 <= 0)
        {
            homepanel.CrossFade("animat 0", 0.1f);
            isHomePanel = false;
            homeFloatPanel = 1;
            isCloseHomePanel = true;
        }
    }

    public void FirstPress()
    {
        FirstPressBool = true;
    }
}
