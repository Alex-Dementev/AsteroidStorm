using System;
using UnityEngine;
using UnityEngine.UI;
using RDG;

public class DoubleTapHandler : MonoBehaviour
{
    private bool isAbilityReady = false;
    public Animator abilityIconAnimator;
    public completetasks c;

    public float doubleTapThreshold = 0.5f;
    private float speed;
    private float delay;
    private float isdelay;
    private float otkat;
    private float isotkat = 30;
    public float lightintens;
    public energy e;
    public RocketUniversalControl r;
    public bool b;
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
                }
            }

            if (delay <= -0.2 && bbb)
                {
                    bbb = false;
                    l.intensity = lightintens;
                    l.color = Color.white;
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
                        l.intensity = 2;
                        bbb = true;
                        l.color = new Color(1f, 1f, 0.95f);
                        anim.Play("blue");

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

if (nowReady != isAbilityReady)
{
    isAbilityReady = nowReady;

    if (isAbilityReady)
    {
        abilityIconAnimator.Play("anim 28 0");
    }
    else
    {
        abilityIconAnimator.Play("anim 28");
    }
}

    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.CompareTag("br"))
        {
            otkat -= 20;
        }
        if (Collision.gameObject.CompareTag("bb"))
        {
            e.energyint += 25;
        }
    }

    void Start()
    {
        abilityt = PlayerPrefs.GetInt("abilityt", 0);
        isdelay = PlayerPrefs.GetFloat("isdelay");
        isotkat = PlayerPrefs.GetFloat("isotkat");

        if (PlayerPrefs.GetInt("partic") == 0)
        {
            p.Stop();
        }
    }
}
