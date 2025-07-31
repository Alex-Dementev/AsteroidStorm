using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RDG;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class death : MonoBehaviour
{
    [SerializeField] public Text quoteText;
    [SerializeField] public GameObject losePanel;
    [SerializeField] public Transform player;
    public int coins;
    public bool b;
    public DoubleTapHandler d;
    private float isdelay = 9999999;
    public Animator anim;
    public Animator anim1;
    public GameObject image;
    public AudioSource ad;
    private float f = 9999999;
    public int score;
    public int allcoins;

    public GameObject explosionEffect;
    public AudioSource explosionSound1;
    public AudioSource explosionSound2;

    private string[] quotes = new string[]
    {
        "Ну вот и всё, капитан кефир.",
        "Покойся с фпс.",
        "Ошибка 404: пилот не найден.",
        "Пилот ушёл в АФК.",
        "Ты нашёл невидимую стену.",
        "Просто космос сказал «нет».",
        "Может, в следующий раз без флипа в стену?",
        "Ракета решила отдохнуть.",
        "Ты сделал кувырок… и всё.",
        "Разве это не была кнопка тормоза?",
        "На всякий случай — счётчик смертей +1.",
        "Ты доказал: астероиды твёрже, чем ты.",
        "Камера была в шоке. Мы тоже.",
        "Ты не учёл фактор \"лол\".",
        "Космос тебя забрал, потому что ты мем.",
        "Ракетный спорт — не твоё.",
        "Об астероид споткнуться — тоже искусство.",
        "Гейм-дизайнер доволен.",
        "Ты нашёл способ проиграть, которого даже мы не знали.",
        "ИИ сказал: «ну и ладно».",
        "Ты прошёл обучение… почти.",
        "Астероиды: «нам смешно».",
        "Это был очень красивый провал.",
        "Спасибо за тест, он не прошёл.",
        "Умер, зато красиво.",
        "Ты — ракетный салат.",
        "Астероид выиграл дуэль.",
        "Ракета? Больше похоже на мыло.",
        "Космос молчит. Он доволен.",
        "Покой нарушен, стабильность исчезла.",
        "Где-то далеко кто-то сказал: «Жаль…».",
        "Осталась только траектория.",
        "Ты стал частью звёздной пыли.",
        "Последний след — твой след.",
        "Ты вошёл в легенды… неудач.",
        "Пульсация прекратилась.",
        "Тебя стерло в фазовом смещении.",
        "Ты проиграл в борьбе с бесконечностью.",
        "Чернота закрыла глаза.",
        "Радиация тебя не заметила — и всё равно убила.",
        "Твоя душа застряла между измерениями.",
        "Это был не выход. Это был конец.",
        "Нестабильность тебя поглотила.",
        "Гравитация не простила.",
        "Ты был слишком лёгким для этой тьмы.",
        "Последний сигнал потерян.",
        "Черная дыра даже не моргнула.",
        "Ты нарушил симметрию.",
        "Бесконечность дала сбой.",
        "Пилот растворился в эхе.",
        "Астероиды аплодировали стоя.",
        "На этом моменте все заплакали.",
        "Ты упал на ровном вакууме.",
        "Ну, бывает.",
        "Мы предупреждали, но ты был быстрее.",
        "Даже симуляция устала от тебя.",
        "Космос устал смеяться.",
        "Кто-то вырезал твой спрайт.",
        "Ракета превратилась в статистику.",
        "Респаун? Нет, спасибо.",
        "Система отказала. Ты — тоже.",
        "Место смерти: вся карта.",
        "Гиперпрыжок? Нет, гиперпровал.",
        "Ты не прошёл проверку на прочность.",
        "В следующий раз не забудь скафандр.",
        "Даже UI не поверил в твои шансы.",
        "Ты догнал собственную неудачу.",
        "Распался на пиксели.",
        "Контракт с реальностью разорван.",
        "Столкновение было единственным диалогом.",
        "Ракета думала, что она птица. Ошиблась.",
        "Космос: «Я не подписывался на это».",
        "Прямо в текстуры.",
        "Ты отправился туда, где баги отдыхают.",
        "Ошибка игрока между клавиатурой и креслом.",
        "Игра: «Ты серьёзно?»",
        "Даже пауза не помогла.",
        "Ты был просто фрагментом кода.",
        "Где-то за углом — твоя удача. Но ты мимо.",
        "Поражение с оттенком отчаяния.",
        "Космос оценил твою жертву.",
        "Ты стал примером для других. Плохим.",
        "Галактика вздохнула с облегчением.",
        "Даже кометы отвернулись.",
        "Астероид притворился планетой. Ты поверил.",
        "Ты взял не тот поворот.",
        "Последняя ошибка была особенно стильной.",
        "Ошибок не было. Просто ты.",
        "Осколки твоего полёта — теперь звёзды.",
        "Время остановилось. А ты — нет.",
        "Космос всегда выигрывает.",
        "Ты нырнул в хаос. Без скафандра.",
        "Всё это могло быть сном.",
        "Ты проснулся в неправильной вселенной.",
        "Ни звука. Только конец.",
        "Пилот исчез. Вселенная не заметила.",
        "Даже баги шокированы.",
        "Твоя смерть добавлена в туториал.",
        "Мечта сгорела вместе с двигателем.",
        "Последние слова: «смотри, как умею».",
        "Ты был легендой. По-своему.",
        "Черная дыра сказала: «Добро пожаловать».",
        "Ты погиб геройски. Ну, почти.",
        "Звезды станцевали на твоей траектории.",
        "Финал был эпичен… для наблюдателей.",
        "Ты стал космической шуткой.",
        "Даже GPS сдался.",
        "Ты ускорился… в смерть.",
        "Все системы отказали. И ты тоже.",
        "Жажда скорости победила осторожность.",
        "Даже симуляция поставила паузу.",
        "Ты вошёл в топ самых странных смертей.",
        "Все молчали. Даже UI.",
        "Прости, это была ловушка.",
        "Превышение кринжа на километр.",
        "Гравитация не простила флекса.",
        "Ты умер ради науки. Наверное.",
        "Энергия закончилась, как и надежда.",
        "Прекрасный полёт. Плохая посадка.",
        "Ты был частью чего-то большего. Теперь — нет.",
        "Ракета сбилась с пути. Навсегда.",
        "Ты стал космическим эхом.",
        "В этот момент ты понял: это всё.",
        "Ты был гравитационно невыгоден.",
        "Двигатель сгорел вместе с планами.",
        "Все смотрели. Никто не помог.",
        "Камни не простили.",
        "Прощай, пилот. Надеюсь, перезапустишься.",
        "Здесь когда-то был игрок.",
        "Игра окончена. Но вселенная осталась."
    };

    void Start()
    {
        b = false;
        isdelay = 9999999;

        int chance = Random.Range(1, 501); // 1 из 500
        if (chance == 1)
        {
            quoteText.text = "MrGameDragon тоже не смог без отключения астероидов";
            quoteText.color = Color.red;
        }
        else
        {
            quoteText.text = quotes[Random.Range(0, quotes.Length)];
            quoteText.color = Color.white;
        }
    }

    void Update()
    {
        isdelay -= Time.deltaTime;
        f -= Time.deltaTime;

        if (isdelay <= 0)
        {
            isdelay = 99999999;
            SceneManager.LoadScene("main");
        }

        if (b == true)
        {
            if (f <= 0)
            {
                restart();
                f = 9999999;
            }
        }
    }

    public void restart()
    {
        image.SetActive(!image.activeSelf);
        anim.Play("anim10 0");
        isdelay = 1.2f;
    }

    public void restart2()
    {
        image.SetActive(!image.activeSelf);
        anim.Play("anim10 0");
        StartCoroutine(RestartAfterDelay(1.2f));
    }

    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.CompareTag("obstacle"))
        {
            if (d.b == true)
            {
                Debug.Log("fly");
                if (explosionEffect != null)
                {
                    Instantiate(explosionEffect, Collision.transform.position, Quaternion.identity);
                }

                int rand = Random.Range(0, 2);
                if (rand == 0 && explosionSound1 != null) explosionSound1.Play();
                else if (rand == 1 && explosionSound2 != null) explosionSound2.Play();

                Destroy(Collision.gameObject);
            }
            else if (b == false)
            {
                losePanel.SetActive(true);
                anim1.Play("anim11");

                coins = PlayerPrefs.GetInt("coins");
                allcoins = PlayerPrefs.GetInt("allcoins");
                score = PlayerPrefs.GetInt("allscore");
                coins += ((int)(player.position.z / 10));
                score += ((int)(player.position.z / 3));
                allcoins += ((int)(player.position.z / 10));
                PlayerPrefs.SetInt("coins", coins);
                PlayerPrefs.SetInt("allcoins", allcoins);
                PlayerPrefs.SetInt("allscore", score);

                if (PlayerPrefs.GetInt("vibration") == 0)
                {
                    Vibration.Vibrate(80, 100);
                }

                ad.Play();
                b = true;
                f = 11;
            }
        }
    }
}
