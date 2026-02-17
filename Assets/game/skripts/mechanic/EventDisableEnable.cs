using UnityEngine;

public class EventDissableEnable : MonoBehaviour
{
    public GameObject[] go;

    public void Activate()
    {
        for(int i = 0; i < go.Length; i++)
        {
            go[i].SetActive(true);
        }
    }

    public void DisActivate()
    {
        for(int i = 0; i < go.Length; i++)
        {
            go[i].SetActive(false);
        }
    }
}
