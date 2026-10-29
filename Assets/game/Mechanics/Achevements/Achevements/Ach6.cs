using UnityEngine;
using UnityEngine.UI;

public class Ach6 : MonoBehaviour
{
    public Text Task;
    public Text Level;
    public Text Revard;
    public Slider StepsSlider;
    public GameObject StepsGO;
    public GameObject Dialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        PlayerPrefs.SetInt("Ach6Level", 3);
        int ach6level = PlayerPrefs.GetInt("Ach6Level", 0);

        if(ach6level == 0)
        {
            Level.text = "Этап 1 из 3";
            Task.text = "Мама позвала.";
        }
        else if(ach6level == 1)
        {
            Level.text = "Этап 2 из 3";
            Task.text = "Купил и сразу продал.";
        }
        else if(ach6level == 2)
        {
            Level.text = "Этап 3 из 3";
            Task.text = "Поддержи проект пж пж.";
            StepsGO.SetActive(true);
            StepsSlider.maxValue = 2;
            StepsSlider.value = PlayerPrefs.GetInt("Ach6Level3Status", 0);
        }
        else if(ach6level >= 3)
        {
            Level.text = "Пройдено";
            Task.text = "";
            Revard.text = "Награда: диалог";
            StepsGO.SetActive(false);

            if(ach6level == 3)
            {
                PlayerPrefs.SetInt("Ach6Level", 4);
                ach6level = 4;
                Dialogue.SetActive(true);
            }
        }

        PlayerPrefs.SetInt("Ach6LevelPrevious", ach6level);
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("Ach6LevelPrevious", PlayerPrefs.GetInt("Ach6Level", 0));
    }
}
