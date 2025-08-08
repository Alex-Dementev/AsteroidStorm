using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneman : MonoBehaviour
{
    public int coins;
    public Text ctext;
    void Update()
    {
        coins = PlayerPrefs.GetInt("coins");
        ctext.text = "" + coins + " монет";
    }
}
