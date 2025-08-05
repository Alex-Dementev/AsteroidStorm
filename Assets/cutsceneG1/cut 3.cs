using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cut3 : MonoBehaviour
{
    public Text t;

    public void LoadNextScene()
    {
        SceneManager.LoadScene("main");
    }

    void Start()
    {
        if(PlayerPrefs.GetInt("yousurwive") == 1)
        t.text = "Сюжет первой главы пройден. Сложность — 'пижамная'.";
        else if(PlayerPrefs.GetInt("fall") == 1)
        t.text = "Кто-то говорил, что за чёрной дырой — бесплатный вайфай. Если выживу — напишу отзыв. Прыгаю в бездну с лицом из пикселей.";
        else
        t.text = "Всё, что начинается — должно однажды закончиться.";
    }
}
