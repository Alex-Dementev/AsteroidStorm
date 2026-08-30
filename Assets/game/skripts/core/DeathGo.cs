using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathGo : MonoBehaviour
{
    public bool is2Glav;
    public bool isIntermediate;
    public bool isFinal;
    public Animator anim;
    public void restartReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PlayAnimator()
    {
        anim.Play("anim10 3");
    }
    public void restartLoad()
    {
        if(isIntermediate)
            SceneManager.LoadScene("IntermediateScene");
        if(is2Glav)
            SceneManager.LoadScene("2GlavStart");
        else
            SceneManager.LoadScene("scenestart");

        if(isFinal)
        {
            PlayerPrefs.SetInt("isfinal", 1);
            SceneManager.LoadScene("Scenetoproblem");
        }
    }
    public void gotohome()
    {
        SceneManager.LoadScene("main");
    }
    public void GoToNextPart()
    {
        if(PlayerPrefs.GetInt("3GlavStarted", 0) == 1)
        {   
            if(Score2GFirst.Quality >= 40)
                SceneManager.LoadScene("3GlavFinal");
            else
                SceneManager.LoadScene("3GlavStart");
        }
        else
            SceneManager.LoadScene("2Glav2Part");
    }
}
