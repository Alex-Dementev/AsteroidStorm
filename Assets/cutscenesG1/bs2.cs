using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bs2 : MonoBehaviour
{
    public Text t;

    void Start()
    {
        if(PlayerPrefs.GetInt("fall", 0) == 1)
        t.text = "ПОРНО";
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("cutsceneG1_2");
    }
    public void nextScene()
    {
        SceneManager.LoadScene("final glav 1");
    }
}
