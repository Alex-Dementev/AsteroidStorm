using UnityEngine;
using UnityEngine.UI;

public class ScoreBuff : MonoBehaviour
{
    private int Score;
    private int coins;
    private int allcoins;
    public Slider s;
    public Animator anim;
    public Animator anim2;
    public Image Subdiv;
    private int SubdivInt;
    public SmartBoostTimer SBT;
    public Text PlusT;


    void Start()
    {
        Score = PlayerPrefs.GetInt("ScoreBuff", 0);
        s.value = Score;

        if(PlayerPrefs.GetInt("ScoreNum", 0) == 0)
        {
            anim2.SetBool("1", true);
        }
        if(PlayerPrefs.GetInt("ScoreNum", 0) == 1)
        {
            anim2.SetBool("2", true);
        }
        if(PlayerPrefs.GetInt("ScoreNum", 0) == 2)
        {
            anim2.SetBool("3", true);
        }
        if(PlayerPrefs.GetInt("ScoreNum", 0) == 3)
        {
            anim2.SetBool("4", true);
        }
        if(PlayerPrefs.GetInt("ScoreNum", 0) == 4)
        {
            anim2.SetBool("5", true);
        }

        if(Score >= 675)
        {
            Score -= 675;
            s.value = Score;
            PlayerPrefs.SetInt("ScoreBuff", Score);
            coins = PlayerPrefs.GetInt("coins", 0);
            allcoins = PlayerPrefs.GetInt("allcoins", 0);
            SubdivInt = PlayerPrefs.GetInt("ScoreNum", 0) + 1; 
            PlayerPrefs.SetInt("ScoreNum", SubdivInt);

            if(PlayerPrefs.GetInt("ScoreNum", 0) == 0)
            {
                coins += 67;
                allcoins += 67;
                anim2.SetBool("1", true);
                PlusT.text = "+67";
            }
            if(PlayerPrefs.GetInt("ScoreNum", 0) == 1)
            {
                coins += 78;
                allcoins += 78;
                anim2.SetBool("2", true);
                PlusT.text = "+78";
            }
            if(PlayerPrefs.GetInt("ScoreNum", 0) == 2)
            {
                coins += 88;
                allcoins += 88;
                anim2.SetBool("3", true);
                PlusT.text = "+88";
            }
            if(PlayerPrefs.GetInt("ScoreNum", 0) == 3)
            {
                coins += 97;
                allcoins += 97;
                anim2.SetBool("4", true);
                PlusT.text = "+97";
            }
            if(PlayerPrefs.GetInt("ScoreNum", 0) >= 4)
            {
                coins += 110;
                allcoins += 110;
                anim2.SetBool("5", true);
                PlusT.text = "+110";
            }

            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("allcoins", allcoins);
            anim.Play("start");
            PlayerPrefs.SetInt("ScoreBuffTimer", 1);
            SBT.RestartTimer();
        }
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("ScoreBuffTimer", 0) == 2)
        {
            PlayerPrefs.SetInt("ScoreBuffTimer", 0);
            PlayerPrefs.SetInt("ScoreNum", 0);
            anim2.SetBool("1", false);
            anim2.SetBool("2", false);
            anim2.SetBool("3", false);
            anim2.SetBool("4", false);
            anim2.SetBool("5", false);
        }
    }
}
