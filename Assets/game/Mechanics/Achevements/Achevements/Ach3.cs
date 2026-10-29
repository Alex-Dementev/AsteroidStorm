using UnityEngine;
using UnityEngine.UI;

public class Ach3 : MonoBehaviour
{
    public Text Task;
    public Text Level;
    public Text Revard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        int ach3level = PlayerPrefs.GetInt("Ach3Level", 0);

        if(ach3level == 0)
        {
            Level.text = "Этап 1 из 3";
            Task.text = "Потрясный сканнер!";
        }
        else if(ach3level == 1)
        {
            Level.text = "Этап 2 из 3";
            Task.text = "Люблю сканировать!";
        }
        else if(ach3level == 2)
        {
            Level.text = "Этап 3 из 3";
            Task.text = "А если уберешь сканнер но попробуешь снова? Раз в год и палка стреляет!";
        }
        else if(ach3level >= 3)
        {
            Level.text = "Пройдено.";
            Task.text = "";
            Revard.text = "Вы получили ракету «Гол»";

            if(ach3level == 3)
            {
                PlayerPrefs.SetInt("Ach3Level", 4);
                PlayerPrefs.SetInt("SattelliteFall", 0);
                PlayerPrefs.SetInt("Skin3", 1);
                ach3level = 4;
            }
        }

        PlayerPrefs.SetInt("Ach3LevelPrevious", ach3level);
    }
}
