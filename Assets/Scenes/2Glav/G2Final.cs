using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class G2Final : MonoBehaviour
{
    public AudioSource ad;
    public Text t;
    private int coins;
    private int allcoins;
    private int score;

    void Start()
    {
        if (PlayerPrefs.GetInt("audio") == 0)
        {
            ad.enabled = true;
        }
        else if (PlayerPrefs.GetInt("audio") == 1)
        {
            ad.enabled = false;
        }

        ad.volume = PlayerPrefs.GetFloat("audios", 0.5f);

        if (PlayerPrefs.GetInt("youcheat", 1) == 1)
            t.text = "Интересно. Ты здесь, но по логам тебя здесь быть не должно. Ни маршрута, ни затрат, ни нормального пути. Решил обойти всё? Без страданий действительно слаще? Только вот системы так не работают. Попробуй ещё раз. По-настоящему.";
        else if (PlayerPrefs.GetInt("yousurwive") == 1)
            t.text = "Ни урона. Ни потерь. Ни расхода топлива. Полёт будто из детской сказки. Так не бывает. Или ты спишь, или вселенная решила подыграть. В любом случае — это несерьёзно. Просыпайся.";
        else if (PlayerPrefs.GetInt("fall") == 1)
            t.text = "Говорили, что за горизонтом бесплатный вайфай. Обманули.";
        else
            t.text = "Что происходит?? Что это за звуки??";

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
            PlayerPrefs.SetInt("g2passed", 1);
        }
    }
    
    public void ToMain()
    {
        SceneManager.LoadScene("main");
    }
}
