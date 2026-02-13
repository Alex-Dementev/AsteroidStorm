using UnityEngine;

public class OpenShakeToCoinsPanel : MonoBehaviour
{
    private int Coll;
    public Animator ActivateAnim;
    public GameObject go;

    public void Open()
    {
        Coll++;

        if(Coll >= 50)
        {
            go.SetActive(true);
            ActivateAnim.Play("Start");
            Coll = 0;
        }
    }
}
