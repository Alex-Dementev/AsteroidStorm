using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RDG;

public class DoubleTapHandler : MonoBehaviour
{
    // === ЦЕНЫ СПОСОБНОСТЕЙ ===
    public int costAbility1 = 15;
    public int costAbility2 = 5;
    public int costAbility3 = 10;
    public int costAbility4 = 35;

    // === ИКОНКИ (новые 4 аниматора) ===
    public Animator ability1Animator;
    public Animator ability2Animator;
    public Animator ability3Animator;
    public Animator ability4Animator;

    bool state1Ready = false;
    bool state2Ready = false;
    bool state3Ready = false;
    bool state4Ready = false;

    public BoxCollider coll;

    private Vector3 sizedpaste;
    private Vector3 sized;

    // === Старые переменные ===
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

    public Vector2 startTouchPos;
    public Vector2 endTouchPos;
    public float lastSwipeUpTime = 0f;
    public bool waitingSecondSwipeUp = false;
    public float swipeThreshold = 180f;
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a4;

    private float ShakeSkan;

    public GameObject prefab;
    public Transform spawnTransform;

    private Coroutine waitSecondSwipeCoroutine;

    void Start()
    {
        var main = p.main;
        main.startSize = PlayerPrefs.GetInt("ScannerLenght", 200);
        
        PlayerPrefs.SetInt("activeShield", 0);
        abilityt = PlayerPrefs.GetInt("abilityt", 0);
        isdelay = PlayerPrefs.GetFloat("isdelay");
        isotkat = PlayerPrefs.GetFloat("isotkat");
        PlayerPrefs.SetInt("isabilityuse", 0);

        if(PlayerPrefs.GetInt("GyperJump", 0) == 0)
            a1.SetActive(false);
        if(PlayerPrefs.GetInt("Scanner", 0) == 0)
            a2.SetActive(false);
        if(PlayerPrefs.GetInt("Shield", 0) == 0)
            a3.SetActive(false);
        if(PlayerPrefs.GetInt("Projectile", 0) == 0)
            a4.SetActive(false);

        isotkat = PlayerPrefs.GetInt("GyperJumpOtkat");
        isotkat2 = PlayerPrefs.GetInt("ScannerOtkat");
        isotkat3 = PlayerPrefs.GetInt("ShieldOtkat");
        isotkat4 = PlayerPrefs.GetInt("ProjectileOtkat");
        costAbility1 = PlayerPrefs.GetInt("GyperJumpEnergy");
        costAbility2 = PlayerPrefs.GetInt("ScannerEnergy");
        costAbility3 = PlayerPrefs.GetInt("ShieldEnergy");
        costAbility4 = PlayerPrefs.GetInt("ProjectileEnergy");

        if (PlayerPrefs.GetInt("audio") == 0) ad.enabled = true;
        else ad.enabled = false;

        float audios = PlayerPrefs.GetFloat("audios", 0.5f);
        ad.volume = audios;

        if (PlayerPrefs.GetInt("partic") == 0)
            ps.Stop();
    }

    void Update()
    {
        // === Откаты ===
        otkat -= Time.deltaTime;
        otkat2 -= Time.deltaTime;
        otkat3 -= Time.deltaTime;
        otkat4 -= Time.deltaTime;

        s.value = otkat;
        s2.value = otkat2;
        s3.value = otkat3;
        s4.value = otkat4;

        isdelay1 -= Time.deltaTime;
        isdelayShield -= Time.deltaTime;

        if(otkat2 > 0 && PlayerPrefs.GetInt("ShakePhone", 0) == 1 && PlayerPrefs.GetInt("Ach3Level", 0) == 0 && PlayerPrefs.GetInt("Ach3Level", 0) == 2)
        {
            ShakeSkan += Time.deltaTime;
            if(ShakeSkan >= 2)
                PlayerPrefs.SetInt("ShakePhone", 1);
        }
        else if(otkat2 <= 0)
            ShakeSkan = 0;

        if(transform.position.z >= 3200)
        {
            var main = p.main;
            main.startSize = 1800;

            if(PlayerPrefs.GetInt("MoonScanned", 0) == 0 && transform.position.z >= 3300 && s2.maxValue >= 4)
            PlayerPrefs.SetInt("MoonScanned", 1);
        }

        UpdateAbilityIcons();   

        HandleShield();
        HandleBoost();
        DetectTouchesAndSwipes();
    }

