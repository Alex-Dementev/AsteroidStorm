using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RDG;

public class DoubleTapHandler : MonoBehaviour
{
    public Animator abilityIconAnimator;
    public completetasks c;
    public float doubleTapThreshold = 0.5f;
    private float speed;
    private float delay;
    private float isdelay;
    public Text livet;
    public float otkat = -1;
    private float isotkat = 30;
    public float lightintens;
    public energy e;
    public RocketUniversalControl r;
    public bool b;
    public int life;
    public bool bb;
    public Slider s;
    public AudioSource AS;
    public ParticleSystem ps;
    public ParticleSystem p;
    public float isdelay1 = 2;
    public Animator anim;
    public int abilityt;
    public Light l;
    public bool bbb;
    public bool is80;
    public AudioSource ad;
    public Animator anim1;
    public int cb;
    public bool isactivateicon;
    public bool isdisactivateicon;
    public Image liveimage;

    private float lastTapTime = 0;
    private bool isWaitingForSecondTap = false;

    void Update()
    {
        otkat -= Time.deltaTime;
        s.value = otkat;
        isdelay1 -= Time.deltaTime;


        if (abilityt >= 10 && PlayerPrefs.GetInt("is10", 0) == 0)
        {
            PlayerPrefs.SetInt("is10", 1);
            c.voidcompletetasks();
        }


        if (isdelay1 >= 0)
        {
            ps.Stop();
        }

        if (b == true)
        {
            if (bb == true)
            {
                if (delay <= -0.05)
                {
                    r.zSpeed = speed;
                    r.zSpeed += 1;
                    bb = false;
                    l.intensity = lightintens;
                    if(PlayerPrefs.GetInt("isfinal1g", 0) == 0)
                    {
                        l.color = new Color(0.878f, 0.788f, 0.659f);
                    }
                    else
                    {
                        l.color = new Color(185f/255f, 155f/255f, 120f/255f);
                    }
                }
            }

            if (delay <= -0.2 && bbb)
                {
                    bbb = false;
                }

            if (delay <= -0.2)
            {
                ps.Stop();
            }

            if (delay <= -0.5)
            {
                b = false;
            }
        }

        delay -= Time.deltaTime;

        bool isTapDetected = false;

        // Мобильный ввод
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            isTapDetected = true;
        }

        // Мышка
        if (Input.GetMouseButtonDown(0))
        {
            isTapDetected = true;
        }

        // Обработка касания
        if (isTapDetected)
        {
            float currentTime = Time.time;

            if (isWaitingForSecondTap)
            {
                // Проверка на двойное нажатие
                if (currentTime - lastTapTime <= doubleTapThreshold)
                {
                    isWaitingForSecondTap = false;

                    if (otkat <= 0 && e.energyint >= 20)
                    {
                        if (PlayerPrefs.GetInt("currentTask2", -1) == 3 && e.energyint >= 80) PlayerPrefs.SetInt("abilityOver80", 1);

                        PlayerPrefs.SetInt("isabilityuse", 1);
                        b = true;
                        e.energyint -= 20;
                        abilityt++;
                        PlayerPrefs.SetInt("abilityt", abilityt);
                        speed = r.zSpeed;
                        r.zSpeed = 750;
                        delay = isdelay;
                        otkat = isotkat;
                        bb = true;
                        lightintens = l.intensity;
                        l.intensity = 1.5f;
                        bbb = true;
                        l.color = new Color(1f, 1f, 0.85f);
                        anim.Play("blue");
                        s.maxValue = isotkat;
                        isactivateicon = false;
                        isdisactivateicon = false;

                        if (PlayerPrefs.GetInt("vibration") == 0)
                        {
                            Vibration.Vibrate(50, 60);
                        }

                        ps.Play();
                        AS.Play();
                    }
                }
            }
            else
            {
                // Первый тап — запоминаем
                isWaitingForSecondTap = true;
                lastTapTime = currentTime;
            }
        }

        // Если прошло слишком много времени — сбрасываем ожидание второго тапа
        if (isWaitingForSecondTap && Time.time - lastTapTime > doubleTapThreshold)
        {
            isWaitingForSecondTap = false;
        }

        bool nowReady = otkat <= 0 && e.energyint >= 20;

        if (nowReady == true && !isactivateicon)
        {
            abilityIconAnimator.Play("anim 28 0");
            isactivateicon = true;
        }
        else if(!isdisactivateicon)
        {
            abilityIconAnimator.Play("anim 28");
            isdisactivateicon = true;
        }

    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.CompareTag("bb"))
        {
            e.energyint += 20;
            ad.Play();
            anim1.Play("green");
            if(PlayerPrefs.GetInt("currentTask2", -1) == 1)
            {
            cb = PlayerPrefs.GetInt("collectBonus", 0);
            cb++;
            PlayerPrefs.SetInt("collectBonus", cb);
            }
        }
    }

    void Start()
    {
        abilityt = PlayerPrefs.GetInt("abilityt", 0);
        isdelay = PlayerPrefs.GetFloat("isdelay");
        isotkat = PlayerPrefs.GetFloat("isotkat");
        PlayerPrefs.SetInt("isabilityuse", 0);

        if (PlayerPrefs.GetInt("audio") == 0) ad.enabled = true;
        else if (PlayerPrefs.GetInt("audio") == 1) ad.enabled = false;

        float audios = PlayerPrefs.GetFloat("audios", 0.5f);
        ad.volume = audios;

        if (PlayerPrefs.GetInt("partic") == 0)
        {
            p.Stop();
        }
    }
}
