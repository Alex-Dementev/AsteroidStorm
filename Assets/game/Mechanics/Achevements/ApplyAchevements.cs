using UnityEngine;

public class ApplyAchevements : MonoBehaviour
{
    public GameObject[] Object;
    public Animator[] Anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.GetInt("ach1", 0) == 2)
        {
            Object[0].SetActive(true);
        }
        if(PlayerPrefs.GetInt("ach2", 0) == 2)
        {
            Object[1].SetActive(true);
        }
        if(PlayerPrefs.GetInt("ach3", 0) == 2)
        {
            Object[2].SetActive(true);
        }
        if(PlayerPrefs.GetInt("ach4", 0) == 2)
        {
            Object[3].SetActive(true);
        }
        if(PlayerPrefs.GetInt("ach5", 0) == 2)
        {
            Object[4].SetActive(true);
        }
    }

    public void Apply()
    {
        if(PlayerPrefs.GetInt("ach1", 0) == 1)
        {
            Object[0].SetActive(true);
            Anim[0].Play("FirstActivate");
            PlayerPrefs.SetInt("ach1", 1);
        }
        if(PlayerPrefs.GetInt("ach2", 0) == 1)
        {
            Object[1].SetActive(true);
            Anim[1].Play("FirstActivate");
            PlayerPrefs.SetInt("ach2", 1);
        }
        if(PlayerPrefs.GetInt("ach3", 0) == 1)
        {
            Object[2].SetActive(true);
            Anim[2].Play("FirstActivate");
            PlayerPrefs.SetInt("ach3", 1);
        }
        if(PlayerPrefs.GetInt("ach4", 0) == 1)
        {
            Object[3].SetActive(true);
            Anim[3].Play("FirstActivate");
            PlayerPrefs.SetInt("ach4", 1);
        }
        if(PlayerPrefs.GetInt("ach5", 0) == 1)
        {
            Object[4].SetActive(true);
            Anim[4].Play("FirstActivate");
            PlayerPrefs.SetInt("ach5", 1);
        }
    }
}
