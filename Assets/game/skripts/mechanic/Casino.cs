using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Casino : MonoBehaviour
{
    public Slider cointocasinos;
    public int coins;              // текущие монеты игрока
    public int allcoins;           // общий счётчик всех монет (только +)
    public Image lightwin;
    public Text coinstocasinot;
    public Text winnercoins;       // текст копилки выигрышей
    public bool isstart;
    public Text x2text;            // показывает множитель
    public int changesLeft;
    public float timer;
    private Color lastColor;

    private int pendingReward;     // накопленные выигрыши
    private string lastMultiplier; // последний множитель (x2/x3 и т.п.)

    void Start()
    {
        x2text.gameObject.SetActive(false);
        lightwin.color = new Color(0.133f, 0.0f, 0.129f);

        coins = PlayerPrefs.GetInt("coins", 0);
        allcoins = PlayerPrefs.GetInt("allcoins", 0);
        pendingReward = PlayerPrefs.GetInt("pendingReward", 0);
        lastMultiplier = PlayerPrefs.GetString("lastMultiplier", "");
        
        winnercoins.text = "Копилка: " + pendingReward;
        x2text.text = lastMultiplier;
        x2text.gameObject.SetActive(!string.IsNullOrEmpty(lastMultiplier));
    }

    void Update()
    {
        cointocasinos.maxValue = PlayerPrefs.GetInt("coins", 0);
        if (!isstart) coinstocasinot.text = "Вложить: " + cointocasinos.value + " монет";

        if (changesLeft > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                lastColor = lightwin.color = GetRandomColor();
                changesLeft--;
                timer = 0.15f;
            }
        }
        else if (isstart)
        {
            isstart = false;
            CheckReward(lastColor);
        }
    }

    Color GetRandomColor()
    {
        float roll = Random.Range(0f, 100f);

        if (roll < 45f) return Color.red;
        else if (roll < 79f) return Color.green;
        else if (roll < 89f) return Color.yellow;
        else if (roll < 99f) return Color.blue;
        else return new Color(0.56f, 0f, 1f);
    }

    public void startroll()
    {
        if (!isstart)
        {
            isstart = true;
            changesLeft = Random.Range(15, 31);
            timer = 0.15f;
        }
    }

    void CheckReward(Color c)
    {
        int bet = (int)cointocasinos.value;
        int reward = 0;

        if (c == Color.green) { reward = bet * 2; lastMultiplier = "x2"; }
        else if (c == Color.blue) { reward = bet * 3; lastMultiplier = "x3"; }
        else if (c == Color.yellow) { reward = bet * 1; lastMultiplier = "x1"; }
        else if (c == Color.red) { reward = 0; lastMultiplier = "x0"; }
        else { reward = bet * 10; lastMultiplier = "x10"; }

        coins = PlayerPrefs.GetInt("coins", 0);
        coins -= bet; // списываем ставку
        PlayerPrefs.SetInt("coins", coins);

        // пополняем накопитель выигрышей
        pendingReward += reward;
        allcoins += reward;

        // сохраняем
        PlayerPrefs.SetInt("pendingReward", pendingReward);
        PlayerPrefs.SetInt("allcoins", allcoins);
        PlayerPrefs.SetString("lastMultiplier", lastMultiplier);

        // обновляем UI
        winnercoins.text = "Копилка: " + pendingReward;
        x2text.text = lastMultiplier;
        x2text.gameObject.SetActive(true);

        Debug.Log("🎰 Последний цвет: " + c + " | Ставка: " + bet + " | Выигрыш: " + reward + " | Всего в копилке: " + pendingReward);
    }

    public void TakeReward()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        coins += pendingReward;  // добавляем накопленный выигрыш
        PlayerPrefs.SetInt("coins", coins);

        // очищаем копилку
        pendingReward = 0;
        lastMultiplier = "";
        PlayerPrefs.SetInt("pendingReward", 0);
        PlayerPrefs.SetString("lastMultiplier", "");

        // обновляем UI
        winnercoins.text = "Копилка: 0";
        x2text.gameObject.SetActive(false);

        Debug.Log("💰 Игрок забрал выигрыш. Теперь монет: " + coins);
    }
}
