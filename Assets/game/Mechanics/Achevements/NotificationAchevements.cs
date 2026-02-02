using UnityEngine;

public class NotificationAchevements : MonoBehaviour
{
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateAch();
    }

    private void OnEnable()
    {
        UpdateAch();
    }

    public void UpdateAch()
    {
        if(PlayerPrefs.GetInt("ach1", 0) == 1 || PlayerPrefs.GetInt("ach2", 0) == 1 || PlayerPrefs.GetInt("ach3", 0) == 1 || PlayerPrefs.GetInt("ach4", 0) == 1 || PlayerPrefs.GetInt("ach5", 0) == 1)
            anim.SetBool("Notification", true);
        else
            anim.SetBool("Notification", false);
    }
}
