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

    public GameObject Dialogue41;
    public GameObject Dialogue42;

    public GameObject[] DialogueMetals;
    public GameObject[] DialogueLombardMetals;

    public GameObject[] DialoguePanels;


    public menu menu;


    public GameObject[] UIPanels;
    public GameObject[] UILocked;
    public Text[] TutorialTexts;



    void Start()
    {
        UIPanels[16].GetComponent<Text>().text = "Продолжить";

        if(PlayerPrefs.GetInt("IndexDialogue", 0) <= 20)
        {
            PlayerPrefs.DeleteAll();
            UIPanels[16].GetComponent<Text>().text = "Начать";
        }

        foreach (GameObject msg in UIPanels)
        {
            msg.SetActive(false);
        }

        VoidDialoguesPanel();

        UIPanels[16].SetActive(true);

        if(PlayerPrefs.GetInt("IndexDialogue", 0) <= 20)
            Invoke(nameof(UpdateDialogue), 7f);
        if(PlayerPrefs.GetInt("IndexDialogue", 0) >= 20)
            UpdateDialogue();
    }

    public void DeActivate()
    {   
        VoidDialoguesPanel();

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

        if (Dialogue31.activeSelf)
            Dialogue31.GetComponent<DialogueManager>().Close();
        if (Dialogue32.activeSelf)
            Dialogue32.GetComponent<DialogueManager>().Close();

        if (Dialogue41.activeSelf)
            Dialogue41.GetComponent<DialogueManager>().Close();
        if (Dialogue42.activeSelf)
            Dialogue42.GetComponent<DialogueManager>().Close();

        if (DialogueMetals[0].activeSelf)
            DialogueMetals[0].GetComponent<DialogueManager>().Close();
        if (DialogueMetals[1].activeSelf)
            DialogueMetals[1].GetComponent<DialogueManager>().Close();

        if (DialogueLombardMetals[0].activeSelf)
            DialogueLombardMetals[0].GetComponent<DialogueManager>().Close();
        if (DialogueLombardMetals[1].activeSelf)
            DialogueLombardMetals[1].GetComponent<DialogueManager>().Close();

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 20)
            menu.is1g();
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

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 16)
        {
            Dialogue32.SetActive(true);
            UIPanels[5].GetComponent<ActivateDisActivatePanels>().DisActivate();
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 18)
        {
            Dialogue41.SetActive(true);
            UIPanels[2].GetComponent<ActivateDisActivatePanels>().DisActivate();
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

        if(PlayerPrefs.GetInt("IndexDialogue", 0) >= 15)
        {
            UIPanels[13].SetActive(true);
        }
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 15)
        {
            UIPanels[5].SetActive(true);
            TutorialTexts[1].text = "Выбрать количество канистр на игру";
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) >= 17)
        {
            UIPanels[13].SetActive(true);
        }
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 17)
        {
            UIPanels[2].SetActive(true);
            UIPanels[9].SetActive(false);
            UIPanels[14].SetActive(true);
            UIPanels[3].SetActive(false);
            UIPanels[15].SetActive(true);
            TutorialTexts[0].text = "Купить модуль бака и поставить его в слот бака";
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 19)
        {
            UIPanels[2].SetActive(true);
            TutorialTexts[0].text = "Поставить 5 канистр в подготовке и начать игру";
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 21)
        {
            if(PlayerPrefs.GetInt("TruekMetalls", 0) >= 1)
                DialogueMetals[1].SetActive(true);
            else if(PlayerPrefs.GetInt("TruekMetalls", 0) == 0)
                DialogueMetals[0].SetActive(true);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 24 || PlayerPrefs.GetInt("IndexDialogue", 0) == 25)
        {
            if(PlayerPrefs.GetInt("TruekMetalls", 0) >= 1)
                DialogueLombardMetals[1].SetActive(true);
            else if(PlayerPrefs.GetInt("TruekMetalls", 0) == 0)
                DialogueLombardMetals[0].SetActive(true);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) >= 22)
        {
            UIPanels[20].SetActive(true);
            UIPanels[21].SetActive(true);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) >= 21)
        {
            UIPanels[17].SetActive(true);
            UIPanels[18].SetActive(true);
            UIPanels[19].SetActive(true);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 24 || PlayerPrefs.GetInt("IndexDialogue", 0) == 25)
        {
            int Coins = PlayerPrefs.GetInt("coins");
            Coins += 80;
            PlayerPrefs.SetInt("coins", Coins);
        }

        if(PlayerPrefs.GetInt("allgames", 0) >= 2)
        {
            UIPanels[22].SetActive(true);
        }

        if(PlayerPrefs.GetInt("allgames", 0) >= 3)
        {
            UIPanels[21].SetActive(true);
        }

        if(PlayerPrefs.GetInt("allgames", 0) >= 8)
        {
            UIPanels[23].SetActive(true);
            UIPanels[24].SetActive(true);
            UIPanels[25].SetActive(true);
        }

        if(PlayerPrefs.GetInt("allgames", 0) >= 14)
        {
            UIPanels[26].SetActive(true);
            UIPanels[27].SetActive(true);
            UIPanels[28].SetActive(true);
            UIPanels[29].SetActive(true);
        }

        if(PlayerPrefs.GetInt("allgames", 0) >= 20)
        {
            UIPanels[30].SetActive(true);
        }
    }

    public void ClickButton2()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 3)
        {
            PlayerPrefs.SetInt("IndexDialogue", 4);
            Invoke(nameof(UpdateDialogue), 2f);
        }
    }
    public void ClickButton1()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 1)
        {
            PlayerPrefs.SetInt("IndexDialogue", 2);
            Invoke(nameof(UpdateDialogue), 0.8f);
        }

        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 7)
        {
            PlayerPrefs.SetInt("IndexDialogue", 8);
            Invoke(nameof(UpdateDialogue), 0.8f);
        }
    }
    public void ClickButton3()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 5 && PlayerPrefs.GetInt("CreditsActivee", 0) == 1)
        {
            PlayerPrefs.SetInt("IndexDialogue", 6);
            Invoke(nameof(UpdateDialogue), 2f);
            UIPanels[8].SetActive(true);
        }
    }
    public void ClickButton4()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 9)
        {
            PlayerPrefs.SetInt("IndexDialogue", 10);
            Invoke(nameof(UpdateDialogue), 1.5f);
        }
    }
    public void ClickButton5()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 11)
        {
            PlayerPrefs.SetInt("IndexDialogue", 12);
            Invoke(nameof(UpdateDialogue), 1.5f);
        }
    }
    public void ClickButton6()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 13 && PlayerPrefs.GetInt("fuel", 0) >= 5)
        {
            PlayerPrefs.SetInt("IndexDialogue", 14);
            Invoke(nameof(UpdateDialogue), 0.8f);
        }
    }
    public void ClickButton7()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 15)
        {
            PlayerPrefs.SetInt("IndexDialogue", 16);
            Invoke(nameof(UpdateDialogue), 2.5f);
        }
    }
    public void ClickButton8()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 17 && PlayerPrefs.GetString("Fuel1IndexModule", "") == "F1")
        {
            PlayerPrefs.SetInt("IndexDialogue", 18);
            Invoke(nameof(UpdateDialogue), 0.8f);
        }
    }
    public void ClickButton9()
    {
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 22)
        {
            PlayerPrefs.SetInt("IndexDialogue", 24);
            Invoke(nameof(UpdateDialogue), 0.8f);
        }
        if(PlayerPrefs.GetInt("IndexDialogue", 0) == 23)
        {
            PlayerPrefs.SetInt("IndexDialogue", 25);
            Invoke(nameof(UpdateDialogue), 1.6f);
        }
    }
    public void ClickButton10()
    {
        if(PlayerPrefs.GetInt("TasksDialogue", 0) == 0)
        {
            DialoguePanels[0].SetActive(true);
        }
    }
    public void ClickButton11()
    {
        if(PlayerPrefs.GetInt("PermanentTasksDialogue", 0) == 0)
        {
            DialoguePanels[1].SetActive(true);
        }
    }

    public void VoidDialoguesPanel()
    {
        if(DialoguePanels[0].activeSelf)
            DialoguePanels[0].GetComponent<DialogueManager>().Close();
        if(PlayerPrefs.GetInt("TasksDialogue", 0) == 1)
        {
            UILocked[0].SetActive(false);
            UIPanels[31].SetActive(true);
        }

        if(DialoguePanels[1].activeSelf)
            DialoguePanels[1].GetComponent<DialogueManager>().Close();
    }
}
