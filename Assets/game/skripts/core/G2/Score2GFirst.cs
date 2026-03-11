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
    public float isdelay5;
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
    public GameObject image;
    public int Vp;
    public Text scoreText;
    public sceneman s;
    public ParticleSystem ps;
    public ParticleSystem ps1;
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
    public float function;
    public float isdelay;
    public float isdelay1 = 1;
    private float isdelay2 = 1;
    public float isminus;
    private bool isbportal;
    public int ach3;
    public Animator achanim1;
    public Animator anim;
    public Animator anim2;
    private bool isbtonext;
    public float isdelay3;
    private bool isend;
    private bool isend2;
    public float isdelay4 = 2f;
    public Text text;
    public Animator anim4;
    public int MessagesID;
    private bool rocketfall;
    public Light l;
    private bool isstart;

    private float nextSpawnTime = 0f;
    private float baseSpawnInterval = 1.3f;
    private float spawnVariance = 0.5f;
    private float audios = 0.5f;


    IEnumerator LoadParticlesWithDelay()
    {
        yield return new WaitForSeconds(0.1f);
        ps1.Play();
        Debug.Log("ps1 запущен!");
    }

    private string[] phrases = new string[]
    {
        "1",
        "2"
    };

    void Start()
    {
        PlayerPrefs.SetInt("isfinal1g", 1);
        PlayerPrefs.SetInt("AchActive", 1);
        ach3 = PlayerPrefs.GetInt("ach3");
        
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

        UpdateObstacleCount();

        ScheduleNextSpawn();
    }

    void Update()
    {
        if (s1 && s1.activeInHierarchy) player = s1.transform;
        else if (s2 && s2.activeInHierarchy) player = s2.transform;
        else if (s3 && s3.activeInHierarchy) player = s3.transform;
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
        ad10.volume = audios / 4f;
        ad11.volume = audios;
        ad12.volume = audios / 1.5f;
        ad14.volume = audios;
        ad15.volume = audios / 1.3f;
        ad16.volume = audios;
        ad17.volume = audios;
        ad18.volume = audios;
        ad19.volume = audios;
        ad20.volume = audios;

        if (spawn >= 340 && MessagesID == 0)
        {
            text.text = "1";
            anim2.CrossFade("anim 26 1", 0.1f);
            ad9.Play();
            MessagesID++;
        }
        if (spawn >= 720 && ach3 == 0 && PlayerPrefs.GetInt("yousurwive", 0) == 0)
        {
            ach3 = 1;
            PlayerPrefs.SetInt("ach3", 1);
            achanim1.CrossFade("anim20", 0.1f);
            ad5.Play();
        }
        if (spawn >= 550 && MessagesID == 1)
        {
            string selected = phrases[UnityEngine.Random.Range(0, phrases.Length)];
            text.text = "2" + selected;
            anim2.CrossFade("anim 26 1", 0.1f);
            ad9.Play();
            MessagesID++;
        }

        if (spawn > 840)
        {
            isbtonext = true;
        }

        if (isdelay1 <= 0)
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

        score = (int)(player.position.z / 3);
        scoreText.text = (score.ToString());
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

        if (score >= PlayerPrefs.GetInt("maxScore"))
        {
            PlayerPrefs.SetInt("maxScore", (int)(player.position.z / 3));
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
        if (spawn < 250)
        {
            spawner.SetObstacleCount(2);
        }
        else if (spawn < 500)
        {
            spawner.SetObstacleCount(3);
        }
        if (spawn < 250)
        {
            omini.SetObstacleCount(4);
        }
        else if (spawn < 500)
        {
            omini.SetObstacleCount(6);
        }
    }

    public void startps()
    {
        ps.Play();
    }

    public void stopps()
    {
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
}