    // ======================================================
    // === ОБНОВЛЕНИЕ ИКОНОК ===
    // ======================================================
    void UpdateAbilityIcons()
    {
        bool ready1 = otkat <= 0 && e.energyint >= costAbility1;
        bool ready2 = otkat2 <= 0 && e.energyint >= costAbility2;
        bool ready3 = otkat3 <= 0 && e.energyint >= costAbility3;
        bool ready4 = otkat4 <= 0 && e.energyint >= costAbility4;

        if (ready1 != state1Ready)
        {
            state1Ready = ready1;
            if (ready1) ability1Animator.CrossFade("anim 28 0", 0.1f);
            else ability1Animator.CrossFade("anim 28", 0.1f);
        }

        if (ready2 != state2Ready)
        {
            state2Ready = ready2;
            if (ready2) ability2Animator.CrossFade("SkannerStart", 0.1f);
            else ability2Animator.CrossFade("SkannerIdle", 0.1f);
        }

        if (ready3 != state3Ready)
        {
            state3Ready = ready3;
            if (ready3) ability3Animator.CrossFade("ShieldStart", 0.1f);
            else ability3Animator.CrossFade("ShieldIdle", 0.1f);
        }

        if (ready4 != state4Ready)
        {
            state4Ready = ready4;
            if (ready4) ability4Animator.CrossFade("ProgectileStart", 0.1f);
            else ability4Animator.CrossFade("ProgectileIdle", 0.1f);
        }
    }

    // ======================================================
    // ===  ОБРАБОТКА КАСАНИЙ / СВАЙПОВ  ===
    // ======================================================

    void DetectTouchesAndSwipes()
    {
        bool wasSwipe = DetectSwipe();
        bool isTapDetected = false;

        if (!wasSwipe)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                isTapDetected = true;

            if (Application.isEditor && Input.GetMouseButtonDown(0))
                isTapDetected = true;
        }
        else
        {
            isWaitingForSecondTap = false;
            lastTapTime = -1f;
        }

        if (isTapDetected)
        {
            float time = Time.time;

            if (isWaitingForSecondTap)
            {
                if (time - lastTapTime <= doubleTapThreshold)
                {
                    isWaitingForSecondTap = false;
                    ActivateAbilityGiperAttack();
                }
            }
            else
            {
                isWaitingForSecondTap = true;
                lastTapTime = time;
            }
        }

