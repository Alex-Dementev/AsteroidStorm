using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Casino : MonoBehaviour
{
    public Slider cointocasinos;
    private int coins;
    private int allcoins;
    public Image lightwin;
    public Text coinstocasinot;
    private int winnercoinsint;
    public Text winnercoins;
    private bool isstart;
    public Text x2text;
    private int changesLeft;
    private int start;
    private Color targetColor;
    private bool isStart;

    [Header("Звуки казино")]
    public AudioSource winSound;
    public AudioSource loseSound;

    private Coroutine spinCoroutine;
    private Coroutine resetCoroutine;

    void Start()
    {
        x2text.gameObject.SetActive(false);
        targetColor = new Color32(34, 0, 33, 255);

        winnercoinsint = PlayerPrefs.GetInt("wincoins", 0);
        winnercoins.text = "" + winnercoinsint;
    }

    private void OnDisable()
    {
        // Если панель закрывается прямо во время вращения — сразу завершаем спин и рассчитываем выигрыш
        if (isstart)
        {
            FinishSpinImmediately();
        }

        if (resetCoroutine != null)
        {
            StopCoroutine(resetCoroutine);
        }
    }

    private void OnApplicationQuit()
    {
        // Если игрок выключает саму игру во время спина
        if (isstart)
        {
            FinishSpinImmediately();
        }
    }

    void Update()
    {
        cointocasinos.maxValue = PlayerPrefs.GetInt("coins", 0);
        if (!isstart)
            coinstocasinot.text = "Вложить: " + cointocasinos.value + " монет";

        lightwin.color = new Color(
            Mathf.MoveTowards(lightwin.color.r, targetColor.r, 8f * Time.deltaTime),
            Mathf.MoveTowards(lightwin.color.g, targetColor.g, 8f * Time.deltaTime),
            Mathf.MoveTowards(lightwin.color.b, targetColor.b, 8f * Time.deltaTime),
            Mathf.MoveTowards(lightwin.color.a, targetColor.a, 8f * Time.deltaTime)
        );
    }

    IEnumerator TestForWithDelay()
    {
        for (int i = 0; i < changesLeft; i++)
        {
            if (i == changesLeft - 1)
            {
                isstart = false;
                randomwin(true);
            }
            else
            {
                randomcolors();
            }

            yield return new WaitForSeconds(0.75f);
        }
    }

    /// <summary>
    /// Мгновенное завершение вращения, если панель была выключена раньше времени.
    /// </summary>
    private void FinishSpinImmediately()
    {
        if (spinCoroutine != null)
        {
            StopCoroutine(spinCoroutine);
        }

        isstart = false;
        isStart = false;

        // Принудительно вызываем рандомный выигрыш без ожидания корутины
        randomwin(false);
    }

    public void randomcolors()
    {
        float roll = Random.Range(0f, 100f);

        if (roll <= 44f)
            targetColor = new Color32(255, 0, 0, 255);
        else if (roll <= 55f)
            targetColor = new Color32(0, 0, 255, 255);
        else if (roll <= 67f)
            targetColor = new Color32(255, 255, 0, 255);
        else if (roll <= 99f)
            targetColor = new Color32(0, 255, 0, 255);
        else
            targetColor = new Color32(143, 0, 255, 255);
    }

    public void randomwin(bool inPanel = true)
    {
        float roll = Random.Range(0f, 100f);

        if (roll <= 44f)
        {
            targetColor = new Color32(255, 0, 0, 255);
            start = 0;
            if (x2text)
            {
                x2text.gameObject.SetActive(true);
                x2text.text = "x0";
            }
            if (loseSound && inPanel) loseSound.Play();
        }
        else if (roll <= 55f)
        {
            targetColor = new Color32(0, 0, 255, 255);
            start *= 3;
            if (x2text)
            {
                x2text.gameObject.SetActive(true);
                x2text.text = "x3";
            }
            if (winSound && inPanel) winSound.Play();
        }
        else if (roll <= 67f)
        {
            targetColor = new Color32(255, 255, 0, 255);
            if (x2text)
            {
                x2text.gameObject.SetActive(true);
                x2text.text = "x1";
            }
            if (loseSound && inPanel) loseSound.Play();
        }
        else if (roll <= 99f)
        {
            targetColor = new Color32(0, 255, 0, 255);
            start *= 2;
            if (x2text)
            {
                x2text.gameObject.SetActive(true);
                x2text.text = "x2";
            }
            if (winSound && inPanel) winSound.Play();
        }
        else
        {
            lightwin.color = new Color(0.56f, 0f, 1f);
            start *= 13;
            if (x2text)
            {
                x2text.gameObject.SetActive(true);
                x2text.text = "x13";
            }
            if (winSound && inPanel) winSound.Play();
        }

        // Сохраняем выигрыш
        winnercoinsint = PlayerPrefs.GetInt("wincoins", 0);
        winnercoinsint += start;
        PlayerPrefs.SetInt("wincoins", winnercoinsint);
        PlayerPrefs.Save();

        if (winnercoins)
            winnercoins.text = "" + winnercoinsint;

        // Если объект активен на сцене — запускаем задержку сброса подсветки
        if (gameObject.activeInHierarchy)
        {
            if (resetCoroutine != null) StopCoroutine(resetCoroutine);
            resetCoroutine = StartCoroutine(ResetAfterDelay());
        }

        isStart = false;
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(10f);

        if (!isStart)
        {
            targetColor = new Color32(34, 0, 33, 255);
            if (x2text) x2text.gameObject.SetActive(false);
        }
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

            if (resetCoroutine != null) StopCoroutine(resetCoroutine);
            spinCoroutine = StartCoroutine(TestForWithDelay());

            if (x2text) x2text.gameObject.SetActive(false);
            int Num = PlayerPrefs.GetInt("Casino", 0);
            Num++;
            PlayerPrefs.SetInt("Casino", Num);

            isStart = true;
        }
    }

    public void winner()
    {
        if (winnercoinsint >= 1)
        {
            if (x2text) x2text.gameObject.SetActive(false);
            coins = PlayerPrefs.GetInt("coins", 0);
            allcoins = PlayerPrefs.GetInt("allcoins", 0);

            coins += winnercoinsint;
            allcoins += winnercoinsint;

            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("allcoins", allcoins);

            winnercoinsint = 0;
            PlayerPrefs.SetInt("wincoins", 0);
            PlayerPrefs.Save();

            if (winnercoins) winnercoins.text = "0";

            if (!isStart)
            {
                if (resetCoroutine != null) StopCoroutine(resetCoroutine);
                targetColor = new Color32(34, 0, 33, 255);
                if (x2text) x2text.gameObject.SetActive(false);
            }
        }
    }
}