using UnityEngine;

public class ActivateDisActivatePanels : MonoBehaviour
{
    public GameObject go;
    public Animator ActivateAnim;

    public bool IsAch = false;
    
    public void Activate()
    {
        go.SetActive(true);
        ActivateAnim.Play("Start");
    }

    public void DisActivate()
    {
        ActivateAnim.Play("End");
    }
    public void EventDisActivate()
    {
        go.SetActive(false);

        if(IsAch = true)
            PlayerPrefs.SetInt("IsActivateAchPanel", 0);
    }
}

