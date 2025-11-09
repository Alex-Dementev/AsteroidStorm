using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalGlavComplete : MonoBehaviour
{
    public AudioSource ad;
    public GameObject BS;
    public Animator ABS;
    public void Audio()
    {
        ad.Play();
    }
    public void BStoEnd()
    {
        BS.SetActive(true);
        ABS.Play("blackscreen");
    }
    public void End()
    {
        if (PlayerPrefs.GetInt("youdead", 0) == 0)
            SceneManager.LoadScene("final g1");
    }
}
