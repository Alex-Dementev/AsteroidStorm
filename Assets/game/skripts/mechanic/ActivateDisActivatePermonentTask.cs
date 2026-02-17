using UnityEngine;

public class ActivateDisActivatePermonentTask : MonoBehaviour
{
    public GameObject go;
    public Animator ActivateAnim;
    
    public void Activate()
    {
        go.SetActive(true);
        ActivateAnim.CrossFade("Start", 0.2f);
    }

    public void DisActivate()
    {
        ActivateAnim.CrossFade("End", 0.2f);
    }
    public void EventDisActivate()
    {
        go.SetActive(false);
    }
}
