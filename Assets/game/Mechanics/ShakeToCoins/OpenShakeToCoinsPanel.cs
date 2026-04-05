using UnityEngine;

public class OpenShakeToCoinsPanel : MonoBehaviour
{
    private int Coll;
    public Animator ActivateAnim;
    public GameObject go;

    public void Open()
    {
        Coll++;

        if(Coll >= 50 && PlayerPrefs.GetInt("IndexDialogue", 0) >= 21)
        {
            go.SetActive(true);
            ActivateAnim.Play("Start");
            Coll = 0;
        }
    }
}
