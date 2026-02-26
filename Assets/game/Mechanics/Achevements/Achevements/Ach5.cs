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
    void Start()
    {
        if(PlayerPrefs.GetInt("Ach5Level", 0) == 0)
        {
            Level.text = "Этап 1 из 3";
            Task.text = "Какая последовательность металлов?";
        }
        else if(PlayerPrefs.GetInt("Ach5Level", 0) == 1)
        {
            Level.text = "Этап 2 из 3";
            Task.text = "Без экипажа...";
        }
        else if(PlayerPrefs.GetInt("Ach5Level", 0) == 2)
        {
            Level.text = "Этап 3 из 3";
            Task.text = "5к шагов, поход нормальный!";
            StepsGO.SetActive(true);
            StepsSlider.value = PlayerPrefs.GetInt("StepsAch", 0);
        }
        else if(PlayerPrefs.GetInt("Ach5Level", 0) >= 3)
        {
            UpdateLevel3();
        }
    }

    public void UpdateLevel3()
    {
        Level.text = "Пройдено";
        Task.text = "";
        Revard.text = "Вы получили ракету «SUS»";
        StepsGO.SetActive(false);
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("Ach5Level", 0) >= 3 && PlayerPrefs.GetInt("Ach5LevelUpdate1", 0) == 0)
        {
            UpdateLevel3();
            PlayerPrefs.SetInt("Ach5LevelUpdate1", 1);
        }
    }
}
