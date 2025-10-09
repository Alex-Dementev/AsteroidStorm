using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RDG;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;

public class death : MonoBehaviour
{
    [SerializeField] public Text quoteText;
    [SerializeField] public GameObject losePanel;
    [SerializeField] public Transform player;
    public int coins;
    public Text fuelzero;
    public float isdelay2;
    public Image liveimage;
    private int live = 3;
    public bool b;
    public int cb;
    public AudioSource adbonus;
    public Animator animbonus;
    public DoubleTapHandler d;
    private float isdelay = 9999999;
    public bool isgotohome;
    public Animator anim;
    public Animator anim3;
    public Animator anim1;
    public GameObject image;
    public AudioSource ad;
    public AudioSource lifeLostSound;
    private float f = 9999999;
    public int score;
    public int allcoins;
    public Text livet;
    public Animator anim2;
    public bool isstarttask;
    public int is2;
    public float fuel;
    public Slider SliderFuel;
    public bool isfuelzero;
    public bool isfuel5;
    public Animator fuel5;

    public GameObject explosionEffect;
    public AudioSource explosionSound1;
    public AudioSource explosionSound2;

    string[] deathQuotes = {
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
        "Ты был просто фрагментом кода.",
        "Где-то за углом — твоя удача. Но ты мимо.",
        "Поражение с оттенком отчаяния.",
        "Ты стал примером для других. Плохим.",
        "Даже кометы отвернулись.",
        "Астероид притворился планетой. Ты поверил.",
        "Ты взял не тот поворот.",
        "Последняя ошибка была особенно стильной.",
        "Ошибок не было. Просто ты.",
        "Осколки твоего полёта — теперь звёзды.",
        "Время остановилось. А ты — нет.",
        "Космос всегда выигрывает.",
        "Ты нырнул в хаос. Без скафандра.",
        "Ты проснулся в неправильной вселенной.",
        "Пилот исчез. Вселенная не заметила.",
        "Даже баги шокированы.",
        "Твоя смерть добавлена в туториал.",
        "Мечта сгорела вместе с двигателем.",
        "Последние слова: «смотри, как умею».",
        "Ты был легендой. По-своему.",
        "Даже GPS сдался.",
        "Ты ускорился… в смерть.",
        "Все системы отказали. И ты тоже.",
        "Жажда скорости победила осторожность.",
        "Ты вошёл в топ самых странных смертей.",
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
        "Игра окончена. Но вселенная осталась.",
        "Ты проиграл, но хотя бы весело.",
        "Нажал не ту кнопку — вылетел.",
        "Полетел за орбиту... без билета обратно.",
        "Ты был отличной мишенью.",
        "Ракета не тормоз — проверено.",
        "Пилот пытался финтить. Зря.",
        "Ты попал в туториал для других игроков.",
        "Залетел красиво — вышел плоско.",
        "Ты поймал бустер... лицом.",
        "Пилот прошёл курс: «Как не надо делать».",
        "Ты слишком доверился своему чутью.",
        "Ракета ушла в закат. Сквозь стену.",
        "Ты победил здравый смысл.",
        "Игровая физика сказала: «досвидания».",
        "Ты оттолкнулся от удачи — и всё.",
        "Стены оказались умнее.",
        "Ракета решила стать ковром-самолётом.",
        "Ты почти победил гравитацию. Почти.",
        "Тебя остановил пыльный пиксель.",
        "Твоя траектория вызвала слёзы у математика.",
        "Ты прошёл сквозь баг. И остался там.",
        "Ты доказал: астероиды — плохие подушки.",
        "Ты не вписался... никуда.",
        "Ты слишком увлёкся ускорением.",
        "Кнопка «вперёд» была нажата слишком сильно.",
        "Ты хотел свернуть — и свернулся.",
        "Пилот решил вздремнуть… в стене.",
        "Ты вызвал смех у всей галактики.",
        "Скорость — это не всё.",
        "Ты словил бан от физики.",
        "Ракета обиделась и ушла в текстуры.",
        "Ты создал идеальный провал.",
        "Ты не избежал банального финала.",
        "Статистика тебя запомнит. Смешно.",
        "Ты нарисовал новый маршрут. В скалу.",
        "Пилот поверил в чудо. А зря.",
        "Ты слился… буквально.",
        "Ты открыл новую точку на карте — «труп».",
        "Ты — баг, ставший легендой.",
        "Геймплей сказал: «нет».",
        "Ты телепортировался в ноль.",
        "Ты сделал кульбит и улетел в позор.",
        "Задел границу Вселенной. И проиграл.",
        "Ты врезался так, что игра поставила паузу.",
        "Ты добился дна космоса.",
        "Ты пролетел сквозь чекпоинт. И мимо жизни.",
        "Ты пошёл в обход… прям в смерть.",
        "Ты потерял управление, уважение и ракету.",
        "Космос тебя не понял.",
        "Ракета ушла на перерыв.",
        "Твоя судьба: быть метеором. В стене.",
        "Ты стал частью ландшафта.",
        "Ты активировал стену. Лицом.",
        "Твоя смерть — баг или фича?",
        "Поздравляем! Ты победил самого себя.",
        "Ты ведь понимаешь, что я всё это вижу?",
        "Поверни телефон. Нет, серьёзно, поверни.",
        "Кто-то стоит за твоим плечом…",
        "Экран становится тёплым… ты это чувствуешь?",
        "Почему ты моргнул? Я видел.",
        "Ты не один…",
        "Батарея садится быстрее, чем должна.",
        "Не смотри в отражение экрана.",
        "Ты уверен, что игра закрыта, когда выходишь?"
    };

