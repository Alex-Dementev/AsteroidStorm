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
    public AudioSource winSound;
    public AudioSource loseSound;

    void Start()
    {
        x2text.gameObject.SetActive(false);
        lightwin.color = new Color(0.133f, 0.0f, 0.129f);

        // монеты выигрыша загружаем
        winnercoinsint = PlayerPrefs.GetInt("wincoins", 0);
        winnercoins.text = "" + winnercoinsint;
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
            if (i == changesLeft - 1)
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
            lightwin.color = Color.red;
        else if (roll <= 55f)
            lightwin.color = Color.blue;
        else if (roll <= 67f)
            lightwin.color = Color.yellow;
        else if (roll <= 99f)
            lightwin.color = Color.green;
        else
            lightwin.color = new Color(0.56f, 0f, 1f);
    }

    public void randomwin()
    {
        float roll = Random.Range(0f, 100f);

        if (roll <= 44f)
        {
            lightwin.color = Color.red;
            start = 0;
            x2text.gameObject.SetActive(true);
            x2text.text = "x0";
            if (loseSound) loseSound.Play();
        }
        else if (roll <= 55f)
        {
            lightwin.color = Color.blue;
            start *= 3;
            x2text.gameObject.SetActive(true);
            x2text.text = "x3";
            if (winSound) winSound.Play();
        }
        else if (roll <= 67f)
        {
            lightwin.color = Color.yellow;
            x2text.gameObject.SetActive(true);
            x2text.text = "x1";
            if (loseSound) loseSound.Play();
        }
        else if (roll <= 99f)
        {
            lightwin.color = Color.green;
            start *= 2;
            x2text.gameObject.SetActive(true);
            x2text.text = "x2";
            if (winSound) winSound.Play();
        }
        else
        {
            lightwin.color = new Color(0.56f, 0f, 1f);
            start *= 13;
            x2text.gameObject.SetActive(true);
            x2text.text = "x13";
            if (winSound) winSound.Play();
        }

        // сохраняем выигрыш
        winnercoinsint = PlayerPrefs.GetInt("wincoins", 0);
        winnercoinsint += start;
        PlayerPrefs.SetInt("wincoins", winnercoinsint);
        PlayerPrefs.Save();
        winnercoins.text = "" + winnercoinsint;

        // запускаем сброс через 10 секунд
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(10f);
        lightwin.color = new Color(0.133f, 0f, 0.129f); // дефолтный цвет
        x2text.gameObject.SetActive(false);            // убрать множитель
    }

    public void startroll()
    {
        if (!isstart && cointocasinos.value >= 1)
        {
            isstart = true;
            changesLeft = Random.Range(7, 20);
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

            winnercoinsint = 0;
            PlayerPrefs.SetInt("wincoins", 0);
            PlayerPrefs.Save();

            winnercoins.text = "0";
        }
    }
}
