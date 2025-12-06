using UnityEngine;
using UnityEngine.UI;

public class GivePermonentTasks : MonoBehaviour
{
    public int Type;
    public int Level;
    public Text LevelT1;
    public Text LevelT2;
    public Text LevelT3;
    public Text LevelT4;
    public PermanentTasks PT1;
    public PermanentTasks PT2;
    public PermanentTasks PT3;
    public PermanentTasks PT4;
    public AudioSource Approve;
    public int Coll;
    

    public void Click()
    {
        Type = PlayerPrefs.GetInt("IndexTypeToPermonentTasks", 0);

        if(Type == 1 && PlayerPrefs.GetInt("AllColl", 0) <= PlayerPrefs.GetInt("PermanentTaskFuel", 0))
        {
            Level = PlayerPrefs.GetInt("LevelTask1", 0);
            Level++;
            PlayerPrefs.SetInt("LevelTask1", Level);
            LevelT1.text = ("Уровень: " + Level + "/3");
            Coll = PlayerPrefs.GetInt("PermanentTaskFuel", 0) - PlayerPrefs.GetInt("AllColl", 0);
            PlayerPrefs.SetInt("PermanentTaskFuel", Coll);
            PT1.UpdateDesc();
            Approve.Play();
            PlayerPrefs.SetInt("fuelIsActivateTask", 1);
        }   
        if(Type == 2 && PlayerPrefs.GetInt("AllColl", 0) <= PlayerPrefs.GetInt("PermanentTaskEnergy", 0))
        {
            Level = PlayerPrefs.GetInt("LevelTask2", 0);
            Level++;
            PlayerPrefs.SetInt("LevelTask2", Level);
            LevelT2.text = ("Уровень: " + Level + "/3");
            Coll = PlayerPrefs.GetInt("PermanentTaskEnergy", 0) - PlayerPrefs.GetInt("AllColl", 0);
            PlayerPrefs.SetInt("PermanentTaskEnergy", Coll);
            PT1.UpdateDesc();
            Approve.Play();
        }   
        if(Type == 3 && PlayerPrefs.GetInt("AllColl", 0) <= PlayerPrefs.GetInt("PermanentTaskLife", 0))
        {
            Level = PlayerPrefs.GetInt("LevelTask3", 0);
            Level++;
            PlayerPrefs.SetInt("LevelTask3", Level);
            LevelT3.text = ("Уровень: " + Level + "/3");
            Coll = PlayerPrefs.GetInt("PermanentTaskLife", 0) - PlayerPrefs.GetInt("AllColl", 0);
            PlayerPrefs.SetInt("PermanentTaskLife", Coll);
            PT1.UpdateDesc();
            Approve.Play();
        }   
        if(Type == 4 && PlayerPrefs.GetInt("AllColl", 0) <= PlayerPrefs.GetInt("PermanentTaskMetalls", 0))
        {
            Level = PlayerPrefs.GetInt("LevelTask4", 0);
            Level++;
            PlayerPrefs.SetInt("LevelTask4", Level);
            LevelT4.text = ("Уровень: " + Level + "/3");
            Coll = PlayerPrefs.GetInt("PermanentTaskMetalls", 0) - PlayerPrefs.GetInt("AllColl", 0);
            PlayerPrefs.SetInt("PermanentTaskMetalls", Coll);
            PT1.UpdateDesc();
            Approve.Play();
            PlayerPrefs.SetInt("MetalsIsActivateTask", 1);
        }   
    }
}
