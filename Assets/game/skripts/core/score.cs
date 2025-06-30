using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RDG;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] public Transform player;

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    public GameObject image;
    public Text scoreText;
    public sceneman s;
    public int score;
    public AudioSource ad1;
    public AudioSource ad2;
    public AudioSource ad3;
    public AudioSource ad4;
    public ObstacleSpawner o;
    public ObstaclearSpawner oar;
    public int spawn;
    public float function;
    public float isdelay;
    public float isdelay1;
    private float isdelay2 = 1;
    public float isminus;
    public SmoothSkyboxSwitcher ss;
    public ParticleSystem ps;
    public bool isbportal;
    private int ars = 300;
    public int ach1;
    public int ach2;
    public Animator achanim1;
    public Animator achanim2;
    public AudioSource AS;
    public Animator anim;

    void Start()
    {
        isminus = 25;

        // Выбираем активного игрока (скин)
        if (s1 && s1.activeInHierarchy) player = s1.transform;
        else if (s2 && s2.activeInHierarchy) player = s2.transform;
        else if (s3 && s3.activeInHierarchy) player = s3.transform;
        else if (s4 && s4.activeInHierarchy) player = s4.transform;

        ach1 = PlayerPrefs.GetInt("1.5kscore", 0);
        ach2 = PlayerPrefs.GetInt("450score", 0);

        anim.Play("anim6");
    }

    void Update()
    {
        // Проверка активного скина — на случай если он сменится во время игры
        if (s1 && s1.activeInHierarchy) player = s1.transform;
        else if (s2 && s2.activeInHierarchy) player = s2.transform;
        else if (s3 && s3.activeInHierarchy) player = s3.transform;
        else if (s4 && s4.activeInHierarchy) player = s4.transform;

        if (player == null) return;

        isdelay1 -= Time.deltaTime;
        isdelay -= Time.deltaTime;
        isdelay2 -= Time.deltaTime;

        if (isdelay1 <= 0)
        {
            image.SetActive(!image.activeSelf);
            isdelay1 = 99999;
        }

        if (isdelay <= 0)
        {
            if (isminus >= 5)
            {
                isdelay = 25f;
                isminus -= 1f;
            }
        }

        if(ach1 == 0 && spawn >= 1500)
        {
            PlayerPrefs.SetInt("1.5kscore", 1);
            ach1 = 1;
            achanim2.Play("anim 21");
            AS.Play();
        }
        if(ach2 == 0 && spawn >= 500)
        {
            PlayerPrefs.SetInt("450score", 1);
            ach2 = 1;
            achanim1.Play("anim20");
            AS.Play();
        }

        if (isdelay2 >= 0)
        {
            ps.Stop();
        }

        score = ((int)(player.position.z / 3));
        scoreText.text = (score.ToString());
        spawn = ((int)(player.position.z) / 3);

        if (spawn >= function)
        {
            function += isminus;
            if (!isbportal)
            {
                o.SpawnObstacles();
            }
        }

        if (spawn >= 3500)
        {
            o.spawnDistance = -200;
            oar.spawnDistance = -350;
        }
        if (spawn >= 7000)
        {
            o.spawnDistance = -300;
            oar.spawnDistance = -550;
        }
        if (spawn >= 10000)
        {
            o.spawnDistance = -420;
            oar.spawnDistance = -700;
        }
        if (spawn >= 6000)
        {
            ss.SwitchToNight();
        }

        if (score >= s.maxScore)
        {
            s.maxScore = ((int)(player.position.z / 3));
        }

        scoreText.text = "" + score;

        if (PlayerPrefs.GetInt("audio") == 0)
        {
            ad1.enabled = true;
            ad2.enabled = true;
            ad3.enabled = true;
            ad4.enabled = true;
            AS.enabled = true;
        }
        else if (PlayerPrefs.GetInt("audio") == 1)
        {
            ad1.enabled = false;
            ad2.enabled = false;
            ad3.enabled = false;
            ad4.enabled = false;
            AS.enabled = false;
        }

        if (spawn == ars)
        {
            ars += 250;
            oar.SpawnObstaclesar();
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
        ad2.Play();
    }

    public void ad3end()
    {
        ad3.Play();
    }
}
