using UnityEngine;

public class StartGame : MonoBehaviour
{
    public bool Starts;

    public GameObject Go1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Starts && PlayerPrefs.GetInt("AchDialogue", 0) == 0)
        {
            Go1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
