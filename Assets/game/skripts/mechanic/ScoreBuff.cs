using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBuff : MonoBehaviour
{
    private int Score;
    private int coins;
    private int coinsplus;
    private int allcoins;
    public Slider s;
    public Animator anim;
    public Animator anim2;
    private int SubdivInt;
    public SmartBoostTimer SBT;
    public Text PlusT;
    private bool Is675;
    private bool IsOne;
    private bool IsOne2;
    private float IsDelay = 0.6f;


    void Start()
    {
        Score = PlayerPrefs.GetInt("ScoreBuff", 0);
        SubdivInt = PlayerPrefs.GetInt("ScoreNum", 0);

        if(SubdivInt == 0)
        {
            anim2.SetBool("1", true);
        }
        if(SubdivInt == 1)
        {
            anim2.SetBool("2", true);
        }
        if(SubdivInt == 2)
        {
            anim2.SetBool("3", true);
        }
        if(SubdivInt == 3)
        {
            anim2.SetBool("4", true);
        }
        if(SubdivInt >= 4)
        {
            anim2.SetBool("5", true);
        }

        s.value = PlayerPrefs.GetInt("ScoreLost", 0);

        Debug.Log("Полученные очки: " + Score);
    }

    void Update()
    {
        IsDelay -= Time.deltaTime;


        UpdateBuff();


        if(SubdivInt == 0)
        {
            anim2.SetBool("1", true);
        }
        if(SubdivInt == 1)
        {
            anim2.SetBool("2", true);
            anim2.SetBool("1", false);
        }
        if(SubdivInt == 2)
        {
            anim2.SetBool("3", true);
            anim2.SetBool("2", false);
        }
        if(SubdivInt == 3)
        {
            anim2.SetBool("4", true);
            anim2.SetBool("3", false);
        }
        if(SubdivInt >= 4)
        {
            anim2.SetBool("5", true);
            anim2.SetBool("4", false);
        }

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

    public void DelayedAction()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        allcoins = PlayerPrefs.GetInt("allcoins", 0);
        coins += coinsplus;
        allcoins += coinsplus;
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("allcoins", allcoins);
        PlayerPrefs.SetInt("ScoreBuffTimer", 1);
        SBT.RestartTimer();

        if(coinsplus != 0)
        {
            anim.Play("start");
            PlusT.text = "+" + coinsplus;
        }

        coinsplus = 0;
    }

    private void UpdateBuff()
    {
        if(IsDelay <= 0)
        {
            if(Is675)
            {
                if(!IsOne)
                {
                    StartCoroutine(DelayedActionCoroutine());
                    IsOne = true;
                }

                if(IsOne2)
                    s.value = Mathf.MoveTowards(s.value, 0, Time.deltaTime * 500);

                if(s.value <= 1)
                {
                    Is675 = false;
                    IsOne2 = false;
                }
            }
            else if(!Is675)
            {
                s.value = Mathf.MoveTowards(s.value, Score, Time.deltaTime * 200);

                if(s.value >= 675)
                {
                    IsOne = false;
                    Is675 = true;
                    Score -= 675;
                    PlayerPrefs.SetInt("ScoreBuff", Score);
                    PlayerPrefs.SetInt("ScoreLost", Score);

                    SubdivInt = PlayerPrefs.GetInt("ScoreNum", 0);

                    if(SubdivInt == 0)
                    {
                        coinsplus += 67;
                    }
                    if(SubdivInt == 1)
                    {
                        coinsplus += 78;
                    }
                    if(SubdivInt == 2)
                    {
                        coinsplus += 88;
                    }
                    if(SubdivInt == 3)
                    {
                        coinsplus += 97;
                    }
                    if(SubdivInt >= 4)
                    {
                        coinsplus += 110;
                    }
                    
                    SubdivInt++;
                    PlayerPrefs.SetInt("ScoreNum", SubdivInt);
                    SBT.RestartTimer();
                    DelayedAction();
                }
                else if(Score < 675)
                    PlayerPrefs.SetInt("ScoreLost", Score);
            }
        }
    }

    IEnumerator DelayedActionCoroutine()
    {
        yield return new WaitForSeconds(1.2f);
        
        IsOne2 = true;
    }
}
