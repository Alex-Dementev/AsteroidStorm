using UnityEngine;

public class Achivements : MonoBehaviour
{
    public Animator Camera;
    public Animator Canvass;

    public GameObject Island;
    public GameObject PetsButton;


    void Start()
    {
        if(PlayerPrefs.GetInt("ach1", 0) == 2)
            Island.SetActive(true);

        if(PlayerPrefs.GetInt("Ach5Level0", 0) == 4 && PlayerPrefs.GetInt("Ach5Level", 0) == 0)
            PlayerPrefs.SetInt("Ach5Level", 1);
        
        if(PlayerPrefs.GetInt("ach2", 0) == 2)
        {
            if(PlayerPrefs.GetInt("FuelZero", 0) == 1 && PlayerPrefs.GetInt("Ach2Level", 0) == 0)
                PlayerPrefs.SetInt("Ach2Level", 1);

            if(PlayerPrefs.GetInt("Ach2Level", 0) == 3)
            {
                PlayerPrefs.SetInt("Ach2Level", 4);
                PetsButton.SetActive(true);
                int Pet = PlayerPrefs.GetInt("P3", 0);
                Pet++;
                PlayerPrefs.SetInt("P3", Pet);
                PlayerPrefs.SetInt("P3Buy", 1);
            }
        }

        if(PlayerPrefs.GetInt("SattelliteFall", 0) == 1 && PlayerPrefs.GetInt("Ach3Level", 0) == 3)
        {
            PlayerPrefs.SetInt("Ach3Level", 4);
            PlayerPrefs.SetInt("SattelliteFall", 0);
            PlayerPrefs.SetInt("Skin3", 1);
        }
    }

    public void Open()
    {
        Camera.Play("Camera");
        Canvass.Play("AchAnim");
    }

    public void Close()
    {
        Camera.Play("Camera 0");
        Canvass.Play("AchAnim 0");
    }
}
