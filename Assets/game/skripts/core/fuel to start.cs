using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class fueltostart : MonoBehaviour
{
    public Slider fuelSlider;
    public int fuel;
    public int fuel2;
    public int fueled;
    private bool userChangedSlider = false;
    public Text text;

    void Start()
    {
        fuelSlider.onValueChanged.AddListener(OnSliderChanged);
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("start", 0) == 0)
        {
        fuel = PlayerPrefs.GetInt("fuel", 0);

        if (!userChangedSlider)
        {
            // обновляем maxValue всегда
            fuelSlider.maxValue = Mathf.Max(1, fuel); 

            if (fuel == 0)
            {
                fuelSlider.value = 0;
                fueled = 0;
            }
            else if (fuel == 1)
            {
                fuelSlider.value = 1;
                fueled = 1;
            }
            else
            {
                fuelSlider.value = 2;
                fueled = 2;
            }

            PlayerPrefs.SetInt("fueltostart", fueled);
            text.text = fueled.ToString();
        }
        else
        {
            fuel2 = PlayerPrefs.GetInt("fuel", 0);
            int selected = Mathf.RoundToInt(fuelSlider.value);

            // не даём выбрать больше, чем есть топлива
            selected = Mathf.Clamp(selected, 0, fuel2);

            PlayerPrefs.SetInt("fueltostart", selected);
            text.text = selected.ToString();
            fuelSlider.maxValue = fuel2;
        }
        }
    }

    void OnSliderChanged(float value)
    {
        // Проверяем, было ли движение реально от игрока
        if (Input.GetMouseButton(0) || Input.touchCount > 0 && fuel >= 1)
        {
            userChangedSlider = true;
        }
    }
}
