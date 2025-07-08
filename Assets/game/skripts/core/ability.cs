using System;
using UnityEngine;
using UnityEngine.UI;
using RDG;

public class DoubleTapHandler : MonoBehaviour
{
    // Время между нажатиями для определения двойного нажатия
    public float doubleTapThreshold = 0.5f;
    private float speed;
    private float delay;
    private float isdelay;
    private float otkat;
    private float isotkat = 30;
    public energy e;
    public RocketUniversalControl r;
    public bool b;
    public bool bb;
    public Slider s;
    public AudioSource AS;
    public ParticleSystem ps;
    public ParticleSystem p;
    public float isdelay1 = 2;
    public int abilityt;

    private float lastTapTime = 0;

    void Update()
    {

        otkat -= Time.deltaTime;
        s.value = otkat;
        isdelay1 -= Time.deltaTime;

        if(isdelay1 >= 0)
        {
            ps.Stop();
        }

        if(b == true)
        {
            if(bb == true)
            {
            if(delay <= 0)
            {
            r.zSpeed = speed;
            r.zSpeed += 1;
            bb = false;
            }
            }

            if(delay <= -0.15)
            {
                ps.Stop();
            }

            if(delay <= -0.4)
            {
            b = false;
            }
        }

        delay -= Time.deltaTime;

        bool isTapDetected = false;

        // Проверяем нажатие на экран (для мобильных устройств)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            isTapDetected = true;
        }

        // Проверяем нажатие левой кнопки мыши (для ПК)
        if (Input.GetMouseButtonDown(0))
        {
            isTapDetected = true;
        }

        // Обрабатываем двойное нажатие
        if (isTapDetected)
        {
            float currentTime = Time.time;

            // Проверяем, прошло ли меньше заданного времени между нажатиями
            if (currentTime - lastTapTime <= doubleTapThreshold)
            {
                if(otkat <= 0)
                {
                    if(e.energyint >= 20)
                    {
                        b = true;
                        e.energyint -= 20;
                        abilityt++;
                        PlayerPrefs.SetInt("abilityt", abilityt);
                        speed = r.zSpeed;
                        r.zSpeed = 650;
                        delay = isdelay;
                        otkat = isotkat;
                        bb = true;
                        if (PlayerPrefs.GetInt("vibration") == 0)
                        {
                            Vibration.Vibrate(50, 60);
                        }  
                        ps.Play();
                        AS.Play();
                    }
                }
            }

            // Обновляем время последнего нажатия
            lastTapTime = currentTime;
        }
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if(Collision.gameObject.CompareTag("br"))
        {
            otkat -= 20;
        }
        if(Collision.gameObject.CompareTag("bb"))
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