using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSend : MonoBehaviour
{
    public void GoToAftorsScene()
    {
        SceneManager.LoadScene("Aftors");
    }
    public void GoToMenuScene()
    {
        SceneManager.LoadScene("main");
    }
    public void GoToPrologueScene()
    {
        SceneManager.LoadScene("scenetoproblem");
    }
    public void GoToGameScene()
    {
        if(PlayerPrefs.GetInt("start", 0) == 1)
        {
            if(PlayerPrefs.GetInt("g2passed", 0) == 1)
                SceneManager.LoadScene("3GlavStart");
            else if(PlayerPrefs.GetInt("g1passed", 0) == 1 && PlayerPrefs.GetInt("Rest", 25000) <= 0)
                SceneManager.LoadScene("2GlavStart");
            else 
                SceneManager.LoadScene("scenestart");
        }
    }
}