    void Start()
    {
        if (PlayerPrefs.GetInt("isfinal1g", 0) == 0)
        {
            fuel = PlayerPrefs.GetInt("fueltostart", 0);
            fuel = fuel * 10 + 10;
            SliderFuel.maxValue = fuel;
        }
        
        if (PlayerPrefs.GetInt("isfinal1g", 0) == 1)
        {
            fuel = PlayerPrefs.GetInt("fueltostart", 0);
            fuel = fuel * 10;

            if(fuel >= 10)
            fuel -= 10;

            SliderFuel.maxValue = fuel;
            fuel = PlayerPrefs.GetFloat("fueltofinalglav", 0);
        }
        
        live = PlayerPrefs.GetInt("live");
        livet.text = live.ToString();
        b = false;
        isdelay = 9999999;

        int chance = Random.Range(1, 501);
        if (chance == 1)
        {
            quoteText.text = "ТЫ НИЧТОЖЕСТВО";
            quoteText.color = Color.red;
        }
        else
        {
            quoteText.text = deathQuotes[Random.Range(0, deathQuotes.Length)];
            quoteText.color = Color.white;
        }
    }

    void Update()
    {
        isdelay -= Time.deltaTime;
        isdelay2 -= Time.deltaTime;
        f -= Time.deltaTime;

        if(fuel <= 5 && !isfuel5)
        {
            fuel5.Play("fuelzerostart");
            isfuel5 = true;
        }

        if (isdelay <= 0 && isgotohome)
        {
            isdelay = 100;
            SceneManager.LoadScene("main");
            isgotohome = false;
        }

        fuel -= Time.deltaTime;
        SliderFuel.value = fuel;

        if (PlayerPrefs.GetInt("GoToFinalGlav", 0) == 1)
        {
            PlayerPrefs.SetFloat("fueltofinalglav", fuel);
            PlayerPrefs.SetInt("GoToFinalGlav", 0);
        }

        if (b == true)
        {
            if (f <= 0)
            {
                restart();
                f = 9999999;
            }
        }

        if (live == 3)
        {
            liveimage.color = new Color(1f, 0f, 0.3f);
            livet.color = new Color(1f, 0f, 0.35f);
        }
        else if (live == 2)
        {
            liveimage.color = new Color(0.749f, 0.223f, 0.478f);
            livet.color = new Color(0.749f, 0.223f, 0.5f);
        }
        else if (live == 1)
        {
            liveimage.color = new Color(0.671f, 0.376f, 0.522f);
            livet.color = new Color(0.671f, 0.376f, 0.522f);
        }
        else
        {
            liveimage.color = new Color(0.322f, 0.322f, 0.322f);
            livet.color = new Color(0.322f, 0.322f, 0.322f);
        }

        if (isdelay2 <= 0 && is2 >= 2)
        {
            is2 = 0;
            PlayerPrefs.SetInt("breakObstacles", 2);
        }
        else if (isdelay2 <= 0 && is2 == 1)
        {
            isstarttask = false;
            is2 = 0;
            PlayerPrefs.SetInt("breakObstacles", 1);
        }
        



        if (b == false && fuel <= -1 && isfuelzero == false)
        {
            if (PlayerPrefs.GetInt("yousurwive", 0) == 0)
            {
                losePanel.SetActive(true);
                anim1.Play("anim11");
                fuelzero.text = "Топливо закончилось";
                isfuelzero = true;

                if (PlayerPrefs.GetInt("isfinal1g", 0) == 1)
                {
                    coins = PlayerPrefs.GetInt("coins");
                    allcoins = PlayerPrefs.GetInt("allcoins");
                    score = PlayerPrefs.GetInt("allscore");
                    coins += ((int)(player.position.z / 7) + 400);
                    score += ((int)(player.position.z / 3) + 1000);
                    allcoins += ((int)(player.position.z / 7) + 400);
                    PlayerPrefs.SetInt("coins", coins);
                    PlayerPrefs.SetInt("allcoins", allcoins);
                    PlayerPrefs.SetInt("allscore", score);
                    PlayerPrefs.SetInt("youdead", 1);
                }
                else
                {
                    coins = PlayerPrefs.GetInt("coins");
                    allcoins = PlayerPrefs.GetInt("allcoins");
                    score = PlayerPrefs.GetInt("allscore");
                    coins += ((int)(player.position.z / 10));
                    score += ((int)(player.position.z / 3));
                    allcoins += ((int)(player.position.z / 10));
                    PlayerPrefs.SetInt("coins", coins);
                    PlayerPrefs.SetInt("allcoins", allcoins);
                    PlayerPrefs.SetInt("allscore", score);
                    PlayerPrefs.SetInt("youdead", 1);
                }

                if (PlayerPrefs.GetInt("vibration") == 0)
                {
                    Vibration.Vibrate(800, 120);
                }

                ad.Play();
                b = true;
                f = 11;
            }
        }
    }

