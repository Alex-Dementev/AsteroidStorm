using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyBoxes : MonoBehaviour
{
    public int Price;
    public Animator BuyPanel;
    public int Index;
    public GameObject IsBuy;
    public int IndexEnd;
    public string Name;
    private Coroutine loop;
    public bool IsNotBuyBox;
    public bool fuelBoxes;


    private void OnEnable()
    {
        if(IsNotBuyBox && PlayerPrefs.GetInt("g2passed", 0) == 0)
            gameObject.SetActive(false);
        else if(IsNotBuyBox && PlayerPrefs.GetInt("g2passed", 0) == 1 && fuelBoxes)
        {
            if(PlayerPrefs.GetInt("CurrentTanksToRust", 0) == 0)
            {
                if(PlayerPrefs.GetInt("MaxFuel1", 0) == 0)
                {
                    if(PlayerPrefs.GetInt("MaxFuel2", 0) != 0)
                    {
                        PlayerPrefs.SetInt("CurrentTanksToRust", 507);
                        PlayerPrefs.SetInt("MaxFuel1Rust", PlayerPrefs.GetInt("MaxFuel1", 0));
                        PlayerPrefs.SetInt("MaxFuel1", 0);
                        PlayerPrefs.SetInt("Rust507", 1);
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("CurrentTanksToRust", 508);
                    PlayerPrefs.SetInt("MaxFuel2Rust", PlayerPrefs.GetInt("MaxFuel2", 0));
                    PlayerPrefs.SetInt("MaxFuel2", 0);
                    PlayerPrefs.SetInt("Rust508", 1);
                }
            }

            if(PlayerPrefs.GetInt("CurrentTanksToRust", 0) != Index)
                gameObject.SetActive(false);
        }
        else if(IsNotBuyBox && PlayerPrefs.GetInt("g2passed", 0) == 1 && !fuelBoxes && PlayerPrefs.GetInt("Rust", 0) != 1)
        {
            PlayerPrefs.SetInt("Rust", 1);

            
            PlayerPrefs.SetFloat("Generators1EnergyRust", PlayerPrefs.GetFloat("Generators1Energy", 0));
            PlayerPrefs.SetFloat("Generators1FuelRust", PlayerPrefs.GetFloat("Generators1Fuel", 0));
            PlayerPrefs.SetFloat("Generators1Energy", 0);
            PlayerPrefs.SetFloat("Generators1Fuel", 0);
            PlayerPrefs.SetInt("Rust500", 1);
            Debug.Log("Generators1EnergyRust: " + PlayerPrefs.GetFloat("Generators1EnergyRust", 0) + ", Generators1Energy: " + PlayerPrefs.GetFloat("Generators1Energy", 0));

            PlayerPrefs.SetFloat("Generators3EnergyRust", PlayerPrefs.GetFloat("Generators3Energy", 0));
            PlayerPrefs.SetFloat("Generators3FuelRust", PlayerPrefs.GetFloat("Generators3Fuel", 0));
            PlayerPrefs.SetFloat("Generators3Energy", 0);
            PlayerPrefs.SetFloat("Generators3Fuel", 0);
            PlayerPrefs.SetInt("Rust501", 1);

            PlayerPrefs.SetFloat("Generators4EnergyRust", PlayerPrefs.GetFloat("Generators4Energy", 0));
            PlayerPrefs.SetFloat("Generators4FuelRust", PlayerPrefs.GetFloat("Generators4Fuel", 0));
            PlayerPrefs.SetFloat("Generators4Energy", 0);
            PlayerPrefs.SetFloat("Generators4Fuel", 0);
            PlayerPrefs.SetInt("Rust502", 1);


            PlayerPrefs.SetInt("GyperJumpRust", PlayerPrefs.GetInt("GyperJump", 0));
            PlayerPrefs.SetInt("GyperJump", 0);
            PlayerPrefs.SetInt("Rust503", 1);

            PlayerPrefs.SetInt("ScannerRust", PlayerPrefs.GetInt("Scanner", 0));
            PlayerPrefs.SetInt("Scanner", 0);
            PlayerPrefs.SetInt("Rust504", 1);

            PlayerPrefs.SetInt("ShieldRust", PlayerPrefs.GetInt("Shield", 0));
            PlayerPrefs.SetInt("Shield", 0);
            PlayerPrefs.SetInt("Rust505", 1);

            PlayerPrefs.SetInt("ProjectileRust", PlayerPrefs.GetInt("Projectile", 0));
            PlayerPrefs.SetInt("Projectile", 0);
            PlayerPrefs.SetInt("Rust506", 1);
        }


        BoxEvents.OnBoxesUpdated += RefreshState;
        
        RefreshState();
    }

    private void OnDisable()
    {
        BoxEvents.OnBoxesUpdated -= RefreshState;
    }

    public void RefreshState()
    {
        bool bought = PlayerPrefs.GetInt(Index + "BuyBoxes", 0) == Index;

        if(bought)
        {
            if(Index == 500 && PlayerPrefs.GetInt("Rust500", 0) == 1)
            {
                Debug.Log("Generators1EnergyRust: " + PlayerPrefs.GetFloat("Generators1EnergyRust", 0) + ", Generators1Energy: " + PlayerPrefs.GetFloat("Generators1Energy", 0));
                PlayerPrefs.SetInt("Rust500", 0);
                PlayerPrefs.SetFloat("Generators1Energy", PlayerPrefs.GetFloat("Generators1EnergyRust", 0));
                PlayerPrefs.SetFloat("Generators1Fuel", PlayerPrefs.GetFloat("Generators1FuelRust", 0));
            }
            else if(Index == 501 && PlayerPrefs.GetInt("Rust501", 0) == 1)
            {
                PlayerPrefs.SetInt("Rust501", 0);
                PlayerPrefs.SetFloat("Generators3Energy", PlayerPrefs.GetFloat("Generators3EnergyRust", 0));
                PlayerPrefs.SetFloat("Generators3Fuel", PlayerPrefs.GetFloat("Generators3FuelRust", 0));
            }
            else if(Index == 502 && PlayerPrefs.GetInt("Rust502", 0) == 1)
            {
                PlayerPrefs.SetInt("Rust502", 0);
                PlayerPrefs.SetFloat("Generators4Energy", PlayerPrefs.GetFloat("Generators4EnergyRust", 0));
                PlayerPrefs.SetFloat("Generators4Fuel", PlayerPrefs.GetFloat("Generators4FuelRust", 0));
            }
            else if(Index == 503 && PlayerPrefs.GetInt("Rust503", 0) == 1)
            {
                PlayerPrefs.SetInt("Rust503", 0);
                PlayerPrefs.SetFloat("GyperJump", PlayerPrefs.GetInt("GyperJumpRust", 0));
            }
            else if(Index == 504 && PlayerPrefs.GetInt("Rust504", 0) == 1)
            {
                PlayerPrefs.SetInt("Rust504", 0);
                PlayerPrefs.SetFloat("Scanner", PlayerPrefs.GetInt("ScannerRust", 0));
            }
            else if(Index == 505 && PlayerPrefs.GetInt("Rust505", 0) == 1)
            {
                PlayerPrefs.SetInt("Rust505", 0);
                PlayerPrefs.SetFloat("Shield", PlayerPrefs.GetInt("ShieldRust", 0));
            }
            else if(Index == 506 && PlayerPrefs.GetInt("Rust506", 0) == 1)
            {
                PlayerPrefs.SetInt("Rust506", 0);
                PlayerPrefs.SetFloat("Projectile", PlayerPrefs.GetInt("ProjectileRust", 0));
            }
            else if(Index == 507 && PlayerPrefs.GetInt("Rust507", 0) == 1)
            {
                PlayerPrefs.SetInt("Rust507", 0);
                PlayerPrefs.SetFloat("MaxFuel1", PlayerPrefs.GetInt("MaxFuel1Rust", 0));
            }
            else if(Index == 508 && PlayerPrefs.GetInt("Rust508", 0) == 1)
            {
                PlayerPrefs.SetInt("Rust508", 0);
                PlayerPrefs.SetFloat("MaxFuel1", PlayerPrefs.GetInt("MaxFuel1Rust", 0));
            }

            IsBuy.SetActive(false);
        }
    }

    public void Buy()
    {
            PlayerPrefs.SetInt("IndexToBuyBox", Index);

            if(Index == 8 || Index == 6 || Index == 4 || Index == 2)
            {
                if(PlayerPrefs.GetInt("2BuyBoxes", 0) == 2 && PlayerPrefs.GetInt("4BuyBoxes", 0) == 4 && PlayerPrefs.GetInt("6BuyBoxes", 0) == 6)
                    PlayerPrefs.SetInt("PriceToBuyBox", 3085);
                else if(PlayerPrefs.GetInt("2BuyBoxes", 0) == 2 && PlayerPrefs.GetInt("4BuyBoxes", 0) == 4)
                    PlayerPrefs.SetInt("PriceToBuyBox", 1635);
                else if(PlayerPrefs.GetInt("2BuyBoxes", 0) == 2)
                    PlayerPrefs.SetInt("PriceToBuyBox", 620);
                else
                    PlayerPrefs.SetInt("PriceToBuyBox", 155);
            }
            else
                PlayerPrefs.SetInt("PriceToBuyBox", Price);

            PlayerPrefs.SetString("NameBuyBox", Name);
            BuyPanel.CrossFade("Start", 0.1f);
    }
}
