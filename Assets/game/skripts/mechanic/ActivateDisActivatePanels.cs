using UnityEngine;

public class ActivateDisActivatePanels : MonoBehaviour
{
    public GameObject go;
    public Animator ActivateAnim;
    private float isOpen;

    public bool IsAch = false;
    
    public void Activate()
    {
        if(!go.activeSelf)
        {
            go.SetActive(true);
            ActivateAnim.Play("Start");
        }
    }

    public void DisActivate()
    {
        if(isOpen <= 0)
            ActivateAnim.Play("End");
    }
    public void EventDisActivate()
    {
        go.SetActive(false);

        if(IsAch)
            PlayerPrefs.SetInt("IsActivateAchPanel", 0);
    }

    private void OnEnable()
    {
        isOpen = 0.6f;
    }
    private void Update()
    {
        isOpen -= Time.deltaTime;
    }
}

