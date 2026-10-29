using UnityEngine;
using UnityEngine.UI;

public class descriptionasglavs : MonoBehaviour
{
    public Animator wa;
    public Text t;
    public GameObject GO1;
    public GameObject GO2;
    public Image I1;
    public Image I2;
    public Image I3;
    public Image I4;
    public Image I5;
    public Image C1;
    public Image C2;
    public Image C3;
    public Image C4;
    public Image C5;
    public Image CI1;
    public Image CI2;
    public Image CI3;
    public Image CI4;
    public Image CI5;

    public void click1()
    {
        if(PlayerPrefs.GetInt("g1passed", 0) == 1)
            t.text = "Мы покидаем орбиту Земли и направляемся к Луне. Полёт проходит спокойно, отклонений не зафиксировано. После приближения к поверхности приборы начинают вести себя странно, но причины неясны. Внезапно начинается буря, и приходится резко набирать высоту. Но после выхода из бури, мы увидели её...";
        else
            t.text = "Никто не знает что тут будет, пока ты не разведаешь!";

        I1.color = new Color(0, 106/255f, 8/255f);
        I2.color = new Color(106/255f, 0, 87/255f);
        I3.color = new Color(106/255f, 0, 87/255f);
        I4.color = new Color(106/255f, 0, 87/255f);
        I5.color = new Color(106/255f, 0, 87/255f);
    }
    public void click2()
    {
        if(PlayerPrefs.GetInt("Rest", 12000) <= 0)
            t.text = "Сбор денег для подготовки к полету в Аномалию. У нас осталось мало времени.";
        else
            t.text = "Никто не знает что тут будет, пока ты не разведаешь!";

        I2.color = new Color(0, 106/255f, 8/255f);
        I1.color = new Color(106/255f, 0, 87/255f);
        I3.color = new Color(106/255f, 0, 87/255f);
        I4.color = new Color(106/255f, 0, 87/255f);
        I5.color = new Color(106/255f, 0, 87/255f);
    }
    public void click3()
    {
        if(PlayerPrefs.GetInt("g2passed", 0) == 1)
            t.text = "Я влетаю в чёрную дыру. Я вижу белый портал, влетаю и оказываюсь в палате.";
        else
            t.text = "Никто не знает что тут будет, пока ты не разведаешь!";

        I3.color = new Color(0, 106/255f, 8/255f);
        I2.color = new Color(106/255f, 0, 87/255f);
        I1.color = new Color(106/255f, 0, 87/255f);
        I4.color = new Color(106/255f, 0, 87/255f);
        I5.color = new Color(106/255f, 0, 87/255f);
    }   
    public void click4()
    {
        if(PlayerPrefs.GetInt("Rest2", 16000) <= 0)
            t.text = "Сбор денег для улучшения подготовки к полету в Аномалию и чтобы отдать долг. Времени мало, аномалия увеличивается!";
        else
            t.text = "Никто не знает что тут будет, пока ты не разведаешь!";

        I4.color = new Color(0, 106/255f, 8/255f);
        I2.color = new Color(106/255f, 0, 87/255f);
        I1.color = new Color(106/255f, 0, 87/255f);
        I3.color = new Color(106/255f, 0, 87/255f);
        I5.color = new Color(106/255f, 0, 87/255f);
    }   
    public void click5()
    {
        if(PlayerPrefs.GetInt("isfinal", 0) == 1)
            t.text = "Я влетаю в аномалию, я очень близко. Топливо кончается, я вижу точку аномалии, но не дотягиваюсь.";
        else
            t.text = "Никто не знает что тут будет, пока ты не разведаешь!";

        I5.color = new Color(0, 106/255f, 8/255f);
        I2.color = new Color(106/255f, 0, 87/255f);
        I1.color = new Color(106/255f, 0, 87/255f);
        I4.color = new Color(106/255f, 0, 87/255f);
        I3.color = new Color(106/255f, 0, 87/255f);
    }   
    public void close()
    {
        wa.Play("closedes");
    }
    public void Open1()
    {
        wa.Play("opendes");
        GO1.SetActive(true);
        GO2.SetActive(false);
    }
    public void Open2()
    {
        wa.Play("opendes");
        GO1.SetActive(false);
        GO2.SetActive(true);
    }

    void Start()
    {
        if(PlayerPrefs.GetInt("g1passed", 0) == 1)
        {
            CI1.color = new Color(0, 106/255f, 8/255f);
            C1.color = new Color(0, 106/255f, 8/255f);
        }
        if(PlayerPrefs.GetInt("Rest", 12000) <= 0)
        {
            CI2.color = new Color(0, 106/255f, 8/255f);
            C2.color = new Color(0, 106/255f, 8/255f);
        }
        if(PlayerPrefs.GetInt("g2passed", 0) == 1)
        {
            CI3.color = new Color(0, 106/255f, 8/255f);
            C3.color = new Color(0, 106/255f, 8/255f);
        }
        if(PlayerPrefs.GetInt("Rest2", 16000) <= 0)
        {
            CI4.color = new Color(0, 106/255f, 8/255f);
            C4.color = new Color(0, 106/255f, 8/255f);
        }
        if(PlayerPrefs.GetInt("isfinal", 0) == 1)
        {
            CI5.color = new Color(0, 106/255f, 8/255f);
            C5.color = new Color(0, 106/255f, 8/255f);
        }
    }

    public void UpdateControllers()
    {
        if(PlayerPrefs.GetInt("g1passed", 0) == 1)
        {
            CI1.color = new Color(0, 106/255f, 8/255f);
            C1.color = new Color(0, 106/255f, 8/255f);
        }
        if(PlayerPrefs.GetInt("Rest", 12000) <= 0)
        {
            CI2.color = new Color(0, 106/255f, 8/255f);
            C2.color = new Color(0, 106/255f, 8/255f);
        }
        if(PlayerPrefs.GetInt("g2passed", 0) == 1)
        {
            CI3.color = new Color(0, 106/255f, 8/255f);
            C3.color = new Color(0, 106/255f, 8/255f);
        }
        if(PlayerPrefs.GetInt("Rest2", 16000) <= 0)
        {
            CI4.color = new Color(0, 106/255f, 8/255f);
            C4.color = new Color(0, 106/255f, 8/255f);
        }
        if(PlayerPrefs.GetInt("isfinal", 0) == 1)
        {
            CI5.color = new Color(0, 106/255f, 8/255f);
            C5.color = new Color(0, 106/255f, 8/255f);
        }
    }
}
