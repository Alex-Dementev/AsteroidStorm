using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statistick : MonoBehaviour
{
    public Text alltimeT;
    public Text metallsT;
    public Text buymodulsT;
    public Text healthT;
    public Text buypetsT;
    public Text buyedtanksT;
    public Text playmultiplayerT;
    public Text destroyasteroidsT;
    public Text upperasteroidsT;
    public Text fuelminusT;
    public Text energyminusT;
    public Text allscoreT;
    public Text creditsT;
    public Text casinoT;
    public Text gamesplayedT;
    public Text coinsT;
    public Text recordT;
    public Text taskT;
    private float Delay;

    void Start()
    {
        recordT.text = PlayerPrefs.GetInt("maxScore", 0).ToString();
        allscoreT.text = PlayerPrefs.GetInt("allscore", 0).ToString();
        gamesplayedT.text = PlayerPrefs.GetInt("allgames", 0).ToString();
        metallsT.text = PlayerPrefs.GetFloat("AllAsteroidsMass", 0).ToString("F1") + "т";
        destroyasteroidsT.text = PlayerPrefs.GetInt("AllDestroyedAsteroids", 0).ToString() + "шт";
        upperasteroidsT.text = PlayerPrefs.GetInt("AllUpperAsteroids", 0).ToString() + "шт";
        playmultiplayerT.text = PlayerPrefs.GetInt("AllMultiplayerGames", 0).ToString();
    }


    void Update()
    {
        Delay -= Time.deltaTime;

        if(Delay <= 0)
        { 
            alltimeT.text = PlayerPrefs.GetFloat("alltimes", 0).ToString("F0") + "с";
            coinsT.text = PlayerPrefs.GetInt("allcoins", 0).ToString();
            taskT.text = PlayerPrefs.GetInt("alltask", 0).ToString();
            creditsT.text = PlayerPrefs.GetInt("AllCredits", 0).ToString();
            buymodulsT.text = PlayerPrefs.GetInt("AllBuyedModuls", 0).ToString() + "шт";
            buypetsT.text = PlayerPrefs.GetInt("AllBuyedPets", 0).ToString() + "шт";
            casinoT.text = PlayerPrefs.GetInt("Casino", 0).ToString();
            buyedtanksT.text = PlayerPrefs.GetInt("AllTanks", 0).ToString() + "шт";
            healthT.text = PlayerPrefs.GetInt("AllLives", 0).ToString() + "шт";

            float MinusFuel = PlayerPrefs.GetFloat("Genertors1Fuel", 0);
            MinusFuel += PlayerPrefs.GetFloat("Genertors2Fuel", 0);
            MinusFuel += PlayerPrefs.GetFloat("Genertors3Fuel", 0);
            MinusFuel += PlayerPrefs.GetFloat("Genertors4Fuel", 0);
            MinusFuel += PlayerPrefs.GetFloat("TurbinsFuel", 0);
            fuelminusT.text = MinusFuel.ToString() + "к";

            float MinusEnergy = PlayerPrefs.GetFloat("Generators1Energy", 0);
            MinusEnergy += PlayerPrefs.GetFloat("Generators2Energy", 0);
            MinusEnergy += PlayerPrefs.GetFloat("Generators3Energy", 0);
            MinusEnergy += PlayerPrefs.GetFloat("Generators4Energy", 0);
            MinusEnergy -= PlayerPrefs.GetFloat("TurbinsEnergy", 0);
            energyminusT.text = MinusEnergy.ToString() + "ед";


            Delay = 1f;
        }
    }
}
