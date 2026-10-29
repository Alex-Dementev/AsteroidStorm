using UnityEngine;
using UnityEngine.UI;

public class Ach2 : MonoBehaviour
{
    public Text Task;
    public Text Level;
    public Text Revard;
    public Achivements Achivements;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        int ach2level = PlayerPrefs.GetInt("Ach2Level", 0);

        if(ach2level == 0)
        {
            Level.text = "Этап 1 из 3";
            Task.text = "Не жди конца, сдавайся...";
        }
        else if(ach2level == 1)
        {
            Level.text = "Этап 2 из 3";
            Task.text = "Отдали свою смерть перед смертью.";
        }
        else if(ach2level == 2)
        {
            Level.text = "Этап 3 из 3";
            Task.text = "Максимум, но забыл и вернулся.";
        }
        else if(ach2level >= 3)
        {
            Level.text = "Пройдено.";
            Task.text = "";
            Revard.text = "Вы получили питомец «Пятно»";

            if(ach2level == 3)
            {
                ach2level = 4;
                Achivements.UpdateAch2();
            }
        }

        PlayerPrefs.SetInt("Ach2LevelPrevious", ach2level);
    }
}
