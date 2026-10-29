using UnityEngine;
using UnityEngine.UI;

public class Ach5 : MonoBehaviour
{
    public Text Task;
    public Text Level;
    public Text Revard;
    public Slider StepsSlider;
    public GameObject StepsGO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        int ach5level = PlayerPrefs.GetInt("Ach5Level", 0);

        if(ach5level == 0)
        {
            Level.text = "Этап 1 из 3";
            Task.text = "Какая последовательность металлов?";
        }
        else if(ach5level == 1)
        {
            Level.text = "Этап 2 из 3";
            Task.text = "Без экипажа...";
        }
        else if(ach5level == 2)
        {
            Level.text = "Этап 3 из 3";
            Task.text = "1000 шагов, поход нормальный!";
            StepsGO.SetActive(true);
            StepsSlider.value = PlayerPrefs.GetInt("StepsAch", 0);
        }
        else if(ach5level >= 3)
        {
            Level.text = "Пройдено.";
            Task.text = "";
            Revard.text = "Вы получили ракету «SUS»";
            StepsGO.SetActive(false);

            if(ach5level == 3)
            {
                PlayerPrefs.SetInt("Ach5Level", 4);
                PlayerPrefs.SetInt("Skin1", 1);
                ach5level = 4;
            }
        }

        PlayerPrefs.SetInt("Ach5LevelPrevious", ach5level);
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("Ach5Level", 0) >= 3 && PlayerPrefs.GetInt("Ach5LevelUpdate1", 0) == 0)
        {
            OnEnable();
            PlayerPrefs.SetInt("Ach5LevelUpdate1", 1);
        }
    }
}
