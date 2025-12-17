using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ApproveModuls : MonoBehaviour
{
    public Text Description;
    public Text DescPositive;
    public Text DescNegative;
    private string DescriptionS;
    private string DescPositiveS;
    private string DescNegativeS;
    public Text Name;
    public Image rareBox;
    public Image rareDesc;
    private int Index;
    public int IndexSlot;
    private int Rare;
    public int TypeIndex;
    public int Position;
    public Image Detection;
    private Coroutine loop;


    void OnEnable()
    {
        loop = StartCoroutine(TimerLoop());
    }

    void Start()
    {
        PlayerPrefs.SetInt("IndexSlot", 0);
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
            if(PlayerPrefs.GetInt("IndexSlot", 0) == IndexSlot)
                Detection.color = new Color(35/255f, 154/255f, 28/255f);
            else
                Detection.color = new Color(147/255f, 15/255f, 128/255f);


            if(TypeIndex == 1)
                Index = PlayerPrefs.GetInt("EngineIndex", 0);
            if(TypeIndex == 2)
            {
                if(Position == 1)
                    Index = PlayerPrefs.GetInt("GeneratorIndex1", 0);
                if(Position == 2)
                    Index = PlayerPrefs.GetInt("GeneratorIndex2", 0);
                if(Position == 3)
                    Index = PlayerPrefs.GetInt("GeneratorIndex3", 0);
                if(Position == 4)
                    Index = PlayerPrefs.GetInt("GeneratorIndex4", 0);
            }
            if(TypeIndex == 3)
            {
                if(Position == 1)
                    Index = PlayerPrefs.GetInt("FuelIndex1", 0);
                if(Position == 2)
                    Index = PlayerPrefs.GetInt("FuelIndex2", 0);
            }
            if(TypeIndex == 4)
                Index = PlayerPrefs.GetInt("GyperJumpIndex", 0);
            if(TypeIndex == 5)
                Index = PlayerPrefs.GetInt("ScannerIndex", 0);
            if(TypeIndex == 6)
                Index = PlayerPrefs.GetInt("ShieldIndex", 0);
            if(TypeIndex == 7)
                Index = PlayerPrefs.GetInt("ProjectileIndex", 0);


            if(Index >= 1)
            {
                DescriptionS = PlayerPrefs.GetString("DescText" + Index);
                DescPositiveS = PlayerPrefs.GetString("DescPositiveText" + Index);
                DescNegativeS = PlayerPrefs.GetString("DescNegativeText" + Index);

                Name.text = "" + PlayerPrefs.GetString("NameModuls" + Index);
                Rare = PlayerPrefs.GetInt("Rare" + Index, 0);
            }
            else
            {
                Name.text = "Пусто";
                
                if(TypeIndex == 1)
                    DescriptionS = "Ячейка для турбины, пусто";
                if(TypeIndex == 2)
                {
                    if(Position == 1)
                        DescriptionS = "Первая ячейка для генератора, пусто";
                    if(Position == 2)
                        DescriptionS = "Вторая ячейка для генератора, пусто";
                    if(Position == 3)
                        DescriptionS = "Третья ячейка для генератора, пусто";
                    if(Position == 4)
                        DescriptionS = "Четвертая ячейка для генератора, пусто";
                }
                if(TypeIndex == 3)
                {
                    if(Position == 1)
                        DescriptionS = "Первая ячейка для бака, пусто";
                    if(Position == 2)
                        DescriptionS = "Вторая ячейка для бака, пусто";
                }
                if(TypeIndex == 4)
                    DescriptionS = "Ячейка для способности \"Гипер пробитие\", пусто";
                if(TypeIndex == 5)
                    DescriptionS = "Ячейка для способности \"Сканнер\", пусто";
                if(TypeIndex == 6)
                    DescriptionS = "Ячейка для способности \"Щит\", пусто";
                if(TypeIndex == 7)
                    DescriptionS = "Ячейка для способности \"Снаряд\", пусто";

                DescPositiveS = "-";
                DescNegativeS = "-";

                Rare = 0;
            }

            if(Rare == 0)
                rareBox.color = new Color(66/255f, 50/255f, 75/255f);
            if(Rare == 1)
                rareBox.color = new Color(60/255f, 57/255f, 109/255f); 
            if(Rare == 2)
                rareBox.color = new Color(22/255f, 90/255f, 0/255f);
            if(Rare == 3)
                rareBox.color = new Color(88/255f, 16/255f, 82/255f);
            if(Rare == 4)
                rareBox.color = new Color(125/255f, 132/255f, 0/255f);
            if(Rare == 5)
                rareBox.color = new Color(114/255f, 15/255f, 61/255f);

            yield return new WaitForSeconds(0.05f);
        }
    }

    public void Click()
    {
        Description.text = "" + DescriptionS;
        DescPositive.text = "" + DescPositiveS;
        DescNegative.text = "" + DescNegativeS;

        PlayerPrefs.SetInt("IndexSlot", IndexSlot);
        Debug.Log(PlayerPrefs.GetInt("IndexSlot"));

        if(Rare == 0)
            rareDesc.color = new Color(66/255f, 50/255f, 75/255f);
        if(Rare == 1)
            rareDesc.color = new Color(60/255f, 57/255f, 109/255f); 
        if(Rare == 2)
            rareDesc.color = new Color(22/255f, 90/255f, 0/255f);
        if(Rare == 3)
            rareDesc.color = new Color(88/255f, 16/255f, 82/255f);
        if(Rare == 4)
            rareDesc.color = new Color(125/255f, 132/255f, 0/255f);
        if(Rare == 5)
            rareDesc.color = new Color(114/255f, 15/255f, 61/255f);

        PlayerPrefs.SetInt("Position", Position);
    }
}
