using UnityEngine;
using UnityEngine.UI;

public class ScoreBuff : MonoBehaviour
{
    public int Score;
    public int coins;
    public int allcoins;
    public Slider s;
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            coins += 320;
            allcoins += 320;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("allcoins", allcoins);
            anim.Play("start");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
