using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrefPets : MonoBehaviour
{
    public int Index;
    public Image DetectedSlot;
    private int Coll;
    private int Slot;
    public string IndexPets;
    public Text Quantity;
    private Coroutine loop;
    public Text NameText;
    public string Name;
    private int Clicks;
    private float TimerClicks;
    public PanelsBuySell BuySell;
    public GameObject Secret;

    public void UpdateSlots()
    {
        Slot = PlayerPrefs.GetInt("PetsSlot", 0);

        if(Slot != 0)
        {
            if(PlayerPrefs.GetInt("PetsIndex" + Slot) != Index && PlayerPrefs.GetInt(IndexPets) >= 1 || Index == 1)
            {
                Coll = PlayerPrefs.GetInt(PlayerPrefs.GetString("BackPet" + Slot, ""), 0);
                Coll += 1;
                PlayerPrefs.SetInt(PlayerPrefs.GetString("BackPet" + Slot, ""), Coll);

                Coll = PlayerPrefs.GetInt(IndexPets);
                Coll -= 1;
                PlayerPrefs.SetInt(IndexPets, Coll);
                PlayerPrefs.SetString("BackPet" + Slot, IndexPets);

                PlayerPrefs.SetInt("PetsIndex" + Slot, Index);
            }

            if(PlayerPrefs.GetInt(IndexPets) >= 0 && Index != 1 && PlayerPrefs.GetString("BackPet" + Slot, "") == IndexPets)
            {
                if(Clicks <= 1)
                {
                    Clicks++;
                    TimerClicks = 0.5f;
                }

                if(Clicks >= 2)
                {
                    BuySell.VSellPanel();
                }
            }
            
            NameText.text = "" + Name;
        }
        else
            NameText.text = "Не выбран слот";
    }

    void OnEnable()
    {
        loop = StartCoroutine(TimerLoop());

        if(Secret == null) return;
         
        if(PlayerPrefs.GetInt(IndexPets + "Buy", 0) == 1)
            Secret.SetActive(true);
        else
            Secret.SetActive(false);
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
            Slot = PlayerPrefs.GetInt("PetsSlot", 0);

            if(PlayerPrefs.GetInt("PetsIndex" + Slot) == Index)
                DetectedSlot.color = new Color(0, 220/255f, 0);
            else
                DetectedSlot.color = new Color(92/255f, 0, 78/255f);

            if(Quantity != null)
                Quantity.text = "" + PlayerPrefs.GetInt(IndexPets, 0);

            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        TimerClicks -= Time.deltaTime;

        if(TimerClicks <= 0)
            Clicks = 0;
    }
}