using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrefBoxPaste : MonoBehaviour
{
    public Text DescText;
    public Image Rare;
    public string Desc;
    public Text DescPositive;
    public Text DescNegative;
    public string DescPos;
    public string DescNegat;
    public int RareLevel;
    public int Index;
    public int TypeIndex;
    private int IndexSlot;
    public Text NameT;
    private string NameS;
    public string IndexModul;
    private string LoadIndexModul;
    private int Quantity;
    public Text QuantityText;
    public Image Detected;
    private Coroutine loop;

    public float minusfuel;
    public float minusenergy;
    public int energyAbility;
    public int maxFuel;
    public float plusenergy;
    public int ScannerLenght;
    public int otkat;
    public Animator approve;
    public int coins;
    public int allcoins;
    public Text Sellcoins;
    public int twoclicks;
    public int twoclicks2;
    public int twoclicks3;
    public int twoclicks4;
    public float ResetClicksFloat;
    public AudioSource ApproveAD;

    

    void OnEnable()
    {
        loop = StartCoroutine(TimerLoop());
    }

    void OnDisable()
    {
        if (loop != null)
            StopCoroutine(loop);
    }

    private IEnumerator TimerLoop()
    {
        while (true)
        {
            if(TypeIndex == 1)
            {
                if(PlayerPrefs.GetString("TurbinIndexModule", "") == IndexModul)
                    Detected.color = new Color(35/255f, 154/255f, 28/255f);
                else
                    Detected.color = new Color(147/255f, 15/255f, 128/255f);
            }
            if(TypeIndex == 2)
            {
                IndexSlot = PlayerPrefs.GetInt("Position");
                
                if(IndexSlot == 1)
                {
                    if(PlayerPrefs.GetString("Generator1IndexModule", "") == IndexModul)
                        Detected.color = new Color(35/255f, 154/255f, 28/255f);
                    else
                        Detected.color = new Color(147/255f, 15/255f, 128/255f);
                }
                if(IndexSlot == 2)
                {
                    if(PlayerPrefs.GetString("Generator2IndexModule") == IndexModul)
                        Detected.color = new Color(35/255f, 154/255f, 28/255f);
                    else
                        Detected.color = new Color(147/255f, 15/255f, 128/255f);
                }
                if(IndexSlot == 3)
                {
                    if(PlayerPrefs.GetString("Generator3IndexModule", "") == IndexModul)
                    Detected.color = new Color(35/255f, 154/255f, 28/255f);
                else
                    Detected.color = new Color(147/255f, 15/255f, 128/255f);
                }
                if(IndexSlot == 4)
                {
                    if(PlayerPrefs.GetString("Generator4IndexModule", "") == IndexModul)
                        Detected.color = new Color(35/255f, 154/255f, 28/255f);
                    else
                        Detected.color = new Color(147/255f, 15/255f, 128/255f);
                }
            }
            if(TypeIndex == 3)
            {
                IndexSlot = PlayerPrefs.GetInt("Position");
                
                if(IndexSlot == 1)
                {
                    if(PlayerPrefs.GetString("Fuel1IndexModule") == IndexModul)
                        Detected.color = new Color(35/255f, 154/255f, 28/255f);
                    else
                        Detected.color = new Color(147/255f, 15/255f, 128/255f);
                }
                if(IndexSlot == 2)
                {
                    if(PlayerPrefs.GetString("Fuel2IndexModule") == IndexModul)
                        Detected.color = new Color(35/255f, 154/255f, 28/255f);
                    else
                        Detected.color = new Color(147/255f, 15/255f, 128/255f);
                }
            }
            if (TypeIndex == 4)
            {
                if(PlayerPrefs.GetString("GyperJumpIndexModule", "") == IndexModul)
                    Detected.color = new Color(35/255f, 154/255f, 28/255f);
                else
                    Detected.color = new Color(147/255f, 15/255f, 128/255f);
            }

            if (TypeIndex == 5)
            {
                if(PlayerPrefs.GetString("ScannerIndexModule", "") == IndexModul)
                    Detected.color = new Color(35/255f, 154/255f, 28/255f);
                else
                    Detected.color = new Color(147/255f, 15/255f, 128/255f);
            }

            if (TypeIndex == 6)
            {
                if(PlayerPrefs.GetString("ShieldIndexModule", "") == IndexModul)
                    Detected.color = new Color(35/255f, 154/255f, 28/255f);
                else
                    Detected.color = new Color(147/255f, 15/255f, 128/255f);
            }

            if (TypeIndex == 7)
            {
                if(PlayerPrefs.GetString("ProjectileIndexModule", "") == IndexModul)
                    Detected.color = new Color(35/255f, 154/255f, 28/255f);
                else
                    Detected.color = new Color(147/255f, 15/255f, 128/255f);
            }

            QuantityText.text = "" + PlayerPrefs.GetInt(IndexModul);

            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        ResetClicksFloat -= Time.deltaTime;

        if(twoclicks >= 1 && ResetClicksFloat <= 0)
            twoclicks = 0;
        if(twoclicks2 >= 1 && ResetClicksFloat <= 0)
            twoclicks2 = 0;
        if(twoclicks3 >= 1 && ResetClicksFloat <= 0)
            twoclicks3 = 0;
        if(twoclicks4 >= 1 && ResetClicksFloat <= 0)
            twoclicks4 = 0;
    }

    public void ApplyDesc()
    {
        DescText.text = "" + Desc;
        DescPositive.text = "" + DescPos;
        DescNegative.text = "" + DescNegat;

        if(PlayerPrefs.GetInt(IndexModul, 0) == 1)
        {
            PlayerPrefs.SetString("DescText" + Index, Desc);
            PlayerPrefs.SetString("DescPositiveText" + Index, DescPos);
            PlayerPrefs.SetString("DescNegativeText" + Index, DescNegat);
            PlayerPrefs.SetInt("Rare" + Index, RareLevel);

            NameS = NameT.text;
            PlayerPrefs.SetString("NameModuls" + Index, NameS);

            if(TypeIndex == 1)
            {
                PlayerPrefs.SetInt("EngineIndex", Index);

                if(PlayerPrefs.GetString("TurbinIndexModule", "") != IndexModul)
                {
                    LoadIndexModul = PlayerPrefs.GetString("TurbinIndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("TurbinIndexModule", IndexModul);
                    Quantity = PlayerPrefs.GetInt(IndexModul, 0);
                    Quantity -= 1;
                    PlayerPrefs.SetInt(IndexModul, Quantity);
                    PlayerPrefs.SetFloat("TurbinsEnergy", minusenergy);
                    PlayerPrefs.SetFloat("TurbinsFuel", minusfuel);
                }
            }
            if(TypeIndex == 2)
            {
                IndexSlot = PlayerPrefs.GetInt("Position");
                
                if(IndexSlot == 1)
                {
                    PlayerPrefs.SetInt("GeneratorIndex1", Index);

                    if(PlayerPrefs.GetString("Generator1IndexModule", "") != IndexModul)
                    {
                        LoadIndexModul = PlayerPrefs.GetString("Generator1IndexModule", "");
                        Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                        Quantity++;
                        PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                        PlayerPrefs.SetString("Generator1IndexModule", IndexModul);
                        Quantity = PlayerPrefs.GetInt(IndexModul, 0);
                        Quantity -= 1;
                        PlayerPrefs.SetInt(IndexModul, Quantity);
                        PlayerPrefs.SetFloat("Generators1Energy", plusenergy);
                        PlayerPrefs.SetFloat("Genertors1Fuel", minusfuel);
                    }
                }
                if(IndexSlot == 2)
                {
                    PlayerPrefs.SetInt("GeneratorIndex2", Index);

                    if(PlayerPrefs.GetString("Generator2IndexModule", "") != IndexModul)
                    {
                        LoadIndexModul = PlayerPrefs.GetString("Generator2IndexModule", "");
                        Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                        Quantity++;
                        PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                        PlayerPrefs.SetString("Generator2IndexModule", IndexModul);
                        Quantity = PlayerPrefs.GetInt(IndexModul, 0);
                        Quantity -= 1;
                        PlayerPrefs.SetInt(IndexModul, Quantity);
                        PlayerPrefs.SetFloat("Generators2Energy", plusenergy);
                        PlayerPrefs.SetFloat("Genertors2Fuel", minusfuel);
                    }
                }
                if(IndexSlot == 3)
                {
                    PlayerPrefs.SetInt("GeneratorIndex3", Index);

                    if(PlayerPrefs.GetString("Generator3IndexModule", "") != IndexModul)
                    {
                        LoadIndexModul = PlayerPrefs.GetString("Generator3IndexModule", "");
                        Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                        Quantity ++;
                        PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                        PlayerPrefs.SetString("Generator3IndexModule", IndexModul);
                        Quantity = PlayerPrefs.GetInt(IndexModul, 0);
                        Quantity -= 1;
                        PlayerPrefs.SetInt(IndexModul, Quantity);
                        PlayerPrefs.SetFloat("Generators3Energy", plusenergy);
                        PlayerPrefs.SetFloat("Genertors3Fuel", minusfuel);
                    }
                }
                if(IndexSlot == 4)
                {
                    PlayerPrefs.SetInt("GeneratorIndex4", Index);

                    if(PlayerPrefs.GetString("Generator4IndexModule", "") != IndexModul)
                    {
                        LoadIndexModul = PlayerPrefs.GetString("Generator4IndexModule", "");
                        Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                        Quantity++;
                        PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                        PlayerPrefs.SetString("Generator4IndexModule", IndexModul);
                        Quantity = PlayerPrefs.GetInt(IndexModul, 0);
                        Quantity -= 1;
                        PlayerPrefs.SetInt(IndexModul, Quantity);
                        PlayerPrefs.SetFloat("Generators4Energy", plusenergy);
                        PlayerPrefs.SetFloat("Genertors4Fuel", minusfuel);
                    }
                }
            }
            if(TypeIndex == 3)
            {
                IndexSlot = PlayerPrefs.GetInt("Position");
                
                if(IndexSlot == 1)
                {
                    PlayerPrefs.SetInt("FuelIndex1", Index);

                    if(PlayerPrefs.GetString("Fuel1IndexModule", "") != IndexModul)
                    {
                        LoadIndexModul = PlayerPrefs.GetString("Fuel1IndexModule");
                        Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                        Quantity++;
                        PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                        PlayerPrefs.SetString("Fuel1IndexModule", IndexModul);
                        Quantity = PlayerPrefs.GetInt(IndexModul, 0);
                        Quantity -= 1;
                        PlayerPrefs.SetInt(IndexModul, Quantity);
                        PlayerPrefs.SetInt("MaxFuel1", maxFuel);
                    }
                }
                if(IndexSlot == 2)
                {
                    PlayerPrefs.SetInt("FuelIndex2", Index);

                    if(PlayerPrefs.GetString("Fuel2IndexModule", "") != IndexModul)
                    {
                        LoadIndexModul = PlayerPrefs.GetString("Fuel2IndexModule", "");
                        Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                        Quantity++;
                        PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                        PlayerPrefs.SetString("Fuel2IndexModule", IndexModul);
                        Quantity = PlayerPrefs.GetInt(IndexModul, 0);
                        Quantity -= 1;
                        PlayerPrefs.SetInt(IndexModul, Quantity);
                        PlayerPrefs.SetInt("MaxFuel2", maxFuel);
                    }
                }
            }
            if (TypeIndex == 4)
            {
                PlayerPrefs.SetInt("GyperJumpIndex", Index);

                if(PlayerPrefs.GetString("GyperJumpIndexModule", "") != IndexModul)
                {
                    LoadIndexModul = PlayerPrefs.GetString("GyperJumpIndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("GyperJumpIndexModule", IndexModul);
                    Quantity = PlayerPrefs.GetInt(IndexModul, 0);
                    Quantity -= 1;
                    PlayerPrefs.SetInt(IndexModul, Quantity);
                    PlayerPrefs.SetInt("GyperJump", 1);
                    PlayerPrefs.SetInt("GyperJumpEnergy", energyAbility);
                    PlayerPrefs.SetInt("GyperJumpOtkat", otkat);
                }
            }
            if (TypeIndex == 5)
            {
                PlayerPrefs.SetInt("ScannerIndex", Index);

                if(PlayerPrefs.GetString("ScannerIndexModule", "") != IndexModul)
                {
                    LoadIndexModul = PlayerPrefs.GetString("ScannerIndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("ScannerIndexModule", IndexModul);
                    Quantity = PlayerPrefs.GetInt(IndexModul, 0);
                    Quantity -= 1;
                    PlayerPrefs.SetInt(IndexModul, Quantity);
                    PlayerPrefs.SetInt("Scanner", 1);
                    PlayerPrefs.SetInt("ScannerEnergy", energyAbility);
                    PlayerPrefs.SetInt("ScannerOtkat", otkat);
                    PlayerPrefs.SetInt("ScannerLenght", ScannerLenght);
                    
                }
            }
            if (TypeIndex == 6)
            {
                PlayerPrefs.SetInt("ShieldIndex", Index);

                if(PlayerPrefs.GetString("ShieldIndexModule", "") != IndexModul)
                {
                    LoadIndexModul = PlayerPrefs.GetString("ShieldIndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("ShieldIndexModule", IndexModul);
                    Quantity = PlayerPrefs.GetInt(IndexModul, 0);
                    Quantity -= 1;
                    PlayerPrefs.SetInt(IndexModul, Quantity);
                    PlayerPrefs.SetInt("Shield", 1);
                    PlayerPrefs.SetInt("ShieldEnergy", energyAbility);
                    PlayerPrefs.SetInt("ShieldOtkat", otkat);
                }
            }
            if (TypeIndex == 7)
            {
                PlayerPrefs.SetInt("ProjectileIndex", Index);

                if(PlayerPrefs.GetString("ProjectileIndexModule", "") != IndexModul)
                {
                    LoadIndexModul = PlayerPrefs.GetString("ProjectileIndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("ProjectileIndexModule", IndexModul);
                    Quantity = PlayerPrefs.GetInt(IndexModul, 0);
                    Quantity -= 1;
                    PlayerPrefs.SetInt(IndexModul, Quantity);
                    PlayerPrefs.SetInt("Projectile", 1);
                    PlayerPrefs.SetInt("ProjectileEnergy", energyAbility);
                    PlayerPrefs.SetInt("ProjectileOtkat", otkat);
                }
            }
        }
        if(IndexModul == "0")
        {
            if (TypeIndex == 1)
            {
                PlayerPrefs.SetInt("EngineIndex", 0);
                LoadIndexModul = PlayerPrefs.GetString("TurbinIndexModule", "");
                Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                Quantity++;
                PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                PlayerPrefs.SetString("TurbinIndexModule", IndexModul);
                PlayerPrefs.SetFloat("TurbinsEnergy", minusenergy);
                PlayerPrefs.SetFloat("TurbinsFuel", minusfuel);
            }
            if(TypeIndex == 2)
            {
                IndexSlot = PlayerPrefs.GetInt("Position");
                
                if(IndexSlot == 1)
                {
                    PlayerPrefs.SetInt("GeneratorIndex1", 0);
                    LoadIndexModul = PlayerPrefs.GetString("Generator1IndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("Generator1IndexModule", IndexModul);
                    PlayerPrefs.SetFloat("Generators1Energy", 0);
                    PlayerPrefs.SetFloat("Genertors1Fuel", 0);
                }
                if(IndexSlot == 2)
                {
                    PlayerPrefs.SetInt("GeneratorIndex2", 0);
                    LoadIndexModul = PlayerPrefs.GetString("Generator2IndexModule", "0");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("Generator2IndexModule", IndexModul);
                    PlayerPrefs.SetFloat("Generators2Energy", 0);
                    PlayerPrefs.SetFloat("Genertors2Fuel", 0);
                }
                if(IndexSlot == 3)
                {
                    PlayerPrefs.SetInt("GeneratorIndex3", 0);
                    LoadIndexModul = PlayerPrefs.GetString("Generator3IndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("Generator3IndexModule", IndexModul);
                    PlayerPrefs.SetFloat("Generators3Energy", 0);
                    PlayerPrefs.SetFloat("Genertors3Fuel", 0);
                }
                if(IndexSlot == 4)
                {
                    PlayerPrefs.SetInt("GeneratorIndex4", 0);
                    LoadIndexModul = PlayerPrefs.GetString("Generator4IndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("Generator4IndexModule", IndexModul);
                    PlayerPrefs.SetFloat("Generators4Energy", 0);
                    PlayerPrefs.SetFloat("Genertors4Fuel", 0);
                }
            }
            if(TypeIndex == 3)
            {
                IndexSlot = PlayerPrefs.GetInt("Position");
                
                if(IndexSlot == 1)
                {
                    PlayerPrefs.SetInt("FuelIndex1", 0);
                    LoadIndexModul = PlayerPrefs.GetString("Fuel1IndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("Fuel1IndexModule", IndexModul);
                    PlayerPrefs.SetInt("MaxFuel1", 0);
                }
                if(IndexSlot == 2)
                {
                    PlayerPrefs.SetInt("FuelIndex2", 0);
                    LoadIndexModul = PlayerPrefs.GetString("Fuel2IndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("Fuel2IndexModule", IndexModul);
                    PlayerPrefs.SetInt("MaxFuel2", 0);
                }
            }
            if (TypeIndex == 4)
            {
                PlayerPrefs.SetInt("GyperJumpIndex", 0);
                LoadIndexModul = PlayerPrefs.GetString("GyperJumpIndexModule", "");
                Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                Quantity++;
                PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                PlayerPrefs.SetString("GyperJumpIndexModule", IndexModul);
                PlayerPrefs.SetInt("GyperJump", 0);
            }
            if (TypeIndex == 5)
            {
                PlayerPrefs.SetInt("ScannerIndex", 0);
                LoadIndexModul = PlayerPrefs.GetString("ScannerIndexModule", "");
                Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                Quantity++;
                PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                PlayerPrefs.SetString("ScannerIndexModule", IndexModul);
                PlayerPrefs.SetInt("Scanner", 0);
            }
            if (TypeIndex == 6)
            {
                PlayerPrefs.SetInt("ShieldIndex", 0);
                LoadIndexModul = PlayerPrefs.GetString("ShieldIndexModule", "");
                Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                Quantity++;
                PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                PlayerPrefs.SetString("ShieldIndexModule", IndexModul);
                PlayerPrefs.SetInt("Shield", 0);
            }
            if (TypeIndex == 7)
            {
                PlayerPrefs.SetInt("ProjectileIndex", 0);
                LoadIndexModul = PlayerPrefs.GetString("ProjectileIndexModule", "");
                Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                Quantity++;
                PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                PlayerPrefs.SetString("ProjectileIndexModule", IndexModul);
                PlayerPrefs.SetInt("Projectile", 0);
            }
        }

        if(RareLevel == 0)
            Rare.color = new Color(66/255f, 50/255f, 75/255f);
        if(RareLevel == 1)
            Rare.color = new Color(60/255f, 57/255f, 109/255f); 
        if(RareLevel == 2)
            Rare.color = new Color(22/255f, 90/255f, 0/255f);
        if(RareLevel == 3)
            Rare.color = new Color(88/255f, 16/255f, 82/255f);
        if(RareLevel == 4)
            Rare.color = new Color(125/255f, 132/255f, 0/255f);
        if(RareLevel == 5)
            Rare.color = new Color(114/255f, 15/255f, 61/255f);

        if(PlayerPrefs.GetString("TurbinIndexModule", "") == IndexModul)
        {
            twoclicks++;
            ResetClicksFloat = 0.75f;
            
            if(twoclicks >= 2)
            {
                twoclicks = 0;

                if(PlayerPrefs.GetInt("TurbinsCount", 0) >= 1)
                    approveSell();
            }
        }
        if(PlayerPrefs.GetString("Generator1IndexModule", "") == IndexModul)
        {
            twoclicks++;
            ResetClicksFloat = 0.75f;
            
            if(twoclicks >= 2)
            {
                twoclicks = 0;

                approveSell();
            }
        }
        if(PlayerPrefs.GetString("Generator2IndexModule", "") == IndexModul)
        {
            twoclicks2++;
            ResetClicksFloat = 0.75f;
            
            if(twoclicks2 >= 2)
            {
                twoclicks2 = 0;

                approveSell();
            }
        }
        if(PlayerPrefs.GetString("Generator3IndexModule", "") == IndexModul)
        {
            twoclicks3++;
            ResetClicksFloat = 0.75f;
            
            if(twoclicks3 >= 2)
            {
                twoclicks3 = 0;

                approveSell();
            }
        }
        if(PlayerPrefs.GetString("Generator4IndexModule", "") == IndexModul)
        {
            twoclicks4++;
            ResetClicksFloat = 0.75f;
            
            if(twoclicks4 >= 2)
            {
                twoclicks4 = 0;
                
                approveSell();
            }
        }
        IndexSlot = PlayerPrefs.GetInt("Position");
        if(PlayerPrefs.GetString("Fuel1IndexModule", "") == IndexModul && IndexSlot == 1)
        {
            twoclicks++;
            ResetClicksFloat = 0.75f;
            
            if(twoclicks >= 2)
            {
                twoclicks = 0;
                
                if(PlayerPrefs.GetInt("FuelTanksCount", 0) >= 1 || PlayerPrefs.GetString("Fuel2IndexModule", "") != "0")
                    approveSell();
            }
        }
        IndexSlot = PlayerPrefs.GetInt("Position");
        if(PlayerPrefs.GetString("Fuel2IndexModule", "") == IndexModul && IndexSlot == 2)
        {
            twoclicks2++;
            ResetClicksFloat = 0.75f;
            
            if(twoclicks2 >= 2)
            {
                twoclicks2 = 0;

                if(PlayerPrefs.GetInt("FuelTanksCount", 0) >= 1 || PlayerPrefs.GetString("Fuel1IndexModule", "") != "0")
                    approveSell();
            }
        }
        if(PlayerPrefs.GetString("GyperJumpIndexModule", "") == IndexModul)
        {
            twoclicks++;
            ResetClicksFloat = 0.75f;
            
            if(twoclicks >= 2)
            {
                twoclicks = 0;

                approveSell();
            }
        }
        if(PlayerPrefs.GetString("ScannerIndexModule", "") == IndexModul)
        {
            twoclicks++;
            ResetClicksFloat = 0.75f;
            
            if(twoclicks >= 2)
            {
                twoclicks = 0;
                
                approveSell();
            }
        }
        if(PlayerPrefs.GetString("ShieldIndexModule", "") == IndexModul)
        {
            twoclicks++;
            ResetClicksFloat = 0.75f;
            
            if(twoclicks >= 2)
            {
                twoclicks = 0;
                
                approveSell();
            }
        }
        if(PlayerPrefs.GetString("ProjectileIndexModule", "") == IndexModul)
        {
            twoclicks++;
            ResetClicksFloat = 0.75f;
            
            if(twoclicks >= 2)
            {
                twoclicks = 0;
                
                approveSell();
            }
        }
    }

    public void approveSell()
    {
        approve.Play("Start");
        PlayerPrefs.SetString("SellModul", IndexModul);
        PlayerPrefs.SetInt("SellModulRare", RareLevel);
        if(RareLevel == 1)
        {
            Sellcoins.text = "+200";
        }
        if(RareLevel == 2)
        {
            Sellcoins.text = "+370";
        }
        if(RareLevel == 3)
        {
            Sellcoins.text = "+680";
        }
        if(RareLevel == 4)
        {
            Sellcoins.text = "+1050";
        }
        if(RareLevel == 5)
        {
            Sellcoins.text = "+1500";
        }
    }
    public void NotApprove()
    {
        approve.Play("End");
    }
    public void sell()
    {
        LoadIndexModul = PlayerPrefs.GetString("SellModul", "");
        Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
        Quantity -= 1;
        PlayerPrefs.SetInt(LoadIndexModul, Quantity);

        int raresell = PlayerPrefs.GetInt("SellModulRare", 0);
        coins = PlayerPrefs.GetInt("coins", 0);
        allcoins = PlayerPrefs.GetInt("allcoins", 0);

        if(raresell == 1)
        {
            coins += 200;
            allcoins += 200;
        }
        if(raresell == 2)
        {
            coins += 370;
            allcoins += 370;
        }
        if(raresell == 3)
        {
            coins += 680;
            allcoins += 680;
        }
        if(raresell == 4)
        {
            coins += 1050;
            allcoins += 1050;
        }
        if(raresell == 5)
        {
            coins += 1500;
            allcoins += 1500;
        }

        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("allcoins", allcoins);

        ApproveAD.Play();

        approve.Play("End");
    }
}
