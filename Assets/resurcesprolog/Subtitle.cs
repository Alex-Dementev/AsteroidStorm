using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Subtitle : MonoBehaviour
{
    public Text SubtitleText;
    public AudioSource Dialogue1;
    public AudioSource Dialogue2;
    public AudioSource Dialogue3;
    public AudioSource Dialogue4;

    private AudioSource Current;
    private string CurrentSentence;
    private float ToNext;
    public GameObject go;

    void Start()
    {
        if(PlayerPrefs.GetInt("isfinal", 0) == 1)
        {
            Dialogue1.Play();
            Current = Dialogue1;
        }
        else if(PlayerPrefs.GetInt("isfinal2g", 0) == 1)
        {
            Dialogue2.Play();
            Current = Dialogue2;
            go.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("isfinal1g", 0) == 1)
        {
            Dialogue3.Play();
            Current = Dialogue3;
            go.SetActive(true);
        }
        else
        {
            Dialogue4.Play();
            Current = Dialogue4;
            go.SetActive(true);
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
            if(SubtitleText.text.Length > 3)
                SubtitleText.text = SubtitleText.text.Substring(0, SubtitleText.text.Length - 3);
            if(SubtitleText.text.Length > 2)
                SubtitleText.text = SubtitleText.text.Substring(0, SubtitleText.text.Length - 2);
            else
                SubtitleText.text = SubtitleText.text.Substring(0, SubtitleText.text.Length - 1);

            yield return new WaitForSeconds(0.0001f); // в 2 раза быстрее
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
            if(Time <= 5.6f)
            {
                SetSubtitle("Озвучка финала");
                ToNext = 0.1f;
            }
            else if(Time <= 8.3f)
            {
                SetSubtitle("СДЕЛАЙ ОЗВУЧКУ ПЖПЖ");
                ToNext = 0.03f;
            }
            else if(Time <= 57.8f)
            {
                SetSubtitle("Я ПОЛЕЧУ!");
                ToNext = 0.085f;

                Current = null;
            }
        }
        else if(Current == Dialogue2)
        {
            if(Time <= 5.6f)
            {
                SetSubtitle("Озвучка озвучка после коммы");
                ToNext = 0.1f;
            }
            else if(Time <= 8.3f)
            {
                SetSubtitle("СДЕЛАЙ ОЗВУЧКУ ПЖПЖ");
                ToNext = 0.03f;
            }
            else if(Time <= 57.8f)
            {
                SetSubtitle("Я ПОЛЕЧУ!");
                ToNext = 0.085f;

                Current = null;
            }
        }
        else if(Current == Dialogue3)
        {
            if(Time <= 5.6f)
            {
                SetSubtitle("Озвучка после 1 главы");
                ToNext = 0.1f;
            }
            else if(Time <= 8.3f)
            {
                SetSubtitle("СДЕЛАЙ ОЗВУЧКУ ПЖПЖ");
                ToNext = 0.03f;
            }
            else if(Time <= 57.8f)
            {
                SetSubtitle("Я ПОЛЕЧУ!");
                ToNext = 0.085f;

                Current = null;
            }
        }
        else if(Current == Dialogue4)
        {
            if(Time <= 5.6f)
            {
                SetSubtitle("Озвучка начала");
                ToNext = 0.1f;
            }
            else if(Time <= 8.3f)
            {
                SetSubtitle("СДЕЛАЙ ОЗВУЧКУ ПЖПЖ");
                ToNext = 0.03f;
            }
            else if(Time <= 57.8f)
            {
                SetSubtitle("Я ПОЛЕЧУ!");
                ToNext = 0.085f;

                Current = null;
            }
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