using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RDG;

public class DoubleTapHandler : MonoBehaviour
{
    // --- ЦЕНЫ СПОСОБНОСТЕЙ ---
    public int costAbility1 = 15;  // Двойной тап — гиператака
    public int costAbility2 = 5;  // Свайп вверх
    public int costAbility3 = 10;  // Свайп вниз
    public int costAbility4 = 35;  // Двойной свайп вверх

    public Animator abilityIconAnimator;
    public completetasks c;
    public float doubleTapThreshold = 0.5f;
    public float speed;
    public float delay;
    public float isdelay;
    public Text livet;

    public float otkat = -1;
    public float isotkat = 20;

    public float otkat2 = -1;
    public float isotkat2 = 10;

    public float otkat3 = -1;
    public float isotkat3 = 10;

    public float otkat4 = -1;
    public float isotkat4 = 30;

    public float lightintens;
    public energy e;
    public RocketUniversalControl r;
    public bool b;
    public int life;
    public bool bb;
    public Slider s;
    public Slider s2;
    public Slider s3;
    public Slider s4;
    public AudioSource GiperAttackAS;
    public AudioSource SkanerAS;
    public AudioSource ShieldAS;
    public AudioSource AttackAS;
    public ParticleSystem ps;
    public ParticleSystem p;
    public float isdelay1 = 2;
    public Animator anim;
    public int abilityt;
    public Light l;
    public bool is80;
    public AudioSource ad;
    public Animator anim1;
    public int cb;
    public bool isactivateicon;
    public bool isdisactivateicon;
    public Image liveimage;
    public Animator effect;
    public ParticleSystem Skanner;
    public float isdelayShield;
    public bool isActiveShield;
    public bool isActiveShield2;
    public AudioSource ShieldEndAS;
    public Animator ShieldAnim;

    public float lastTapTime = 0;
    public bool isWaitingForSecondTap = false;

    // --- Для свайпов ---
    public Vector2 startTouchPos;
    public Vector2 endTouchPos;
    public float lastSwipeUpTime = 0f;
    public bool waitingSecondSwipeUp = false;
    public float swipeThreshold = 180f; // чувствительность свайпа

    void Update()
    {
        otkat -= Time.deltaTime;
        otkat2 -= Time.deltaTime;
        otkat3 -= Time.deltaTime;
        otkat4 -= Time.deltaTime;
        isdelayShield -= Time.deltaTime;

        s.value = otkat;
        s2.value = otkat2;
        s3.value = otkat3;
        s4.value = otkat4;
        isdelay1 -= Time.deltaTime;

        if(isActiveShield && isdelayShield <= 0 && PlayerPrefs.GetInt("activeShield") == 1)
        {
            isActiveShield = false;
            ShieldEndAS.Play();
            ShieldAnim.Play("endShield");
            isActiveShield2 = true;
        }
        if(isActiveShield && isdelayShield <= -0.3f && isActiveShield2)
        {
            isActiveShield2 = false;
            PlayerPrefs.SetInt("activeShield", 0);
        }

        if (abilityt >= 10 && PlayerPrefs.GetInt("is10", 0) == 0)
        {
            PlayerPrefs.SetInt("is10", 1);
            c.voidcompletetasks();
        }

        if (isdelay1 >= 0)
            ps.Stop();

        if (b)
        {
            if (bb)
            {
                if (delay <= -0.05)
                {
                    r.zSpeed = speed;
                    r.zSpeed += 1;
                    bb = false;
                    l.intensity = lightintens;
                    if (PlayerPrefs.GetInt("isfinal1g", 0) == 0)
                        l.color = new Color(0.878f, 0.788f, 0.659f);
                    else
                        l.color = new Color(238f / 255f, 211f / 255f, 179f / 255f);
                }
            }

            if (delay <= -0.2)
                ps.Stop();

            if (delay <= -0.5)
                b = false;
        }

        delay -= Time.deltaTime;

        // --- Проверка свайпов ---
        bool wasSwipe = DetectSwipe(); // теперь возвращает bool

        // --- Проверка на клик ---
        bool isTapDetected = false;

        if (!wasSwipe) // если свайпа не было — считаем тап
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                isTapDetected = true;

            if (Application.isEditor && Input.GetMouseButtonDown(0))
                isTapDetected = true;
        }
        else
        {
            // если был свайп — сбрасываем возможный первый тап
            isWaitingForSecondTap = false;
            lastTapTime = -1f;
        }

        if (isTapDetected)
        {
            float currentTime = Time.time;

            if (isWaitingForSecondTap)
            {
                if (currentTime - lastTapTime <= doubleTapThreshold)
                {
                    isWaitingForSecondTap = false;
                    ActivateAbilityGiperAttack(); // способность 1
                }
            }
            else
            {
                isWaitingForSecondTap = true;
                lastTapTime = currentTime;
            }
        }

        if (isWaitingForSecondTap && Time.time - lastTapTime > doubleTapThreshold)
            isWaitingForSecondTap = false;

        // --- Иконка готовности ---
        bool nowReady = otkat <= 0 && e.energyint >= costAbility1;

