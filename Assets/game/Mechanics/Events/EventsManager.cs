using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class EventsManager : MonoBehaviour
{
    public GameObject Panel;
    public Animator PanelAnim;
    public Text PanelText;
    private float Delay;
    public Text ButtonText;

    void Update()
    {
        Delay -= Time.deltaTime;

        if(Delay <= 0)
            Events();
    }

    public void Events()
    {
        if ((System.DateTime.Now.Month == 12 && System.DateTime.Now.Day >= 25) || (System.DateTime.Now.Month == 1 && System.DateTime.Now.Day <= 7))
        {
            if(System.DateTime.Now.Year > PlayerPrefs.GetInt("Is1Event", 0))
            {
                Panel.SetActive(true);
                PanelText.text = "С наступающим! В честь грядущего праздника мы дарим тебе новый скин ракеты!";
            }
        }

        if (System.DateTime.Now.Month == 4 && System.DateTime.Now.Day == 1 && System.DateTime.Now.Year > PlayerPrefs.GetInt("Is2Event", 0))
        {
            int random = UnityEngine.Random.Range(15, 26);
            random *= 10000;
            Panel.SetActive(true);
            PanelText.text = "Сегодня у меня хорошее настроение, поэтому мы дарим вам: " + random;
        }

        if (System.DateTime.Now.Month == 3 && System.DateTime.Now.Day == 30 && System.DateTime.Now.Year > PlayerPrefs.GetInt("Is3Event", 0))
        {
            Panel.SetActive(true);
            PanelText.text = "С днем рождения Argonaft228!";
            ButtonText.text = "Поздравить";
        }
        if (System.DateTime.Now.Month == 10 && System.DateTime.Now.Day == 21 && System.DateTime.Now.Year > PlayerPrefs.GetInt("Is4Event", 0))
        {
            Panel.SetActive(true);
            PanelText.text = "С днем рождения DemonAlex!";
            ButtonText.text = "Поздравить";
        }

        if (System.DateTime.Now.Month == 4 && System.DateTime.Now.Day == 12 && System.DateTime.Now.Year > PlayerPrefs.GetInt("Is4Event", 0))
        {
            Panel.SetActive(true);
            PanelText.text = "Сегодня международный день космонавтики!";
            ButtonText.text = "Хорошо";
        }


        Delay = 5;
    }

    public void UpdateEventTrigger()
    {
        if ((System.DateTime.Now.Month == 12 && System.DateTime.Now.Day >= 25) || (System.DateTime.Now.Month == 1 && System.DateTime.Now.Day <= 7))
        {
            PlayerPrefs.SetInt("Skin2", 1);
            PlayerPrefs.SetInt("Is1Event", System.DateTime.Now.Year);
        }

        if (System.DateTime.Now.Month == 3 && System.DateTime.Now.Day == 30)
        {
            PlayerPrefs.SetInt("Is3Event", System.DateTime.Now.Year);
        }
        if (System.DateTime.Now.Month == 10 && System.DateTime.Now.Day == 21)
        {
            PlayerPrefs.SetInt("Is4Event", System.DateTime.Now.Year);
        }

        if (System.DateTime.Now.Month == 4 && System.DateTime.Now.Day == 12)
        {
            PlayerPrefs.SetInt("Is4Event", System.DateTime.Now.Year);
        }

        if (System.DateTime.Now.Month == 4 && System.DateTime.Now.Day == 1)
        {
            PlayerPrefs.SetInt("Is2Event", System.DateTime.Now.Year);
            PanelText.text = "Шучу!";
        }

        PanelAnim.Play("End");
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        StartCoroutine(HalfSecondDelay());
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(HalfSecondDelay());
    }

    public void ActivateObjects()
    {
        int month = System.DateTime.Now.Month;
        int day = System.DateTime.Now.Day;
        Debug.Log("Переход");

        GameObject go1;
        GameObject go2;
        GameObject go3;
        GameObject go4;
        GameObject go5;

        // 23 февраля
        if (!(month == 2 && day == 23))
        {
            go1 = GameObject.Find("M11");
            go2 = GameObject.Find("M21");
            go3 = GameObject.Find("M31");
            go4 = GameObject.Find("M41");
            go5 = GameObject.Find("M51");

            if (go1 != null) go1.SetActive(false);
            if (go2 != null) go2.SetActive(false);
            if (go3 != null) go3.SetActive(false);
            if (go4 != null) go4.SetActive(false);
            if (go5 != null) go5.SetActive(false);
        }

        // 8 марта
        if (!(month == 3 && day == 8))
        {
            go1 = GameObject.Find("M12");
            go2 = GameObject.Find("M22");
            go3 = GameObject.Find("M32");
            go4 = GameObject.Find("M42");
            go5 = GameObject.Find("M52");

            if (go1 != null) go1.SetActive(false);
            if (go2 != null) go2.SetActive(false);
            if (go3 != null) go3.SetActive(false);
            if (go4 != null) go4.SetActive(false);
            if (go5 != null) go5.SetActive(false);
        }

        // 30 марта
        if (!(month == 3 && day == 30) && !(month == 10 && day == 21))
        {
            go1 = GameObject.Find("M15");
            go2 = GameObject.Find("M25");
            go3 = GameObject.Find("M35");
            go4 = GameObject.Find("M45");
            go5 = GameObject.Find("M55");

            if (go1 != null) go1.SetActive(false);
            if (go2 != null) go2.SetActive(false);
            if (go3 != null) go3.SetActive(false);
            if (go4 != null) go4.SetActive(false);
            if (go5 != null) go5.SetActive(false);
        }

        // 31 октября
        if (!(month == 10 && day == 31))
        {
            go1 = GameObject.Find("M16");
            go2 = GameObject.Find("M26");
            go3 = GameObject.Find("M36");
            go4 = GameObject.Find("M46");
            go5 = GameObject.Find("M56");

            if (go1 != null) go1.SetActive(false);
            if (go2 != null) go2.SetActive(false);
            if (go3 != null) go3.SetActive(false);
            if (go4 != null) go4.SetActive(false);
            if (go5 != null) go5.SetActive(false);
        }

        // 1–3 ноября
        if (!(month == 11 && day >= 1 && day <= 3))
        {
            go1 = GameObject.Find("M13");
            go2 = GameObject.Find("M23");
            go3 = GameObject.Find("M33");
            go4 = GameObject.Find("M43");
            go5 = GameObject.Find("M53");

            if (go1 != null) go1.SetActive(false);
            if (go2 != null) go2.SetActive(false);
            if (go3 != null) go3.SetActive(false);
            if (go4 != null) go4.SetActive(false);
            if (go5 != null) go5.SetActive(false);
        }

        // Новый год (25 декабря – 7 января)
        if (!((month == 12 && day >= 25) || (month == 1 && day <= 7)))
        {
            go1 = GameObject.Find("M14");
            go2 = GameObject.Find("M24");
            go3 = GameObject.Find("M34");
            go4 = GameObject.Find("M44");
            go5 = GameObject.Find("M54");

            if (go1 != null) go1.SetActive(false);
            if (go2 != null) go2.SetActive(false);
            if (go3 != null) go3.SetActive(false);
            if (go4 != null) go4.SetActive(false);
            if (go5 != null) go5.SetActive(false);
        }
    }

    IEnumerator HalfSecondDelay()
    {
        yield return new WaitForSeconds(0.05f);

        ActivateObjects();
    }
}
