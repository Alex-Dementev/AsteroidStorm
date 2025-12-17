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

    public void UpdateSlots()
    {
        Slot = PlayerPrefs.GetInt("PetsSlot", 0);

        if(PlayerPrefs.GetInt("PetsIndex" + Slot) != Index && PlayerPrefs.GetInt("PetsIndex" + Slot) >= 2 && PlayerPrefs.GetInt(IndexPets) >= 1 || PlayerPrefs.GetInt("PetsIndex" + Slot) == 1)
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

        NameText.text = "" + Name;
    }

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
            Slot = PlayerPrefs.GetInt("PetsSlot", 0);

            if(PlayerPrefs.GetInt("PetsIndex" + Slot) == Index)
                DetectedSlot.color = new Color(0, 220/255f, 0);
            else
                DetectedSlot.color = new Color(92/255f, 0, 78/255f);

            Quantity.text = "" + PlayerPrefs.GetInt(IndexPets, 0);

            yield return new WaitForSeconds(0.1f);
        }
    }
}