        if (nowReady && !isactivateicon)
        {
            abilityIconAnimator.Play("anim 28 0");
            isactivateicon = true;
        }
        else if (!isdisactivateicon)
        {
            abilityIconAnimator.Play("anim 28");
            isdisactivateicon = true;
        }
    }

    // --- Универсальный свайп ---
    bool DetectSwipe()
    {
        bool didSwipe = false;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                startTouchPos = touch.position;

            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPos = touch.position;
                Vector2 swipeDelta = endTouchPos - startTouchPos;

                if (Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x) && Mathf.Abs(swipeDelta.y) > swipeThreshold)
                {
                    didSwipe = true;
                    isWaitingForSecondTap = false; // сброс клика
                    lastTapTime = -1f; // обнуление
                    if (swipeDelta.y > 0)
                        OnSwipeUp();
                    else
                        OnSwipeDown();
                }
            }
        }

        // --- Для редактора ---
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
                startTouchPos = Input.mousePosition;

            if (Input.GetMouseButtonUp(0))
            {
                endTouchPos = Input.mousePosition;
                Vector2 swipeDelta = endTouchPos - startTouchPos;

                if (Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x) && Mathf.Abs(swipeDelta.y) > swipeThreshold)
                {
                    didSwipe = true;
                    isWaitingForSecondTap = false;
                    lastTapTime = -1f;
                    if (swipeDelta.y > 0)
                        OnSwipeUp();
                    else
                        OnSwipeDown();
                }
            }
        }

        return didSwipe;
    }

    void OnSwipeUp()
    {
        float currentTime = Time.time;

        if (waitingSecondSwipeUp)
        {
            // Второй свайп — активируем способность 4
            if (currentTime - lastSwipeUpTime <= doubleTapThreshold)
            {
                waitingSecondSwipeUp = false;

                if (waitSecondSwipeCoroutine != null)
                    StopCoroutine(waitSecondSwipeCoroutine);

                if (otkat4 <= 0 && e.energyint >= costAbility4)
                    ActivateDoubleSwipeUpAbility(); // способность 4
            }
        }
        else
        {
            // Первый свайп — ждём второй
            waitingSecondSwipeUp = true;
            lastSwipeUpTime = currentTime;

            if (waitSecondSwipeCoroutine != null)
                StopCoroutine(waitSecondSwipeCoroutine);

            waitSecondSwipeCoroutine = StartCoroutine(WaitForSecondSwipeUp());
        }
    }

    private Coroutine waitSecondSwipeCoroutine;

    IEnumerator WaitForSecondSwipeUp()
    {
        float timer = 0f;
        waitingSecondSwipeUp = true;

        while (timer < doubleTapThreshold)
        {
            timer += Time.deltaTime;
            yield return null;

            if (!waitingSecondSwipeUp)
                yield break; // если был второй свайп — выходим
        }

        // если второго свайпа не было — запускаем способность 2
        waitingSecondSwipeUp = false;

        if (otkat2 <= 0 && e.energyint >= costAbility2)
            ActivateSwipeUpAbility(); // способность 2
    }



    void OnSwipeDown()
    {
        if (otkat3 <= 0 && e.energyint >= costAbility3)
            ActivateSwipeDownAbility(); // способность 3
    }

    void OnDoubleSwipeUp()
    {
        if (otkat4 <= 0 && e.energyint >= costAbility4)
            ActivateDoubleSwipeUpAbility(); // способность 4
    }

    // --- СПОСОБНОСТЬ 1 ---
    public void ActivateAbilityGiperAttack()
    {
        if (otkat > 0 || e.energyint < costAbility1) return;

        PlayerPrefs.SetInt("isabilityuse", 1);
        b = true;
        e.energyint -= costAbility1;
        abilityt++;
        PlayerPrefs.SetInt("abilityt", abilityt);
        speed = r.zSpeed;
        r.zSpeed = 750;
        delay = isdelay;
        otkat = isotkat;
        bb = true;
        lightintens = l.intensity;
        l.intensity = 1.5f;
        l.color = new Color(1f, 1f, 0.85f);
        anim.Play("blue");
        s.maxValue = isotkat;
        effect.Play("slide lr");
        ps.Play();
        GiperAttackAS.Play();
    }

    public void ActivateSwipeUpAbility()
    {
        if (otkat2 > 0 || e.energyint < costAbility2) return;

        PlayerPrefs.SetInt("isabilityuse", 1);
        Skanner.Play();
        e.energyint -= costAbility2;
        abilityt++;
        PlayerPrefs.SetInt("abilityt", abilityt);
        otkat2 = isotkat2;
        anim.Play("blue");
        s2.maxValue = isotkat2;
        effect.Play("slide lr");
        SkanerAS.Play();
    }

    public void ActivateSwipeDownAbility()
    {
        if (otkat3 > 0 || e.energyint < costAbility3) return;

        PlayerPrefs.SetInt("isabilityuse", 1);
        e.energyint -= costAbility3;
        abilityt++;
        PlayerPrefs.SetInt("activeShield", 1);
        isdelayShield = 5;
        isActiveShield = true;
        PlayerPrefs.SetInt("abilityt", abilityt);
        otkat3 = isotkat3;
        anim.Play("blue");
        s3.maxValue = isotkat3;
        effect.Play("slide lr");
        ShieldAS.Play();
        ShieldAnim.Play("startShield");
    }

    public void ActivateDoubleSwipeUpAbility()
    {
        if (otkat4 > 0 || e.energyint < costAbility4) return;

        PlayerPrefs.SetInt("isabilityuse", 1);
        e.energyint -= costAbility4;
        abilityt++;
        PlayerPrefs.SetInt("abilityt", abilityt);
        otkat4 = isotkat4;
        anim.Play("blue");
        s4.maxValue = isotkat4;
        effect.Play("slide lr");
        AttackAS.Play();
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.CompareTag("bb"))
        {
            e.energyint += 20;
            ad.Play();
            anim1.Play("green");
            Destroy(Collision.gameObject);
            if (PlayerPrefs.GetInt("currentTask2", -1) == 1)
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
            p.Stop();
    }
}
