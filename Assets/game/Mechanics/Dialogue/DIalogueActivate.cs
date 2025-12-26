using UnityEngine;
using UnityEngine.UI;

public class DIalogueActivate : MonoBehaviour
{
    public GameObject Dialogue11;
    public GameObject Dialogue12;
    public GameObject Dialogue13;
    public GameObject Dialogue14;

    public GameObject Dialogue21;
    public GameObject Dialogue22;
    public GameObject Dialogue23;

    public GameObject Dialogue31;
    public GameObject Dialogue32;
    public GameObject Dialogue33;


    public GameObject[] UIPanels;
    public Text[] TutorialTexts;



    void Start()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) <= 15)
        {
            PlayerPrefs.DeleteAll();
        }

        foreach (GameObject msg in UIPanels)
        {
            msg.SetActive(false);
        }

        Invoke(nameof(UpdateDialogue), 7f);
    }

    public void DeActivate()
    {   
        if (Dialogue11.activeSelf)
            Dialogue11.GetComponent<DialogueManager>().Close();
        if (Dialogue12.activeSelf)
            Dialogue12.GetComponent<DialogueManager>().Close();
        if (Dialogue13.activeSelf)
            Dialogue13.GetComponent<DialogueManager>().Close();
        if (Dialogue14.activeSelf)
            Dialogue14.GetComponent<DialogueManager>().Close();

        if (Dialogue21.activeSelf)
            Dialogue21.GetComponent<DialogueManager>().Close();
        if (Dialogue22.activeSelf)
            Dialogue22.GetComponent<DialogueManager>().Close();
        if (Dialogue23.activeSelf)
            Dialogue23.GetComponent<DialogueManager>().Close();
    }

    public void UpdateDialogue()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 0)
            Dialogue11.SetActive(true);

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 2)
        {
            Dialogue12.SetActive(true);
            UIPanels[2].GetComponent<ActivateDisActivatePanels>().DisActivate();
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 4)
        {
            Dialogue13.SetActive(true);
            UIPanels[2].GetComponent<ActivateDisActivatePanels>().DisActivate();
        }
            
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 6)
        {
            Dialogue14.SetActive(true);
            UIPanels[5].GetComponent<ActivateDisActivatePanels>().DisActivate();
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 8)
        {
            Dialogue21.SetActive(true);
            UIPanels[2].GetComponent<ActivateDisActivatePanels>().DisActivate();
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 10)
        {
            Dialogue22.SetActive(true);
            UIPanels[5].GetComponent<ActivateDisActivatePanels>().DisActivate();
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 12)
        {
            Dialogue23.SetActive(true);
            UIPanels[5].GetComponent<ActivateDisActivatePanels>().DisActivate();
        }
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 14)
        {
            Dialogue31.SetActive(true);
            UIPanels[12].GetComponent<ActivateDisActivatePanels>().DisActivate();
        }

    
        if(PlayerPrefs.GetInt("IndexDialogue", 0) <= 15)
        {
            UIPanels[9].SetActive(true);
        }


        if(PlayerPrefs.GetInt("IndexDialogue", 0) >= 1)
        {
            UIPanels[0].SetActive(true);
            UIPanels[1].SetActive(true);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 1)
        {
            UIPanels[2].SetActive(true);
            UIPanels[3].SetActive(true);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 3)
        {
            TutorialTexts[0].text = "Зайти в банк";
            PlayerPrefs.SetInt("coins", 26);
            UIPanels[2].SetActive(true);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) >= 3)
        {
            UIPanels[4].SetActive(true);
            UIPanels[6].SetActive(true);
        }
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 5)
        {
            UIPanels[5].SetActive(true);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 7)
        {
            UIPanels[2].SetActive(true);
            TutorialTexts[0].text = "Купить модуль \"Турбина 1\"";

        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 9)
        {
            UIPanels[5].SetActive(true);
            TutorialTexts[1].text = "Зайди в отдел \"Модули\"";

        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) >= 9)
        {
            UIPanels[7].SetActive(true);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) >= 11)
        {
            UIPanels[10].SetActive(true);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 11)
        {
            UIPanels[5].SetActive(true);
            TutorialTexts[1].text = "Купить слот для турбины и поставь \"Турбина 1\"";
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) >= 13)
        {
            UIPanels[11].SetActive(true);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 13)
        {
            UIPanels[12].SetActive(true);
        }
    }

    public void ClickButton2()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 3)
        {
            PlayerPrefs.SetInt("IndexDialogue", 4);
            PlayerPrefs.SetInt("DialogueActive", 0);
            Invoke(nameof(UpdateDialogue), 2f);
        }
    }
    public void ClickButton1()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 1)
        {
            PlayerPrefs.SetInt("IndexDialogue", 2);
            PlayerPrefs.SetInt("DialogueActive", 0);
            Invoke(nameof(UpdateDialogue), 0.8f);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 7)
        {
            PlayerPrefs.SetInt("IndexDialogue", 8);
            PlayerPrefs.SetInt("DialogueActive", 0);
            Invoke(nameof(UpdateDialogue), 0.8f);
        }
    }
    public void ClickButton3()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 5 && PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            PlayerPrefs.SetInt("IndexDialogue", 6);
            PlayerPrefs.SetInt("DialogueActive", 0);
            Invoke(nameof(UpdateDialogue), 2f);
            UIPanels[8].SetActive(true);
        }
    }
    public void ClickButton4()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 9)
        {
            PlayerPrefs.SetInt("IndexDialogue", 10);
            PlayerPrefs.SetInt("DialogueActive", 0);
            Invoke(nameof(UpdateDialogue), 1.5f);
        }
    }
    public void ClickButton5()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 11)
        {
            PlayerPrefs.SetInt("IndexDialogue", 12);
            PlayerPrefs.SetInt("DialogueActive", 0);
            Invoke(nameof(UpdateDialogue), 1.5f);
        }
    }
    public void ClickButton6()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 13 && PlayerPrefs.GetInt("fuel", 0) == 5)
        {
            PlayerPrefs.SetInt("IndexDialogue", 14);
            PlayerPrefs.SetInt("DialogueActive", 0);
            Invoke(nameof(UpdateDialogue), 0.8f);
        }
    }
}
