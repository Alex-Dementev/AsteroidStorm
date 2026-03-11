using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RDG;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] public Transform player;

    public float isdelay5;
    public ObstacleSpawner spawner;
    public ObstacleSpawner spawnermini;
    private bool isCloseHomePanel;
    public float homeFloatPanel;
    private bool isHomePanel;
    public Animator homepanel;
    public GameObject panelHome;
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;

    public Animator anim1;

    private bool isbtotask;

    public GameObject image;
    private int Vp;
    public Text scoreText;
    public Light l;
    public ParticleSystem ps;
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    private int score;
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
    public AudioSource ad13;
    public AudioSource ad14;
    public AudioSource ad15;
    public AudioSource ad16;
    public AudioSource ad17;
    public AudioSource ad18;
    public AudioSource ad19;
    public ObstacleSpawner o;
    public ObstaclearSpawner oar;
    private int spawn;
    private float function;
    private float isdelay;
    private float isdelay1;
    private float isdelay2 = 1;
    private float isminus;
    private bool isbportal;
    private int ars = 300;
    private int ach1;
    private int ach2;
    public Animator achanim1;
    public Animator achanim2;
    public Animator anim;
    private bool isbtonext;
    private float isdelay3;
    private bool isend;
    private bool isend2;
    private float isdelay4 = 2f;
    public Text text;
    public Animator anim2;
    private int MessagesID;
    private bool isstart;

    private float nextSpawnTime = 0f;
    private float baseSpawnInterval = 1.3f;
    private float spawnVariance = 0.5f;
    private float audios = 0.5f;
    private bool rocketfall;
    private bool FirstPressBool;

    IEnumerator LoadParticlesWithDelay()
    {
        yield return new WaitForSeconds(0.1f);
        ps1.Play();
    }



    private string[] phrases = new string[]
    {
        "Курс стабилен.",
        "Курс выровнен.",
        "Супер облепиха.",
        "военный мёд.",
        "грустный мёд.",
        "Показатели корабля в норме.",
        "Навигация подтверждает курс.",
        "Связь стабильна.",
        "Двигатели работают ровно.",
        "Траектория без отклонений.",
        "Сканеры чисты.",
        "Данные телеметрии обновлены.",
        "Системы работают штатно.",
        "Проверка курса завершена.",
        "Параметры полёта стабильны.",
        "Канал связи чист.",
        "Отклонений не обнаружено.",
        "Тяга двигателей в норме.",
        "Навигационные данные обновлены."
    };



    void Start()
    {
        PlayerPrefs.SetInt("youdead", 0);
        PlayerPrefs.SetInt("start", 0);
        PlayerPrefs.SetInt("isfinal1g", 0);
        if (PlayerPrefs.GetInt("isbtotask") == 1)
        {
            isbtotask = true;
        }

        l.intensity = PlayerPrefs.GetFloat("lightgameplay");

        StartCoroutine(LoadParticlesWithDelay());
        stopps();
        isminus = 25;

        if (s1 && s1.activeInHierarchy) player = s1.transform;
        else if (s2 && s2.activeInHierarchy) player = s2.transform;
        else if (s3 && s3.activeInHierarchy) player = s3.transform;
        else if (s4 && s4.activeInHierarchy) player = s4.transform;
        else if (s5 && s5.activeInHierarchy) player = s5.transform;

        ach1 = PlayerPrefs.GetInt("ach2", 0);
        ach2 = PlayerPrefs.GetInt("ach1", 0);

        Vp = PlayerPrefs.GetInt("maxParticles", 31);
        var main = ps1.main;
        main.maxParticles = Vp;
        ps1.Clear();
        ps1.Play();

        if (PlayerPrefs.GetInt("fall") == 1)
            rocketfall = true;


        anim.CrossFade("anim6", 0.1f);

        UpdateObstacleCount();

        ScheduleNextSpawn();

        PlayerPrefs.SetInt("live", PlayerPrefs.GetInt("LifeToStart", 1));
    }

    void Update()
    {
        isdelay5 -= Time.deltaTime;

        if (s1 && s1.activeInHierarchy) player = s1.transform;
        else if (s2 && s2.activeInHierarchy) player = s2.transform;
        else if (s3 && s3.activeInHierarchy) player = s3.transform;
        else if (s4 && s4.activeInHierarchy) player = s4.transform;
        else if (s5 && s5.activeInHierarchy) player = s5.transform;

        if (player == null) return;

        isdelay1 -= Time.deltaTime;
        isdelay -= Time.deltaTime;
        isdelay2 -= Time.deltaTime;
        isdelay3 -= Time.deltaTime;
        isdelay4 -= Time.deltaTime;


        if(isdelay1 >= 0 && !isstart)
        {
            ps.Stop();
            ps1.Stop();
            ps2.Stop();
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
        ad8.volume = audios / 14;
        ad9.volume = audios / 1.25f;
        ad10.volume = audios;
        ad11.volume = audios;
        ad12.volume = audios;
        ad13.volume = audios / 1.3f;
        ad14.volume = audios;
        ad15.volume = audios;
        ad16.volume = audios;
        ad17.volume = audios;
        ad18.volume = audios;
        ad19.volume = audios;


        if (spawn >= 1150 && !isend2 && PlayerPrefs.GetInt("youdead", 0) == 0)
        {
            image.SetActive(true);
            anim1.Play("anim10 0");
            isdelay3 = 2f;
            isend = true;
            isend2 = true;
        }
        if (spawn >= 1145 && !isend2 && PlayerPrefs.GetInt("youdead", 0) == 0)
        {
            PlayerPrefs.SetInt("GoToFinalGlav", 1);
        }
        if (spawn >= 100 && MessagesID == 0)
        {
            anim2.CrossFade("anim 26 1", 0.1f);
            MessagesID++;
            ad9.Play();
        }
        if (spawn >= 925 && MessagesID == 4)
        {
            text.text = "Сканирование: выход на высокую орбиту луны.";
            anim2.CrossFade("anim 26 1", 0.1f);
            MessagesID++;
            ad9.Play();
        }
        if (spawn >= 440 && MessagesID == 2)
        {
            string selected = phrases[UnityEngine.Random.Range(0, phrases.Length)];
            text.text = "Сканирование: " + selected;
            anim2.CrossFade("anim 26 1", 0.1f);
            MessagesID++;
            ad9.Play();
            PlayerPrefs.SetInt("youcheat", 0);
        }

        if (spawn >= 750)
        {
            if (!isbtotask)
            {
                if (PlayerPrefs.GetInt("currentTask1", -1) == 2 && PlayerPrefs.GetInt("live") == 3)
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
            if (PlayerPrefs.GetInt("currentTask1", -1) == 2 && PlayerPrefs.GetInt("live") == 3)
            {
                PlayerPrefs.SetInt("scoreNoDamage", (int)(player.position.z / 3));
            }
            else if (PlayerPrefs.GetInt("currentTask1", -1) == 3 && PlayerPrefs.GetInt("isabilityuse") == 0)
            {
                PlayerPrefs.SetInt("scoreNoAbility", (int)(player.position.z / 3));
            }
        }

        if (spawn >= 750 && MessagesID == 3)
        {
            string selected = phrases[UnityEngine.Random.Range(0, phrases.Length)];
            text.text = "Сканирование: " + selected;
            anim2.CrossFade("anim 26 1", 0.1f);
            MessagesID++;
            ad9.Play();
        }
        if (spawn >= 250 && MessagesID == 1)
        {
            string selected = phrases[UnityEngine.Random.Range(0, phrases.Length)];
            text.text = "Сканирование: " + selected;
            anim2.CrossFade("anim 26 1", 0.1f);
            MessagesID++;
            ad9.Play();
        }

        if (isdelay3 <= 0 && isend)
        {
            SceneManager.LoadScene("cutsceneG1");
        }

        if (spawn > 1080)
        {
            isbtonext = true;
        }


        if (isdelay1 <= -4)
        {
            image.SetActive(!image.activeSelf);
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

        if (ach1 == 0 && spawn >= 850 && PlayerPrefs.GetInt("yousurwive", 0) == 0)
        {
            PlayerPrefs.SetInt("ach2", 1);
            ach1 = 1;
            achanim2.CrossFade("anim 21", 0.1f);
            ad5.Play();
        }
        if (ach2 == 0 && spawn >= 350 && PlayerPrefs.GetInt("yousurwive", 0) == 0)
        {
            PlayerPrefs.SetInt("Achevements", 1);
            PlayerPrefs.SetInt("ach1", 1);
            ach2 = 1;
            achanim1.CrossFade("anim20", 0.1f);
            ad5.Play();
        }

        score = ((int)(player.position.z / 3));
        scoreText.text = (score.ToString() + " очков");
        spawn = ((int)(player.position.z) / 3);

        UpdateObstacleCount();

        if (Time.time >= nextSpawnTime && !isbportal)
        {
            if (!isbtonext)
            {
                function += isminus;
                o.SpawnObstacles();
                ScheduleNextSpawn();
                spawnermini.SpawnObstacles();
            }
        }

        if (score >= PlayerPrefs.GetInt("maxScore"))
        {
            PlayerPrefs.SetInt("maxScore", ((int)(player.position.z / 3)));
        }

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
            ad11.enabled = true;
            ad12.enabled = true;
            ad15.enabled = true;
            ad14.enabled = true;
            ad16.enabled = true;
            ad17.enabled = true;
            ad18.enabled = true;
            ad19.enabled = true;
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
            ad15.enabled = false;
            ad14.enabled = false;
            ad13.volume = 0;
            ad16.enabled = false;
            ad17.enabled = false;
            ad18.enabled = false;
            ad19.enabled = false;
        }

        if (spawn >= ars && spawn <= 950)
        {
            ars += 130;
            oar.SpawnObstaclesar();
        }

        if(PlayerPrefs.GetInt("Ach5Level", 0) == 1 && spawn >= 300 && !FirstPressBool)
            PlayerPrefs.SetInt("Ach5Level", 2);
    }

    public void FirstPress()
    {
        FirstPressBool = true;
    }

    void ScheduleNextSpawn()
    {
        float randomOffset = UnityEngine.Random.Range(-spawnVariance, spawnVariance);
        nextSpawnTime = Time.time + baseSpawnInterval + randomOffset;
    }

    void UpdateObstacleCount()
    {
        if (spawn < 150)
        {
            spawner.SetObstacleCount(1);
        }
        else if (spawn < 300)
        {
            spawner.SetObstacleCount(2);
        }
        else if (spawn < 450)
        {
            spawner.SetObstacleCount(4);
        }
        else if (spawn < 600)
        {
            spawner.SetObstacleCount(5);
        }
        else if (spawn < 765)
        {
            spawner.SetObstacleCount(4);
        }
        else
        {
            spawner.SetObstacleCount(3);
        }
        if (spawn < 150)
        {
            spawnermini.SetObstacleCount(3);
        }
        else if (spawn < 300)
        {
            spawnermini.SetObstacleCount(4);
        }
        else if (spawn < 450)
        {
            spawnermini.SetObstacleCount(5);
        }
        else if (spawn < 600)
        {
            spawnermini.SetObstacleCount(6);
        }
        else if (spawn < 765)
        {
            spawnermini.SetObstacleCount(5);
        }
        else
        {
            spawnermini.SetObstacleCount(4);
        }
    }

    public void startps()
    {
        ps.Play();
    }
    public void startps2()
    {
        ps2.Play();
    }

    public void stopps()
    {
        ps.Stop();
        ps2.Stop();
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

    public void ad2in()
    {
        if (!rocketfall)
            ad2.Play();
        else
            ad10.Play();
    }

    public void ad3end()
    {
        if (!rocketfall)
            ad3.Play();
        else
            ad11.Play();
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
            else if(isdelay2 <= 0)
            {
                homepanel.CrossFade("animat 0", 0.1f);
                isHomePanel = false;
                homeFloatPanel = 1;
                isCloseHomePanel = true;
            }
    }
}
