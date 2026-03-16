using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathGo : MonoBehaviour
{
    public bool is2Glav;
    public void restartReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void restartLoad()
    {
        if(!is2Glav)
            SceneManager.LoadScene("scenestart");
        else
            SceneManager.LoadScene("2GlavStart");
    }
    public void gotohome()
    {
        SceneManager.LoadScene("main");
    }
}
