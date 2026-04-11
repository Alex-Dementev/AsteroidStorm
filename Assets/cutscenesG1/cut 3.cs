using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class cut3 : MonoBehaviour
{
    public Text t;
    public int coins;
    public int allcoins;
    public int score;
    public AudioSource ad1;
    public AudioSource ad3;
    public AudioSource ad4;
    public AudioSource Lightning;
    public float audios;
    public Animator anim;
    public Animator anim2;
    public int sus;

    void Start()
    {
        audios = PlayerPrefs.GetFloat("audios", 0.5f);
        ad1.volume = audios / 14f;
        ad3.volume = audios / 1.85f;
        ad4.volume = audios;
        Lightning.volume = audios;

        if(PlayerPrefs.GetInt("ach4", 0) == 0 && PlayerPrefs.GetInt("yousurwive", 0) == 0)
        {
        anim.Play("anim20");
        ad4.Play();
        PlayerPrefs.SetInt("ach4", 1);
        }

        if (PlayerPrefs.GetInt("audio") == 0)
        {
            ad1.enabled = true;
            ad3.enabled = true;
            ad4.enabled = true;
            Lightning.enabled = true;
        }
        else if (PlayerPrefs.GetInt("audio") == 1)
        {
            ad1.enabled = false;
            ad3.enabled = false;
            ad4.enabled = false;
            Lightning.enabled = false;
        }

        if (PlayerPrefs.GetInt("youcheat", 1) == 1)
            t.text = "Интересно. Ты здесь, но по логам тебя здесь быть не должно. Ни маршрута, ни затрат, ни нормального пути. Решил обойти всё? Без страданий действительно слаще? Только вот системы так не работают. Попробуй ещё раз. По-настоящему.";
        else if (PlayerPrefs.GetInt("yousurwive") == 1)
            t.text = "Ни урона. Ни потерь. Ни расхода топлива. Полёт будто из детской сказки. Так не бывает. Или ты спишь, или вселенная решила подыграть. В любом случае — это несерьёзно. Просыпайся.";
        else if (PlayerPrefs.GetInt("fall") == 1)
            t.text = "Говорили, что за горизонтом бесплатный вайфай. Сигнал действительно странный… будто что-то пытается ответить. Но то, что впереди, нестабильно и опасно. Рваться туда сейчас — глупость. Если вернёмся живыми, отзыв обязательно оставим. Пока назад. Нужна подготовка.";
        else
            t.text = "Это хуже, чем мы предполагали. Показатели нестабильны, гравитация ведёт себя аномально. Лезть дальше сейчас — самоубийство. Мы возвращаемся. Нужно подготовиться и понять, с чем именно имеем дело.";

        if (PlayerPrefs.GetInt("youcheat", 1) == 0 && PlayerPrefs.GetInt("yousurwive") == 0)
        {
            coins = PlayerPrefs.GetInt("coins");
            allcoins = PlayerPrefs.GetInt("allcoins");
            score = PlayerPrefs.GetInt("allscore");
            coins += 150;
            score += 2000;
            allcoins += 150;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("allcoins", allcoins);
            PlayerPrefs.SetInt("allscore", score);
            PlayerPrefs.SetInt("g1passed", 1);
        }
    }

    public void FadeAd1()
    {
        StartCoroutine(FadeOutAudio(ad1, 6f));
    }

    public void FadeAd3()
    {
        StartCoroutine(FadeOutAudio(ad3, 6f));
    }

    IEnumerator FadeOutAudio(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, time / duration);
            yield return null;
        }

        audioSource.volume = 0f;
        audioSource.Stop();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("main");
    }

    public void issus()
    {
        sus++;

        if(PlayerPrefs.GetInt("ach5", 0) == 0 && sus == 80 && PlayerPrefs.GetInt("yousurwive", 0) == 0)
        {
            PlayerPrefs.SetInt("ach5", 1);
            anim2.Play("anim20");
            ad4.Play();
        }
    }
}