    public void restart()
    {
        image.SetActive(!image.activeSelf);
        anim.Play("anim10 0");
        isdelay = 2f;
        isgotohome = true;
    }

    public void restart2()
    {
        image.SetActive(!image.activeSelf);
        anim.Play("anim10 0");
        StartCoroutine(RestartAfterDelay(2f));
    }

    public void restart3()
    {
        image.SetActive(!image.activeSelf);
        anim.Play("anim10 0");
        StartCoroutine(RestartAfterDelay2(2f));
    }

    private IEnumerator RestartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private IEnumerator RestartAfterDelay2(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("scenestart");
    }

    [SerializeField] private Text fineText;
    [SerializeField] private Animator fineAnim;
    private string[] secretMessages = { "Забей, это просто заранее приготовленные фразы", "ЛОЛ это какие-то 25 монет", "ВОУ, ТЫ НУБ!", "52" };
    private string[] fallfineMessages = { "Ракета 1 : 0 Камень", "Астероид проиграл в PvP.", "Ну всё, камень теперь обижен.", "УФ"};
    private string[] fineMessages = { "Отлично!", "Хорошо!", "Неплохо!", "Класс!", "Есть попадание!", "Харошь" };
    private string[] lifeMessages = { "Осторожней!", "Аб-т-т-на!", "Дела не очень.", "Ужас.", "О-нет.", "ЛОЛ!" };
    private string[] falllifeMessages = { "Жизни улетучиваются быстрее зарплаты.", "Хочешь жизнь? А ЖИЗНЬ ТЕБЯ НЕ ХОЧЕТ!!! (смех за кадром)", "Я ГЕРКУНУ! скафандер мо...", "Супер облепиха!"};


    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.CompareTag("bo"))
        {
            adbonus.Play();
            animbonus.Play("green");
            fuel = fuel + 8;

            if (PlayerPrefs.GetInt("currentTask2", -1) == 1)
            {
                cb = PlayerPrefs.GetInt("collectBonus", 0);
                cb++;
                PlayerPrefs.SetInt("collectBonus", cb);
            }
            
            Destroy(Collision.gameObject);
        }
        if (Collision.gameObject.CompareTag("br") && live <= 2)
        {
            live += 1;
            adbonus.Play();
            animbonus.Play("green");
            livet.text = live.ToString();
            PlayerPrefs.SetInt("live", live);

            if (PlayerPrefs.GetInt("currentTask2", -1) == 1)
            {
                cb = PlayerPrefs.GetInt("collectBonus", 0);
                cb++;
                PlayerPrefs.SetInt("collectBonus", cb);
            }

            Destroy(Collision.gameObject);
        }

        if (Collision.gameObject.CompareTag("obstacle"))
        {
            if (PlayerPrefs.GetInt("yousurwive", 0) == 0)
            {
            AsteroidSkript AS = Collision.gameObject.GetComponent<AsteroidSkript>();
            if (AS != null)
            {
                AS.asvoid();
            }

            if (d.b == true)
            {
                if (PlayerPrefs.GetInt("currentTask2", -1) == 0)
                {
                    is2++;
                    if(!isstarttask)
                    {
                    isstarttask = true;
                    isdelay2 = 3;
                    }
                }


                if (PlayerPrefs.GetInt("fall") == 1)
                            fineText.text = falllifeMessages[Random.Range(0, lifeMessages.Length)];
                        else
                            fineText.text = lifeMessages[Random.Range(0, lifeMessages.Length)];

                        fineAnim.Play("textFine", -1, 0f);

                if (explosionEffect != null)
                    Instantiate(explosionEffect, Collision.transform.position, Quaternion.identity);

                int rand = Random.Range(0, 2);
                if (rand == 0 && explosionSound1 != null) explosionSound1.Play();
                else if (rand == 1 && explosionSound2 != null) explosionSound2.Play();

                coins = PlayerPrefs.GetInt("coins");
                allcoins = PlayerPrefs.GetInt("allcoins");
                int reward = 25;
                coins += reward;
                allcoins += reward;
                PlayerPrefs.SetInt("coins", coins);
                PlayerPrefs.SetInt("allcoins", allcoins);
                
                if (PlayerPrefs.GetInt("fall") == 1)
                {
                    fineText.text = fallfineMessages[Random.Range(0, fallfineMessages.Length)];
                }
                else if (PlayerPrefs.GetInt("fall") == 0)
                {
                    if (Random.Range(0f, 100f) < 5f)
                    {
                        fineText.text = secretMessages[Random.Range(0, secretMessages.Length)];
                    }
                    else
                    {
                        fineText.text = fineMessages[Random.Range(0, fineMessages.Length)];
                    }
                }

                fineText.color = new Color (0.698f, 0.0f, 0.608f);
                fineAnim.Play("textFine", -1, 0f);

                if (!Collision.gameObject.name.StartsWith("T"))
                {
                    Destroy(Collision.gameObject);
                }
            }
            else if (b == false)
            {
                    anim2.Play("oneshake");
                    fineText.color = new Color (0.698f, 0.0f, 0.608f);  
                    lifeLostSound.Play();
                    live -= 1;
                    livet.text = live.ToString();
                    PlayerPrefs.SetInt("live", live);

                    if (PlayerPrefs.GetInt("currentTask2", -1) == 2)
                    {
                        int current = PlayerPrefs.GetInt("loseLife", 0);
                        current += 1;
                        PlayerPrefs.SetInt("loseLife", current);
                    }

                    anim3.Play("anim");

                    if (live >= 1)
                    {
                        if (live == 3)
                        {
                            fineText.color = new Color(1f, 0f, 0.3f);
                        }
                        else if (live == 2)
                        {
                            fineText.color = new Color(0.749f, 0.223f, 0.478f);
                        }
                        else
                        {
                            fineText.color = new Color(0.671f, 0.376f, 0.522f);
                        }
                        
                        if (PlayerPrefs.GetInt("vibration") == 0)
                        {
                            Vibration.Vibrate(200, 70);
                        }
                        if (explosionEffect != null)
                            Instantiate(explosionEffect, Collision.transform.position, Quaternion.identity);

                        if (!Collision.gameObject.name.StartsWith("T"))
                        {
                            Destroy(Collision.gameObject);
                        }
                    }
                    else
                    {
                        if (explosionEffect != null)
                            Instantiate(explosionEffect, Collision.transform.position, Quaternion.identity);

                        if (!Collision.gameObject.name.StartsWith("T"))
                        {
                            Destroy(Collision.gameObject);
                        }

                        losePanel.SetActive(true);
                        anim1.Play("anim11");
                        live -= 1;
                        livet.text = live.ToString();
                        PlayerPrefs.SetInt("live", live);

                        if (PlayerPrefs.GetInt("isfinal1g", 0) == 1)
                            {
                                coins = PlayerPrefs.GetInt("coins");
                                allcoins = PlayerPrefs.GetInt("allcoins");
                                score = PlayerPrefs.GetInt("allscore");
                                coins += ((int)(player.position.z / 7) + 400);
                                score += ((int)(player.position.z / 3) + 1000);
                                allcoins += ((int)(player.position.z / 7) + 400);
                                PlayerPrefs.SetInt("coins", coins);
                                PlayerPrefs.SetInt("allcoins", allcoins);
                                PlayerPrefs.SetInt("allscore", score);
                                PlayerPrefs.SetInt("youdead", 1);
                            }
                            else
                            {
                                coins = PlayerPrefs.GetInt("coins");
                                allcoins = PlayerPrefs.GetInt("allcoins");
                                score = PlayerPrefs.GetInt("allscore");
                                coins += ((int)(player.position.z / 10));
                                score += ((int)(player.position.z / 3));
                                allcoins += ((int)(player.position.z / 10));
                                PlayerPrefs.SetInt("coins", coins);
                                PlayerPrefs.SetInt("allcoins", allcoins);
                                PlayerPrefs.SetInt("allscore", score);
                                PlayerPrefs.SetInt("youdead", 1);
                            }

                    if (PlayerPrefs.GetInt("vibration") == 0)
                    {
                        Vibration.Vibrate(800, 120);
                    }

                    ad.Play();
                    b = true;
                    f = 11;
                }
            }
            }
        }
    }
}
