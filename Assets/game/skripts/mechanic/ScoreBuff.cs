using UnityEngine;
using UnityEngine.UI;

public class ScoreBuff : MonoBehaviour
{
    public int Score;
    public int coins;
    public int allcoins;
    public Slider s;
    public Animator anim;


    void Start()
    {
        Score = PlayerPrefs.GetInt("ScoreBuff", 0);
        s.value = Score;

        if(Score >= 8000)
        {
            Score -= 8000;
            s.value = Score;
            PlayerPrefs.SetInt("ScoreBuff", Score);
            coins = PlayerPrefs.GetInt("coins", 0);
            allcoins = PlayerPrefs.GetInt("allcoins", 0);
            coins += 175;
            allcoins += 175;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("allcoins", allcoins);
            anim.Play("start");
        }
    }
}
