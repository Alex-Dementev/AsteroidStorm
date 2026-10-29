using UnityEngine;
using UnityEngine.UI;

public class NotificationAchevements : MonoBehaviour
{
    public Animator anim;
    public GameObject Controller;
    private float isDelay;
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

    void Update()
    {
        isDelay -= Time.deltaTime;

        if(isDelay >= 0) return;

        isDelay = 1;

        if(PlayerPrefs.GetInt("Ach2Level", 0) != PlayerPrefs.GetInt("Ach2LevelPrevious", -1) && PlayerPrefs.GetInt("ach2", 0) == 2 || PlayerPrefs.GetInt("ach2", 0) == 1)
            Controller.SetActive(true);
        else if(PlayerPrefs.GetInt("Ach3Level", 0) != PlayerPrefs.GetInt("Ach3LevelPrevious", -1) && PlayerPrefs.GetInt("ach3", 0) == 2 || PlayerPrefs.GetInt("ach3", 0) == 1)
            Controller.SetActive(true);
        else if(PlayerPrefs.GetInt("g2passed", 0) == 1 && PlayerPrefs.GetInt("Ach4Start2", 0) == 0 || PlayerPrefs.GetInt("g1passed", 0) == 1 && PlayerPrefs.GetInt("Ach4Start", 0) == 0)
            Controller.SetActive(true);
        else if(PlayerPrefs.GetInt("Ach5Level", 0) != PlayerPrefs.GetInt("Ach5LevelPrevious", -1) && PlayerPrefs.GetInt("ach5", 0) == 2 || PlayerPrefs.GetInt("ach5", 0) == 1)
            Controller.SetActive(true);
        else if(PlayerPrefs.GetInt("Ach6Level", 0) != PlayerPrefs.GetInt("Ach6LevelPrevious", -1) && PlayerPrefs.GetInt("ach6", 0) == 2 || PlayerPrefs.GetInt("ach6", 0) == 1)
            Controller.SetActive(true);
        else if(PlayerPrefs.GetInt("Ach7Level", 0) != PlayerPrefs.GetInt("Ach7LevelPrevious", -1) && PlayerPrefs.GetInt("ach7", 0) == 2 || PlayerPrefs.GetInt("ach7", 0) == 1)
            Controller.SetActive(true);
        else
            Controller.SetActive(false);
    }
}
