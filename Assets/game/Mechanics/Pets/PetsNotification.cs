using UnityEngine;

public class PetsNotification : MonoBehaviour
{
    public Animator anim;


    void Update()
    {
        if(PlayerPrefs.GetInt("PetsDialogue", 0) == 0)
        {
            anim.SetBool("Bool", false);

            if(PlayerPrefs.GetInt("P1Buy", 0) == 1 && PlayerPrefs.GetInt("P1Apply", 0) == 0)
            {
                anim.SetBool("Bool", true);
            }
            if(PlayerPrefs.GetInt("P2Buy", 0) == 1 && PlayerPrefs.GetInt("P2Apply", 0) == 0)
            {
                anim.SetBool("Bool", true);
            }
            if(PlayerPrefs.GetInt("P3Buy", 0) == 1 && PlayerPrefs.GetInt("P3Apply", 0) == 0)
            {
                anim.SetBool("Bool", true);
            }
            if(PlayerPrefs.GetInt("P4Buy", 0) == 1 && PlayerPrefs.GetInt("P4Apply", 0) == 0)
            {
                anim.SetBool("Bool", true);
            }
            if(PlayerPrefs.GetInt("P5Buy", 0) == 1 && PlayerPrefs.GetInt("P5Apply", 0) == 0)
            {
                anim.SetBool("Bool", true);
            }
        }
        else
            anim.SetBool("Bool", false);
    }

    public void DissableNotifications()
    {
        if(PlayerPrefs.GetInt("P1Buy", 0) == 1 && PlayerPrefs.GetInt("P1Apply", 0) == 0)
        {
            PlayerPrefs.SetInt("P1Apply", 1);
            anim.SetBool("Bool", false);
        }
        if(PlayerPrefs.GetInt("P2Buy", 0) == 1 && PlayerPrefs.GetInt("P2Apply", 0) == 0)
        {
            PlayerPrefs.SetInt("P2Apply", 1);
            anim.SetBool("Bool", false);
        }
        if(PlayerPrefs.GetInt("P3Buy", 0) == 1 && PlayerPrefs.GetInt("P3Apply", 0) == 0)
        {
            PlayerPrefs.SetInt("P3Apply", 1);
            anim.SetBool("Bool", false);
        }
        if(PlayerPrefs.GetInt("P4Buy", 0) == 1 && PlayerPrefs.GetInt("P4Apply", 0) == 0)
        {
            PlayerPrefs.SetInt("P4Apply", 1);
            anim.SetBool("Bool", false);
        }
        if(PlayerPrefs.GetInt("P5Buy", 0) == 1 && PlayerPrefs.GetInt("P5Apply", 0) == 0)
        {
            PlayerPrefs.SetInt("P5Apply", 1);
            anim.SetBool("Bool", false);
        }
    }
}
