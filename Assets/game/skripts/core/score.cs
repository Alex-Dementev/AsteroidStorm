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
    public bool isCloseHomePanel;
    public float homeFloatPanel;
    public bool isHomePanel;
    public Animator homepanel;
    public GameObject panelHome;
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    public Animator anim1;

    public bool isbtotask;

    public GameObject image;
    public int Vp;
    public Text scoreText;
    public Light l;
    public ParticleSystem ps;
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public int score;
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
    public ObstacleSpawner o;
    public ObstaclearSpawner oar;
    public int spawn;
    public float function;
    public float isdelay;
    public float isdelay1;
    private float isdelay2 = 1;
    public float isminus;
    public SmoothSkyboxSwitcher ss;
    public bool isbportal;
    private int ars = 300;
    public int ach1;
    public int ach2;
    public Animator achanim1;
    public Animator achanim2;
    public Animator anim;
    public bool isbtonext;
    public float isdelay3;
    public bool isend;
    public bool isend2;
    public float isdelay4 = 2f;
    public Text text;
    public Animator anim2;
    public bool is100;
    public bool is825;
    public bool is440;
    public bool is250;
    public bool is750;
    public bool isstart;

    private float nextSpawnTime = 0f;
    private float baseSpawnInterval = 1.3f;
    private float spawnVariance = 0.5f;
    private float audios = 0.5f;
    public bool rocketfall;

    IEnumerator LoadParticlesWithDelay()
    {
        yield return new WaitForSeconds(0.1f);
        ps1.Play();
        Debug.Log("ps1 запущен!");
    }



    private string[] phrases = new string[]
    {
        "Остерегайтесь космического мусора",
        "Курс стабилен",
        "Курс выровнен",
        "Какать охото",
        "Наблюдаю Луну на горизонте",
        "Супер облепиха",
        "военный мёд",
        "грустный мёд",
        "Луна впереди"
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

        ach1 = PlayerPrefs.GetInt("1.5kscore", 0);
        ach2 = PlayerPrefs.GetInt("450score", 0);

        Vp = PlayerPrefs.GetInt("maxParticles", 31);
        var main = ps1.main;
        main.maxParticles = Vp;
        ps1.Clear();
        ps1.Play();

        if (PlayerPrefs.GetInt("fall") == 1)
            rocketfall = true;


        anim.Play("anim6");

        UpdateObstacleCount();

        ScheduleNextSpawn();

        PlayerPrefs.SetInt("live", 3);
    }

    void Update()
    {
        isdelay5 -= Time.deltaTime;

        if (s1 && s1.activeInHierarchy) player = s1.transform;
        else if (s2 && s2.activeInHierarchy) player = s2.transform;
        else if (s3 && s3.activeInHierarchy) player = s3.transform;
        else if (s4 && s4.activeInHierarchy) player = s4.transform;

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


        if ((int)(player.position.z / 3) >= 890 && !isend2 && PlayerPrefs.GetInt("youdead", 0) == 0)
        {
            PlayerPrefs.SetInt("GoToFinalGlav", 1);
            image.SetActive(true);
            anim1.Play("anim10 0");
            isdelay3 = 1f;
            isend = true;
            isend2 = true;
        }
        if ((int)(player.position.z / 3) >= 100 && !is100)
        {
            anim2.Play("anim 26 1");
            is100 = true;
            ad9.Play();
        }
        if ((int)(player.position.z / 3) >= 825 && !is825)
        {
            text.text = "выход на высокую арбиту луны";
            anim2.Play("anim 26 1");
            is825 = true;
            ad9.Play();
        }
        if ((int)(player.position.z / 3) >= 440 && !is440)
        {
            string selected = phrases[UnityEngine.Random.Range(0, phrases.Length)];
            text.text = "пол пути пройдено: " + selected;
            anim2.Play("anim 26 1");
            is440 = true;
            ad9.Play();
            PlayerPrefs.SetInt("youcheat", 0);
        }

        if ((int)(player.position.z / 3) >= 700)
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

        if ((int)(player.position.z / 3) >= 750 && !is750)
        {
            string selected = phrases[UnityEngine.Random.Range(0, phrases.Length)];
            text.text = "Большое количество остеридов: " + selected;
            anim2.Play("anim 26 1");
            is750 = true;
            ad9.Play();
        }
        if ((int)(player.position.z / 3) >= 250 && !is250)
        {
            text.text = "курс стабилен";
            anim2.Play("anim 26 1");
            is250 = true;
            ad9.Play();
        }

        if (isdelay3 <= 0 && isend)
        {
            SceneManager.LoadScene("cutsceneG1");
        }

        if (spawn > 840)
        {
            isbtonext = true;
        }


        if (isdelay1 <= -1)
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
            PlayerPrefs.SetInt("1.5kscore", 1);
            ach1 = 1;
            achanim2.Play("anim 21");
            ad5.Play();
        }
        if (ach2 == 0 && spawn >= 500 && PlayerPrefs.GetInt("yousurwive", 0) == 0)
        {
            PlayerPrefs.SetInt("450score", 1);
            ach2 = 1;
            achanim1.Play("anim20");
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
        }

        if (spawn >= ars)
        {
            ars += 150;
            oar.SpawnObstaclesar();
        }
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
                homepanel.Play("animat");
                isHomePanel = true;
                isdelay5 = 1;
            }
            else if(isdelay2 <= 0)
            {
                homepanel.Play("animat 0");
                isHomePanel = false;
                homeFloatPanel = 1;
                isCloseHomePanel = true;
            }
    }
}