        if (isWaitingForSecondTap && Time.time - lastTapTime > doubleTapThreshold)
            isWaitingForSecondTap = false;
    }

    bool DetectSwipe()
    {
        bool didSwipe = false;

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
                startTouchPos = t.position;

            else if (t.phase == TouchPhase.Ended)
            {
                endTouchPos = t.position;
                Vector2 delta = endTouchPos - startTouchPos;

                if (Mathf.Abs(delta.y) > Mathf.Abs(delta.x) && Mathf.Abs(delta.y) > swipeThreshold)
                {
                    didSwipe = true;
                    isWaitingForSecondTap = false;

                    if (delta.y > 0) OnSwipeUp();
                    else OnSwipeDown();
                }
            }
        }

        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
                startTouchPos = Input.mousePosition;

            if (Input.GetMouseButtonUp(0))
            {
                endTouchPos = Input.mousePosition;
                Vector2 delta = endTouchPos - startTouchPos;

                if (Mathf.Abs(delta.y) > Mathf.Abs(delta.x) && Mathf.Abs(delta.y) > swipeThreshold)
                {
                    didSwipe = true;
                    isWaitingForSecondTap = false;

                    if (delta.y > 0) OnSwipeUp();
                    else OnSwipeDown();
                }
            }
        }

        return didSwipe;
    }

    void OnSwipeUp()
    {
        float time = Time.time;

        if (waitingSecondSwipeUp)
        {
            if (time - lastSwipeUpTime <= doubleTapThreshold)
            {
                waitingSecondSwipeUp = false;

                if (waitSecondSwipeCoroutine != null)
                    StopCoroutine(waitSecondSwipeCoroutine);

                if (otkat4 <= 0 && e.energyint >= costAbility4)
                    ActivateDoubleSwipeUpAbility();
            }
        }
        else
        {
            waitingSecondSwipeUp = true;
            lastSwipeUpTime = time;

            if (waitSecondSwipeCoroutine != null)
                StopCoroutine(waitSecondSwipeCoroutine);

            waitSecondSwipeCoroutine = StartCoroutine(WaitForSecondSwipeUp());
        }
    }

    IEnumerator WaitForSecondSwipeUp()
    {
        float timer = 0f;

        while (timer < doubleTapThreshold)
        {
            timer += Time.deltaTime;
            yield return null;

            if (!waitingSecondSwipeUp)
                yield break;
        }

        waitingSecondSwipeUp = false;

        if (otkat2 <= 0 && e.energyint >= costAbility2)
            ActivateSwipeUpAbility();
    }

    void OnSwipeDown()
    {
        if (otkat3 <= 0 && e.energyint >= costAbility3)
            ActivateSwipeDownAbility();
    }

    // ======================================================
    // === АКТИВАЦИЯ СПОСОБНОСТЕЙ ===
    // ======================================================

    public void ActivateAbilityGiperAttack()
    {
        if (otkat > 0 || e.energyint < costAbility1) return;

        if(PlayerPrefs.GetInt("GyperJump", 0) == 1)
        {
            PlayerPrefs.SetInt("isabilityuse", 1);
            b = true;
            e.energyint -= costAbility1;
            abilityt++;
            PlayerPrefs.SetInt("abilityt", abilityt);
            speed = r.zSpeed;
            r.zSpeed = 500;
            delay = isdelay;
            otkat = isotkat;
            bb = true;
            sized = coll.size;
            sizedpaste = coll.size;
            sized.x *= 1.5f;
            sized.y *= 1.5f;
            coll.size = sized;
            lightintens = l.intensity;
            l.intensity = 1.5f;
            l.color = new Color(1f, 1f, 0.85f);
            anim.CrossFade("blue", 0.1f);
            s.maxValue = isotkat;
            effect.CrossFade("slide lr", 0.1f);
            ps.Play();
            GiperAttackAS.Play();

            if (PlayerPrefs.GetInt("vibration") == 0)
            {
                Vibration.Vibrate(100, 35);
            }
        }
    }

    public void ActivateSwipeUpAbility()
    {
        if (otkat2 > 0 || e.energyint < costAbility2) return;

        if(PlayerPrefs.GetInt("Scanner", 0) == 1)
        {
            PlayerPrefs.SetInt("isabilityuse", 1);
            Skanner.Play();
            e.energyint -= costAbility2;
            abilityt++;
            PlayerPrefs.SetInt("abilityt", abilityt);
            otkat2 = isotkat2;
            anim.CrossFade("blue", 0.1f);
            s2.maxValue = isotkat2;
            effect.CrossFade("slide lr", 0.1f);
            SkanerAS.Play();

            if(PlayerPrefs.GetInt("Ach3Level", 0) == 1)
            {
                int Count;

                Count = PlayerPrefs.GetInt("CountScan", 0);
                Count++;
                PlayerPrefs.SetInt("CountScan", Count);

                if(Count >= 4)
                    PlayerPrefs.SetInt("Ach3Level", 2);
            }

            if (PlayerPrefs.GetInt("vibration") == 0)
            {
                Vibration.Vibrate(100, 35);
            }
        }
    }

    public void ActivateSwipeDownAbility()
    {
        if (otkat3 > 0 || e.energyint < costAbility3) return;

        if(PlayerPrefs.GetInt("Shield", 0) == 1)
        {
            PlayerPrefs.SetInt("isabilityuse", 1);
            e.energyint -= costAbility3;
            abilityt++;
            PlayerPrefs.SetInt("activeShield", 1);
            isdelayShield = 5;
            isActiveShield = true;
            PlayerPrefs.SetInt("abilityt", abilityt);
            otkat3 = isotkat3;
            anim.CrossFade("blue", 0.1f);
            s3.maxValue = isotkat3;
            effect.CrossFade("slide lr", 0.1f);
            ShieldAS.Play();
            ShieldAnim.CrossFade("startShield", 0.1f);

            if (PlayerPrefs.GetInt("vibration") == 0)
            {
                Vibration.Vibrate(100, 35);
            }
        }
    }

    public void ActivateDoubleSwipeUpAbility()
    {
        if (otkat4 > 0 || e.energyint < costAbility4) return;

        if(PlayerPrefs.GetInt("Projectile", 0) == 1)
        {
            PlayerPrefs.SetInt("isabilityuse", 1);
            e.energyint -= costAbility4;
            abilityt++;
            PlayerPrefs.SetInt("abilityt", abilityt);
            otkat4 = isotkat4;
            Instantiate(prefab, spawnTransform.position, prefab.transform.rotation);
            anim.CrossFade("blue", 0.1f);
            s4.maxValue = isotkat4;
            effect.CrossFade("slide lr", 0.1f);
            AttackAS.Play();

            if (PlayerPrefs.GetInt("vibration") == 0)
            {
                Vibration.Vibrate(200, 65);
            }
        }
    }

    // === Щиты и бусты ===

    void HandleShield()
    {
        if (isActiveShield && isdelayShield <= 0 && PlayerPrefs.GetInt("activeShield") == 1)
        {
            isActiveShield = false;
            ShieldEndAS.Play();
            ShieldAnim.CrossFade("endShield", 0.1f);
            isActiveShield2 = true;
        }

        if (isActiveShield && isdelayShield <= -0.3f && isActiveShield2)
        {
            isActiveShield2 = false;
            PlayerPrefs.SetInt("activeShield", 0);
        }
    }

    void HandleBoost()
    {
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
                    sized.x = sizedpaste.x;
                    sized.y = sizedpaste.y;
                    coll.size = sized;
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
    }
}
