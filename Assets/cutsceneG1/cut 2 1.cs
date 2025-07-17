using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutsceneg2 : MonoBehaviour
{
    public AudioSource ad;
    public AudioSource ad2;
    public AudioSource ad3;
    private float currentVolume;
    public Animator anim;

    void Start()
    {
        // Загружаем громкость для ad2
        currentVolume = PlayerPrefs.GetFloat("audios", 0.5f);
        ad2.volume = currentVolume / 14;
        ad.volume = currentVolume / 1.2f;
        ad3.volume = currentVolume / 1.1f;
    }

    public void isclick()
    {
        anim.Play("end");
    }

    public void nextScene()
    {
        SceneManager.LoadScene("main");
    }

    public void humanoid()
    {
        ad.Play();
    }

    // Затухание ad2 за 1 секунду
    public void FadeOutAd2()
    {
        StartCoroutine(FadeVolume(ad2, ad2.volume, 0f, 1f));
    }

    // Нарастание ad2 за 1 секунду (до текущей сохранённой громкости)
    public void FadeInAd2()
    {
        StartCoroutine(FadeVolume(ad2, ad2.volume, currentVolume, 1.5f));
    }

    // Длинное затухание ad2 за 3 секунды
    public void LongFadeOutAd2()
    {
        StartCoroutine(FadeVolume(ad2, ad2.volume, 0f, 2f));
    }

    // Общий метод для плавной смены громкости
    private IEnumerator FadeVolume(AudioSource source, float from, float to, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            source.volume = Mathf.Lerp(from, to, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        source.volume = to;

        // Сохраняем новую громкость, если нужно
        if (source == ad2)
        {
            PlayerPrefs.SetFloat("ad2_volume", to);
        }
    }
}
