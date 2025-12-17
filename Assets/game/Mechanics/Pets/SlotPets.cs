using UnityEngine;

public class SlotPets : MonoBehaviour
{
    private int Index;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    public int Slot;
    public Image DetectedSlot;

    void Update()
    {
        if(PlayerPrefs.GetInt("PetsIndex" + Slot) == 1)
        {
            DeActive();
        }
        else if(PlayerPrefs.GetInt("PetsIndex" + Slot) == 2)
        {
            DeActive();
            image1.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("PetsIndex" + Slot) == 3)
        {
            DeActive();
            image2.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("PetsIndex" + Slot) == 4)
        {
            DeActive();
            image3.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("PetsIndex" + Slot) == 5)
        {
            DeActive();
            image4.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("PetsIndex" + Slot) == 6)
        {
            DeActive();
            image5.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("PetsIndex" + Slot) == 7)
        {
            DeActive();
            image6.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("PetsIndex" + Slot) == 8)
        {
            DeActive();
            image7.SetActive(true);
        }
    }
    private void DeActive()
    {
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
        image5.SetActive(false);
        image6.SetActive(false);
        image7.SetActive(false);
    }

    public void Click()
    {
        if(PlayerPrefs.GetInt("PetsSlot", 0) == Slot)
            DetectedSlot.color = new Color(0, 220/255f, 0);
        else
            DetectedSlot.color = new Color(92/255f, 0, 78/255f);
    }
}
