using UnityEngine;

public class PetsNotification : MonoBehaviour
{
    public Animator anim;


    void Update()
    {
        if(PlayerPrefs.GetInt("PetsDialogue", 0) == 0)
        {
            anim.SetBool("Bool", false);

            if(PlayerPrefs.GetInt("P1Buy", 0) == 1)
            {
                anim.SetBool("Bool", true);
            }
            if(PlayerPrefs.GetInt("P2Buy", 0) == 1)
            {
                anim.SetBool("Bool", true);
            }
            if(PlayerPrefs.GetInt("P3Buy", 0) == 1)
            {
                anim.SetBool("Bool", true);
            }
            if(PlayerPrefs.GetInt("P4Buy", 0) == 1)
            {
                anim.SetBool("Bool", true);
            }
            if(PlayerPrefs.GetInt("P5Buy", 0) == 1)
            {
                anim.SetBool("Bool", true);
            }
        }
        else
            anim.SetBool("Bool", false);
    }
}
