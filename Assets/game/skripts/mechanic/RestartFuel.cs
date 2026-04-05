using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartFuel : MonoBehaviour
{
    private int coins;
    private int allfuel;
    private int allcoins;
    private int fuelused;
    private int thispricefuel;
    private bool is1;
    public death d1;
    public death d2;
    public death d3;
    public death d4;
    public death d5;

    void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);
        allfuel = PlayerPrefs.GetInt("fuel", 0);
        fuelused = PlayerPrefs.GetInt("fueltostart", 0);
        thispricefuel = PlayerPrefs.GetInt("fuelPrice", 10);
    }

    public void restart()
    {
        int Price;

        if(PlayerPrefs.GetInt("g2passed", 0) == 1)
            Price = 15 + PlayerPrefs.GetInt("PriceToPlayProjectile", 0) + PlayerPrefs.GetInt("PriceToPlayShield", 0) + PlayerPrefs.GetInt("PriceToPlayScanner", 0) + PlayerPrefs.GetInt("PriceToPlayGyperJump", 0);
        else if(PlayerPrefs.GetInt("g1passed", 0) == 1 && PlayerPrefs.GetInt("Rest", 25000) <= 0)
            Price = 11 + PlayerPrefs.GetInt("PriceToPlayProjectile", 0) + PlayerPrefs.GetInt("PriceToPlayShield", 0) + PlayerPrefs.GetInt("PriceToPlayScanner", 0) + PlayerPrefs.GetInt("PriceToPlayGyperJump", 0);
        else
            Price = 7 + PlayerPrefs.GetInt("PriceToPlayProjectile", 0) + PlayerPrefs.GetInt("PriceToPlayShield", 0) + PlayerPrefs.GetInt("PriceToPlayScanner", 0) + PlayerPrefs.GetInt("PriceToPlayGyperJump", 0);


        if(allfuel >= fuelused && coins >= Price && !is1)
        {
            is1 = true;
            allfuel -= fuelused;
            coins -= Price;
            d1.restart3();
            d2.restart3();
            d3.restart3();
            d4.restart3();
            d5.restart3();
            PlayerPrefs.SetInt("fuel", allfuel);
            PlayerPrefs.SetInt("coins", coins);
        }
        else if(allfuel <= fuelused && coins >= Price && !is1)
        {
            fuelused = fuelused - allfuel;
            fuelused = fuelused * thispricefuel + Price;

            if(coins >= fuelused)
            {
                coins -= fuelused;
                PlayerPrefs.SetInt("coins", coins);
                PlayerPrefs.SetInt("fuel", 0);
                d1.restart3();
                d2.restart3();
                d3.restart3();
                d4.restart3();
                d5.restart3();
                is1 = true;
            }
        }
    }
}
