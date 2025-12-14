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
    public Image C1;
    public Image C2;
    public Image C3;
    public Image CI1;
    public Image CI2;
    public Image CI3;

    public void click1()
    {
        if(PlayerPrefs.GetInt("g1passed", 0) == 1)
            t.text = "Мы покидаем орбиту Земли и направляемся к Луне. Полёт проходит спокойно, отклонений не зафиксировано. После приближения к поверхности приборы начинают вести себя странно, но причины неясны. Мы решаем проверить источник и меняем курс. Внезапно начинается буря, и приходится резко набирать высоту. Но после выхода из бури я ув-в-в-в… р-а…";
        else
            t.text = "Никто не знает что тут будет, пока ты не разведаешь!";

        I1.color = new Color(0, 106/255f, 8/255f);
        I2.color = new Color(106/255f, 0, 87/255f);
        I3.color = new Color(106/255f, 0, 87/255f);
    }
    public void click2()
    {
        if(PlayerPrefs.GetInt("g2passed", 0) == 1)
            t.text = "Мы влетаем в чёрную дыру — пространство теряет форму. Мелькает коридор из игрушек, затем слепящий свет. Резкий переход: комната из неподвижных часов. Потом — заброшенное помещение, серый бетон, облезшие стены. На одной из них знакомые буквы, будто оставленные кем-то давно и не к месту. Мы задерживаемся на них дольше, чем хотелось бы. Изображение рвётся, связь гаснет и возвращается. Мы уже в розово-синем космосе. И сразу — удар. Метеор пробивает корпус, двигатель выходит из строя.";
        else
            t.text = "Никто не знает что тут будет, пока ты не разведаешь!";

        I2.color = new Color(0, 106/255f, 8/255f);
        I1.color = new Color(106/255f, 0, 87/255f);
        I3.color = new Color(106/255f, 0, 87/255f);
    }
    public void click3()
    {
        t.text = "Скоро. Я просто еще не придумал...";

        I3.color = new Color(0, 106/255f, 8/255f);
        I2.color = new Color(106/255f, 0, 87/255f);
        I1.color = new Color(106/255f, 0, 87/255f);
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
        if(PlayerPrefs.GetInt("g2passed", 0) == 1)
        {
            CI1.color = new Color(0, 106/255f, 8/255f);
            C1.color = new Color(0, 106/255f, 8/255f);
        }
        if(PlayerPrefs.GetInt("g3passed", 0) == 1)
        {
            CI1.color = new Color(0, 106/255f, 8/255f);
            C1.color = new Color(0, 106/255f, 8/255f);
        }
    }
}
