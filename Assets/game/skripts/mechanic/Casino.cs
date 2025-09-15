using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Casino : MonoBehaviour
{
    public Slider cointocasinos;
    public int coins;
    public int allcoins;
    public Image lightwin;
    public Text coinstocasinot;
    public int winnercoinsint;
    public Text winnercoins;
    public bool isstart;
    public Text x2text;
    public int changesLeft;
    public int start;
    public bool win;

    [Header("Звуки казино")]
    public AudioSource winSound;   // звук при выигрыше
    public AudioSource loseSound;  // звук при проигрыше

    void Start()
    {
        x2text.gameObject.SetActive(false);
        lightwin.color = new Color(0.133f, 0.0f, 0.129f);

        // загружаем сохранённый выигрыш
        winnercoinsint = PlayerPrefs.GetInt("wincoins", 0);
        winnercoins.text = "" + winnercoinsint;

        // загружаем сохранённый множитель
        string lastMultiplier = PlayerPrefs.GetString("lastMultiplier", "");
        if (!string.IsNullOrEmpty(lastMultiplier))
        {
            x2text.gameObject.SetActive(true);
            x2text.text = lastMultiplier;
        }

        // загружаем сохранённый цвет
        if (PlayerPrefs.HasKey("lastColorR"))
        {
            float r = PlayerPrefs.GetFloat("lastColorR");
            float g = PlayerPrefs.GetFloat("lastColorG");
            float b = PlayerPrefs.GetFloat("lastColorB");
            float a = PlayerPrefs.GetFloat("lastColorA");
            lightwin.color = new Color(r, g, b, a);
        }
    }

    void Update()
    {
        cointocasinos.maxValue = PlayerPrefs.GetInt("coins", 0);
        if (!isstart) 
            coinstocasinot.text = "Вложить: " + cointocasinos.value + " монет";
    }

    IEnumerator TestForWithDelay()
    {
        for (int i = 0; i < changesLeft; i++)
        {
            if (i == changesLeft - 1) // последний шаг
            {
                isstart = false;
                randomwin();
            }
            else
            {
                randomcolors();
            }

            yield return new WaitForSeconds(0.75f);
        }
    }

    public void randomcolors()
    {
        float roll = Random.Range(0f, 100f);

        if (roll <= 44f)
            lightwin.color = Color.red;       // 0–44
        else if (roll <= 55f)
            lightwin.color = Color.blue;      // 45–55
        else if (roll <= 67f)
            lightwin.color = Color.yellow;    // 56–67
        else if (roll <= 99f)
            lightwin.color = Color.green;     // 68–99
        else
            lightwin.color = new Color(0.56f, 0f, 1f); // 100 — джекпот
    }

    public void randomwin()
    {
        float roll = Random.Range(0f, 100f);
        bool isWin;

        if (roll <= 44f)
        {
            lightwin.color = Color.red;
            start = 0;
            x2text.gameObject.SetActive(true);
            x2text.text = "x0";
        }
        else if (roll <= 55f)
        {
            lightwin.color = Color.blue;
            start *= 3;
            x2text.gameObject.SetActive(true);
            x2text.text = "x3";
            isWin = true;
        }
        else if (roll <= 67f)
        {
            lightwin.color = Color.yellow;
            x2text.gameObject.SetActive(true);
            x2text.text = "x1";
            isWin = true;
        }
        else if (roll <= 99f)
        {
            lightwin.color = Color.green;
            start *= 2;
            x2text.gameObject.SetActive(true);
            x2text.text = "x2";
            isWin = true;
        }
        else
        {
            lightwin.color = new Color(0.56f, 0f, 1f);
            start *= 13;
            x2text.gameObject.SetActive(true);
            x2text.text = "x13";
            isWin = true;
        }

        // проигрыш или выигрыш звук
        // проигрыш или выигрыш звук
        if (x2text.text == "x0" || x2text.text == "x1")
        {
            if (loseSound != null) loseSound.Play(); // проигрышные звуки
        }
        else
        {
            if (winSound != null) winSound.Play();   // выигрышные звуки
        }


        // сохраняем множитель
        PlayerPrefs.SetString("lastMultiplier", x2text.text);

        // сохраняем цвет
        PlayerPrefs.SetFloat("lastColorR", lightwin.color.r);
        PlayerPrefs.SetFloat("lastColorG", lightwin.color.g);
        PlayerPrefs.SetFloat("lastColorB", lightwin.color.b);
        PlayerPrefs.SetFloat("lastColorA", lightwin.color.a);

        // сохраняем выигрыш
        winnercoinsint = PlayerPrefs.GetInt("wincoins", 0);
        winnercoinsint += start;
        PlayerPrefs.SetInt("wincoins", winnercoinsint);
        PlayerPrefs.Save();

        // обновляем текст UI
        winnercoins.text = "" + winnercoinsint;
    }

    public void startroll()
    {
        if (!isstart && cointocasinos.value >= 1)
        {
            isstart = true;
            changesLeft = Random.Range(7, 20); // от 7 до 20 смен
            coins = PlayerPrefs.GetInt("coins", 0);
            coins -= Mathf.RoundToInt(cointocasinos.value);
            PlayerPrefs.SetInt("coins", coins);
            start = Mathf.RoundToInt(cointocasinos.value);
            StartCoroutine(TestForWithDelay());
            x2text.gameObject.SetActive(false);
        }
    }

    public void winner()
    {
        if (winnercoinsint >= 1)
        {
            x2text.gameObject.SetActive(false);
            coins = PlayerPrefs.GetInt("coins", 0);
            allcoins = PlayerPrefs.GetInt("allcoins", 0);

            coins += winnercoinsint;
            allcoins += winnercoinsint;

            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("allcoins", allcoins);

            // сброс, чтобы не дублировалось при перезаходе
            winnercoinsint = 0;
            PlayerPrefs.SetInt("wincoins", 0);
            PlayerPrefs.SetString("lastMultiplier", "");
            PlayerPrefs.DeleteKey("lastColorR");
            PlayerPrefs.DeleteKey("lastColorG");
            PlayerPrefs.DeleteKey("lastColorB");
            PlayerPrefs.DeleteKey("lastColorA");
            PlayerPrefs.Save();

            winnercoins.text = "0";
        }
    }
}
