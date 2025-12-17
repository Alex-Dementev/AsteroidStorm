using UnityEngine;

public class ClosePastePanels : MonoBehaviour
{
    public GameObject GO;
    public void DisActivate()
    {
        GO.SetActive(false);
    }
}
