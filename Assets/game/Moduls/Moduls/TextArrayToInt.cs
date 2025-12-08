using UnityEngine;
using UnityEngine.UI;

public class TextArrayToInt : MonoBehaviour
{
    [Header("Массив UI Text")]
    public Text[] textArray;

    [Header("Ключ для PlayerPrefs")]
    public string playerPrefsKey = "SavedValue";

    [Header("Сумма значений")]
    private int totalValue = 0;

    void Update()
    {
        totalValue = 0;

        foreach (Text t in textArray)
        {
            int value;
            if (int.TryParse(t.text, out value))
            {
                totalValue += value;
            }
        }

        PlayerPrefs.SetInt(playerPrefsKey, totalValue);
        PlayerPrefs.Save();
    }
}