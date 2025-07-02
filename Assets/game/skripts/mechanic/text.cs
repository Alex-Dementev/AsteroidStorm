using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneman : MonoBehaviour
{
    public int maxScore;
    public int coins;
    public Text mtext;
    public Text ctext;

    void Start()
    {
        maxScore = PlayerPrefs.GetInt("maxScore", 0);
        mtext.text = "максимально очков:" + maxScore;
    }

    void Update()
    {
        PlayerPrefs.SetInt("maxScore", maxScore);
        coins = PlayerPrefs.GetInt("coins");
        ctext.text = "космические монеты:" + coins;
    }
}
