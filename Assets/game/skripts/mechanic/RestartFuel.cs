using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartFuel : MonoBehaviour
{
    public int coins;
    public int allfuel;
    public int allcoins;
    public int fuelused;
    public int thispricefuel;
    public bool is1;
    public death d1;
    public death d2;
    public death d3;
    public death d4;

    void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        allfuel = PlayerPrefs.GetInt("fuel", 0);
        fuelused = PlayerPrefs.GetInt("fueltostart", 0);
        thispricefuel = PlayerPrefs.GetInt("fuelPrice", 10);
    }

    public void restart()
    {
        if(allfuel >= fuelused && coins >= 3 && !is1)
        {
            is1 = true;
            allfuel -= fuelused;
            coins -= 3;
            d1.restart3();
            d2.restart3();
            d3.restart3();
            d4.restart3();
        }
        else if(allfuel <= fuelused && coins >= 3 && !is1)
        {
            fuelused = fuelused - allfuel;
            fuelused = fuelused * thispricefuel + 3;

            if(coins >= fuelused)
            {
                coins -= fuelused;
                PlayerPrefs.SetInt("coins", coins);
                PlayerPrefs.SetInt("fuel", 0);
                d1.restart3();
                d2.restart3();
                d3.restart3();
                d4.restart3();
            }
        }
    }
}
