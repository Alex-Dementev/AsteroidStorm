using UnityEngine;

public class SkinsPaste : MonoBehaviour
{
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;

    void Start()
    {
        int currentSkin = PlayerPrefs.GetInt("CurrentSkin", 3); // По умолчанию - Skin4
        ShowSkin(currentSkin);
    }

    private void ShowSkin(int index)
    {
        PlayerPrefs.SetInt("Skin1", 1);
        PlayerPrefs.SetInt("Skin2", 1);
        PlayerPrefs.SetInt("Skin3", 1);
        PlayerPrefs.SetInt("Skin5", 1);
        // Выключаем все скины
        if (s1) s1.SetActive(false);
        if (s2) s2.SetActive(false);
        if (s3) s3.SetActive(false);
        if (s4) s4.SetActive(false);
        if (s5) s5.SetActive(false);

        // Включаем нужный, если он доступен
        if (index == 0 && PlayerPrefs.GetInt("Skin1", 0) == 1 && s1)
            s1.SetActive(true);
        else if (index == 1 && PlayerPrefs.GetInt("Skin2", 0) == 1 && s2)
            s2.SetActive(true);
        else if (index == 2 && PlayerPrefs.GetInt("Skin3", 0) == 1 && s3)
            s3.SetActive(true);
        else if (index == 3 && s4)
            s4.SetActive(true);
        else if (index == 4 && PlayerPrefs.GetInt("Skin5", 0) == 1 && s5)
            s5.SetActive(true);
    }
}
