using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathGo : MonoBehaviour
{
    public void restartReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void restartLoad()
    {
        SceneManager.LoadScene("scenestart");
    }
    public void gotohome()
    {
        SceneManager.LoadScene("main");
    }
}
