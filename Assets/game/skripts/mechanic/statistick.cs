using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statistick : MonoBehaviour
{
    public float alltime;
    public Text alltimeT;
    public int allscore;
    public Text allscoreT;
    public int allgames;
    public Text gamesPlayed;
    public int allcoinsadd;
    public Text coins;
    public int recordf;
    public Text record;

    void Start()
    {
        recordf = PlayerPrefs.GetInt("maxScore", 0);
        record.text = recordf.ToString();
        allscore = PlayerPrefs.GetInt("allscore", 0);
        allscoreT.text = allscore.ToString("F0");
        allgames = PlayerPrefs.GetInt("allgames", 0);
        gamesPlayed.text = allgames.ToString("F0");
    }


    void Update()
    {
        alltime = PlayerPrefs.GetFloat("alltimes", 0);
        alltimeT.text = alltime.ToString("F0");
        allcoinsadd = PlayerPrefs.GetInt("allcoins", 0);
        coins.text = allcoinsadd.ToString("F0");
    }
}
