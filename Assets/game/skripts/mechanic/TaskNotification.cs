using UnityEngine;

public class TaskNotification : MonoBehaviour
{
    public Animator Task;
    private bool AnyTrue;
    private bool WasActive;

    void Update()
    {
        AnyTrue = false;

        if(PlayerPrefs.GetInt("LevelTask1", 0) == 0 && 200 <= PlayerPrefs.GetInt("PermanentTaskFuel", 0))
            AnyTrue = true;
        if(PlayerPrefs.GetInt("LevelTask1", 0) == 1 && 500 <= PlayerPrefs.GetInt("PermanentTaskFuel", 0))
            AnyTrue = true;
        if(PlayerPrefs.GetInt("LevelTask1", 0) == 2 && 1000 <= PlayerPrefs.GetInt("PermanentTaskFuel", 0))
            AnyTrue = true;

        if(PlayerPrefs.GetInt("LevelTask2", 0) == 0 && 600 <= PlayerPrefs.GetInt("PermanentTaskEnergy", 0))
            AnyTrue = true;
        if(PlayerPrefs.GetInt("LevelTask2", 0) == 1 && 2000 <= PlayerPrefs.GetInt("PermanentTaskEnergy", 0))
            AnyTrue = true;
        if(PlayerPrefs.GetInt("LevelTask2", 0) == 2 && 5000 <= PlayerPrefs.GetInt("PermanentTaskEnergy", 0))
            AnyTrue = true;

        if(PlayerPrefs.GetInt("LevelTask3", 0) == 0 && 15 <= PlayerPrefs.GetInt("PermanentTaskLife", 0))
            AnyTrue = true;
        if(PlayerPrefs.GetInt("LevelTask3", 0) == 1 && 35 <= PlayerPrefs.GetInt("PermanentTaskLife", 0))
            AnyTrue = true;
        if(PlayerPrefs.GetInt("LevelTask3", 0) == 2 && 135 <= PlayerPrefs.GetInt("PermanentTaskLife", 0))
            AnyTrue = true;

        if(PlayerPrefs.GetInt("LevelTask4", 0) == 0 && 350 <= PlayerPrefs.GetInt("PermanentTaskMetals", 0))
            AnyTrue = true;
        if(PlayerPrefs.GetInt("LevelTask4", 0) == 1 && 650 <= PlayerPrefs.GetInt("PermanentTaskMetals", 0))
            AnyTrue = true;
        if(PlayerPrefs.GetInt("LevelTask4", 0) == 2 && 1300 <= PlayerPrefs.GetInt("PermanentTaskMetals", 0))
            AnyTrue = true;

        if(AnyTrue && !WasActive)
        {
            PlayerPrefs.SetInt("isDisActivateAnimTask2", 1);
            Task.SetBool("IsTrue", true);
            WasActive = true;
        }
        if(!AnyTrue && WasActive)
        {
            PlayerPrefs.SetInt("isDisActivateAnimTask2", 0);

            if(PlayerPrefs.GetInt("isDisActivateAnimTask1", 0) == 0)
            {
                Task.SetBool("IsTrue", false);
                WasActive = false;
            }
        }
    }
}
