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


    void OnEnable() 
    {
        StartCoroutine(TimerLoop());
    }

    private IEnumerator TimerLoop()
    {
        while (true)
        {
            QuantityText.text = "" + PlayerPrefs.GetInt(IndexModul);

            yield return new WaitForSeconds(0.05f);
        }
    }


    public void ApplyDesc()
    {
        DescText.text = "" + Desc;
        DescPositive.text = "" + DescPos;
        DescNegative.text = "" + DescNegat;


        if(PlayerPrefs.GetInt(IndexModul, 0) >= 1)
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
                }
            }
        }
        if(IndexModul == "")
        {
            if(TypeIndex == 1)
            {
                PlayerPrefs.SetInt("EngineIndex", 0);
                LoadIndexModul = PlayerPrefs.GetString("TurbinIndexModule", "");
                Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                Quantity++;
                PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                PlayerPrefs.SetString("TurbinIndexModule", "0");
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
                    PlayerPrefs.SetString("Generator1IndexModule", "0");
                }
                if(IndexSlot == 2)
                {
                    PlayerPrefs.SetInt("GeneratorIndex2", 0);
                    LoadIndexModul = PlayerPrefs.GetString("Generator2IndexModule", "0");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("Generator2IndexModule", "");
                }
                if(IndexSlot == 3)
                {
                    PlayerPrefs.SetInt("GeneratorIndex3", 0);
                    LoadIndexModul = PlayerPrefs.GetString("Generator3IndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("Generator3IndexModule", "0");
                }
                if(IndexSlot == 4)
                {
                    PlayerPrefs.SetInt("GeneratorIndex4", 0);
                    LoadIndexModul = PlayerPrefs.GetString("Generator4IndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("Generator4IndexModule", "0");
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
                    PlayerPrefs.SetString("Fuel1IndexModule", "0");
                }
                if(IndexSlot == 2)
                {
                    PlayerPrefs.SetInt("FuelIndex2", 0);
                    LoadIndexModul = PlayerPrefs.GetString("Fuel2IndexModule", "");
                    Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                    Quantity++;
                    PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                    PlayerPrefs.SetString("Fuel2IndexModule", "0");
                }
            }
            if (TypeIndex == 4)
            {
                PlayerPrefs.SetInt("GyperJumpIndex", 0);
                LoadIndexModul = PlayerPrefs.GetString("GyperJumpIndexModule", "");
                Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                Quantity++;
                PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                PlayerPrefs.SetString("GyperJumpIndexModule", "0");
            }

            if (TypeIndex == 5)
            {
                PlayerPrefs.SetInt("ScannerIndex", 0);
                LoadIndexModul = PlayerPrefs.GetString("ScannerIndexModule", "");
                Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                Quantity++;
                PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                PlayerPrefs.SetString("ScannerIndexModule", "0");
            }

            if (TypeIndex == 6)
            {
                PlayerPrefs.SetInt("ShieldIndex", 0);
                LoadIndexModul = PlayerPrefs.GetString("ShieldIndexModule", "");
                Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                Quantity++;
                PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                PlayerPrefs.SetString("ShieldIndexModule", "0");
            }

            if (TypeIndex == 7)
            {
                PlayerPrefs.SetInt("ProjectileIndex", 0);
                LoadIndexModul = PlayerPrefs.GetString("ProjectileIndexModule", "");
                Quantity = PlayerPrefs.GetInt(LoadIndexModul, 0);
                Quantity++;
                PlayerPrefs.SetInt(LoadIndexModul, Quantity);
                PlayerPrefs.SetString("ProjectileIndexModule", "0");
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
    }
}
