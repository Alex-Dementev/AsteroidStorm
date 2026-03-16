using UnityEngine;

public class ActivateObjects : MonoBehaviour
{
    public GameObject Activate;
    public GameObject DisActivate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EventActivate()
    {
        Activate.SetActive(true);
    }
    public void EventDisActivate()
    {
        DisActivate.SetActive(false);
    }
}
