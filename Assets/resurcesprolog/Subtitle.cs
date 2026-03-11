using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Subtitle : MonoBehaviour
{
    public Text SubtitleText;
    public AudioSource Dialogue1;
    public AudioSource Dialogue2;

    private AudioSource Current;
    private string CurrentSentence;
    private float ToNext;

    void Start()
    {
        if(PlayerPrefs.GetInt("PrologueDialogues", 0) == 0)
        {
            Dialogue1.Play();
            Current = Dialogue1;
        }
        else if(PlayerPrefs.GetInt("PrologueDialogues", 0) == 1)
        {
            Dialogue2.Play();
            Current = Dialogue2;
        }
    }

    IEnumerator TypeText(string Sentence)
    {
        SubtitleText.text = "";

        foreach(char letter in Sentence)
        {
            SubtitleText.text += letter;
            yield return new WaitForSeconds(ToNext);
        }
    }

    IEnumerator DeleteText()
    {
        while(SubtitleText.text.Length > 0)
        {
            SubtitleText.text =
                SubtitleText.text.Substring(0, SubtitleText.text.Length - 1);

            yield return new WaitForSeconds(0.00015f); // в 2 раза быстрее
        }
    }

    IEnumerator ChangeSubtitle(string Sentence)
    {
        yield return StartCoroutine(DeleteText());
        yield return StartCoroutine(TypeText(Sentence));
    }

    void Update()
    {
        float Time = Current.time;

        if(Current == Dialogue1)
        {
            if(Time <= 5.3f)
            {
                SetSubtitle("Что это за... тень!?");
                ToNext = 0.1f;
            }
            else if(Time <= 8f)
            {
                SetSubtitle("Ты тоже это видишь, Рома?");
                ToNext = 0.03f;
            }
            else if(Time <= 14.4f)
            {
                SetSubtitle("Вижу, за луной... Похоже на искажение. Оно только что появилось?");
                ToNext = 0.02f;
            }
            else if(Time <= 19f)
            {
                SetSubtitle("Нет. Я проверил старые снимки. Раньше там ничего не было...");
                ToNext = 0.015f;
            }
            else if(Time <= 22.3f)
            {
                SetSubtitle("Что бы это не было, оно появилось внезапно.");
                ToNext = 0.015f;
            }
            else if(Time <= 30f)
            {
                SetSubtitle("Подождите, оно словно поглощает свет, как будто дыра, или...");
                ToNext = 0.03f;
            }
            else if(Time <= 35.3f)
            {
                SetSubtitle("Оно меняется. Только что было меньше. Что это вообще может быть?");
                ToNext = 0.015f;
            }
            else if(Time <= 38.3f)
            {
                SetSubtitle("Если не совпадение, значит, что-то серьезное.");
                ToNext = 0.015f;
            }
            else if(Time <= 41f)
            {
                SetSubtitle("Может это связанно с тем сигналом который мы поймали?");
                ToNext = 0.015f;
            }
            else if(Time <= 44f)
            {
                SetSubtitle("Это не похоже на обычную аномалию...");
                ToNext = 0.025f;
            }
            else if(Time <= 51f)
            {
                SetSubtitle("Слишком... Тихо... Слишком... Точно.");
                ToNext = 0.14f;
            }
            else if(Time <= 55.2f)
            {
                SetSubtitle("И что мы теперь будем делать!?");
                ToNext = 0.03f;
            }
            else if(Time <= 57.5f)
            {
                SetSubtitle("Я ПОЛЕЧУ!");
                ToNext = 0.085f;

                Current = null;
            }
        }

        if(Current == Dialogue2)
        {

        }
    }

    void SetSubtitle(string Sentence)
    {
        if(CurrentSentence == Sentence)
            return;

        CurrentSentence = Sentence;

        StopAllCoroutines();
        StartCoroutine(ChangeSubtitle(Sentence));
    }
}