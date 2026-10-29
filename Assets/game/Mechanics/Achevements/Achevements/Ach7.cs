using UnityEngine;
using UnityEngine.UI;

public class Ach7 : MonoBehaviour
{
    public Text Task;
    public Text Level;
    public Text Revard;
    public Slider StepsSlider;
    public GameObject StepsGO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        int ach7level = PlayerPrefs.GetInt("Ach7Level", 0);

        if(ach7level == 0)
        {
            Level.text = "Этап 1 из 3";
            Task.text = "Услышь тишину вакуума.";
        }
        else if(ach7level == 1)
        {
            Level.text = "Этап 2 из 3";
            Task.text = "Шагни без защиты.";
        }
        else if(ach7level == 2)
        {
            Level.text = "Этап 3 из 3";
            Task.text = "Энергия не бесконечна.";
        }
        else if(ach7level >= 3)
        {
            UpdateLevel3();

            if(ach7level == 3)
            {
                PlayerPrefs.SetInt("Ach7Level", 4);
                ach7level = 4;
                PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + 1);
            }
        }

        PlayerPrefs.SetInt("Ach7LevelPrevious", ach7level);
    }

    public void UpdateLevel3()
    {
        Level.text = "Пройдено";
        Task.text = "";
        Revard.text = "Награда: 1 монета";
        StepsGO.SetActive(false);
    }
}
