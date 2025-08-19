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
    public AudioSource ad2;
    public AudioSource ad3;
    public AudioSource ad4;
    public float audios;
    public Animator anim;
    public Animator anim2;
    public int sus;

    void Start()
    {
        audios = PlayerPrefs.GetFloat("audios", 0.5f);
        ad1.volume = audios / 14f;
        ad2.volume = audios / 1.25f;
        ad3.volume = audios / 1.5f;
        ad4.volume = audios;

        if(PlayerPrefs.GetInt("ach4", 0) == 0)
        {
        anim.Play("anim20");
        ad4.Play();
        PlayerPrefs.SetInt("ach4", 1);
        }

        if (PlayerPrefs.GetInt("audio") == 0)
        {
            ad1.enabled = true;
            ad2.enabled = true;
            ad3.enabled = true;
            ad4.enabled = true;
        }
        else if (PlayerPrefs.GetInt("audio") == 1)
        {
            ad1.enabled = false;
            ad2.enabled = false;
            ad3.enabled = false;
            ad4.enabled = false;
        }

        if (PlayerPrefs.GetInt("youcheat", 1) == 1)
            t.text = "А без страданий слаще, да?";
        else if (PlayerPrefs.GetInt("yousurwive") == 1)
            t.text = "Сюжет первой главы пройден. Сложность — 'пижамная'.";
        else if (PlayerPrefs.GetInt("fall") == 1)
            t.text = "Кто-то говорил, что за чёрной дырой — бесплатный вайфай. Если выживу — напишу отзыв. Прыгаю в бездну с лицом из пикселей.";
        else
            t.text = "Всё, что начинается — должно однажды закончиться.";

        if (PlayerPrefs.GetInt("youcheat", 1) == 0 && PlayerPrefs.GetInt("yousurwive") == 0)
        {
            coins = PlayerPrefs.GetInt("coins");
            allcoins = PlayerPrefs.GetInt("allcoins");
            score = PlayerPrefs.GetInt("allscore");
            coins += 10000;
            score += 2000;
            allcoins += 10000;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("allcoins", allcoins);
            PlayerPrefs.SetInt("allscore", score);
            PlayerPrefs.SetInt("g1passed", 1);
        }
        if (PlayerPrefs.GetInt("youcheat", 1) == 0 && PlayerPrefs.GetInt("yousurwive") == 1)
        {
            coins = PlayerPrefs.GetInt("coins");
            allcoins = PlayerPrefs.GetInt("allcoins");
            score = PlayerPrefs.GetInt("allscore");
            coins += 300;
            score += 2000;
            allcoins += 300;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("allcoins", allcoins);
            PlayerPrefs.SetInt("allscore", score);
            PlayerPrefs.SetInt("g1passed", 1);
        }

        // ⬇️ Если хочешь запустить затухание сразу — раскомментируй строки ниже:
        // StartCoroutine(FadeOutAudio(ad1, 6f));
        // StartCoroutine(FadeOutAudio(ad3, 6f));
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
        if(PlayerPrefs.GetInt("ach5", 0) == 0 && sus == 100 && PlayerPrefs.GetInt("yousurwive", 0) == 0)
        {
        PlayerPrefs.SetInt("ach5", 1);
        anim2.Play("anim20");
        ad4.Play();
        }
    }
}
