using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class fueltostart : MonoBehaviour
{
    public Slider fuelSlider;
    private int fuel;
    private int fuel2;
    private int fueled;
    private bool userChangedSlider = false;
    public Text text;
    private int maxfuel;
    public Animator zeroTanks;
    private float delay;
    private bool isdelay;

    void Start()
    {
        fuelSlider.onValueChanged.AddListener(OnSliderChanged);
    }

    void Update()
    {
        delay -= Time.deltaTime;

        if(PlayerPrefs.GetInt("start", 0) == 0)
        {
            fuel = PlayerPrefs.GetInt("fuel", 0);
            maxfuel = PlayerPrefs.GetInt("MaxFuel1", 0);
            maxfuel += PlayerPrefs.GetInt("MaxFuel2", 0);

            if(maxfuel <= fuel)
            fuelSlider.maxValue = maxfuel;
            if(maxfuel >= fuel)
            fuelSlider.maxValue = fuel;

            if (!userChangedSlider)
            {
                if (fuel == 0)
                {
                    fuelSlider.value = 0;
                    fueled = 0;
                }
                else if (fuel == 1 && maxfuel >= 1)
                {
                    fuelSlider.value = 1;
                    fueled = 1;
                }
                else if(maxfuel >= 1 && fuel >= 2)
                {
                    fuelSlider.value = 2;
                    fueled = 2;
                }

                PlayerPrefs.SetInt("fueltostart", fueled);
                text.text = fueled.ToString();
            }
            else
            {
                if(maxfuel != 0)
                {
                fuel2 = PlayerPrefs.GetInt("fuel", 0);
                int selected = Mathf.RoundToInt(fuelSlider.value);

                // не даём выбрать больше, чем есть топлива
                selected = Mathf.Clamp(selected, 0, fuel2);

                PlayerPrefs.SetInt("fueltostart", selected);
                text.text = selected.ToString();
                }
                else
                {
                    fuel2 = 0;
                    text.text = "0";
                }
            }
        }

        if(delay <= 0)
            isdelay = false;
    }

    void OnSliderChanged(float value)
    {
        // Проверяем, было ли движение реально от игрока
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            Debug.Log("fd");

            if (maxfuel == 0 && isdelay != true)
            {
                zeroTanks.Play("Start3");
                delay = 3;
                isdelay = true;
            }

            userChangedSlider = true;
        }
    }
}
