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
            SceneManager.LoadScene("scenestart");
        }
    }
}
