using UnityEngine;
using UnityEngine.UI;

public class Ach2 : MonoBehaviour
{
    public Text Task;
    public Text Level;
    public Text Revard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.GetInt("Ach2Level", 0) == 0)
        {
            Level.text = "Этап 1 из 3";
            Task.text = "Не жди конца...";
        }
        else if(PlayerPrefs.GetInt("Ach2Level", 0) == 1)
        {
            Level.text = "Этап 2 из 3";
            Task.text = "На нервах.";
        }
        else if(PlayerPrefs.GetInt("Ach2Level", 0) == 2)
        {
            Level.text = "Этап 3 из 3";
            Task.text = "Максимум, но забыл.";
        }
        else if(PlayerPrefs.GetInt("Ach2Level", 0) >= 3)
        {
            Level.text = "Пройдено";
            Task.text = "";
            Revard.text = "Вы получили питомец «Пятно»";
        }
    }
}
