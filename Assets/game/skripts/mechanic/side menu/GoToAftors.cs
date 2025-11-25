using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAftors : MonoBehaviour
{
    public void GoToAftorsScene()
    {
        SceneManager.LoadScene("Aftors");
    }
    public void GoToMenuScene()
    {
        SceneManager.LoadScene("main");
    }
}
