using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Реплики для диалогов")]
    public string[] Dialogue;
    public float[] Float;

    [Header("Для скрипта")]
    public Text[] Name;
    public Text[] Text;
    public GameObject[] Message;

    public Animator anim;
    public Animator[] MessageAnim;
    

    
    public ActivateDisActivatePanels Activate;

    private float Delay = 1.65f;
    private float Delay2;

    private int Index;

    private bool Max;
    private bool Dis;

    public int MaxIndex;
    public int Complete;

    public DIalogueActivate UpdateDialogue;

    public AudioSource SMS;

    void Start()
    {
        foreach (GameObject msg in Message)
        {
            msg.SetActive(false);
        }

        StartDialogue();
    }

    void Update()
    {
        if(Max == false)
            Delay -= Time.deltaTime;

        if(Delay <= 0 && PlayerPrefs.GetInt("DialogueActive", 0) == 0)
            Next();

        Delay2 -= Time.deltaTime;

        if(Delay2 <= 0 && Dis)
        {
            foreach (GameObject msg in Message)
            {
                msg.SetActive(false);
            }

            Dis = false;
        }
    }

    public void Next()
    {
        if(Index <= 5 && Index < MaxIndex)
        {
            SMS.Play();

            Delay = Float[Index];
            Message[Index].SetActive(true);
            MessageAnim[Index].Play("Start");
            Text[Index].text = Dialogue[Index];
            Name[Index].text = Dialogue[Index + 20];

            if(Dialogue[Index + 20] == "Алексей")
                Name[Index].color = new Color(113/255f, 224/255f, 107/255f);
            else    
                Name[5].color = new Color(1f, 100f / 255f, 237f / 255f);
        }
        else if(Index >= 6 && Index < MaxIndex)
        {
            SMS.Play();

            Delay = Float[Index];

            Text[0].text = Dialogue[Index - 5];
            Name[0].text = Dialogue[Index + 15];
            Text[1].text = Dialogue[Index - 4];
            Name[1].text = Dialogue[Index + 16];
            Text[2].text = Dialogue[Index - 3];
            Name[2].text = Dialogue[Index + 17];
            Text[3].text = Dialogue[Index - 2];
            Name[3].text = Dialogue[Index + 18];
            Text[4].text = Dialogue[Index - 1];
            Name[4].text = Dialogue[Index + 19];
            Text[5].text = Dialogue[Index];
            Name[5].text = Dialogue[Index + 20];

            if(Dialogue[Index + 20] == "Алексей")
                Name[5].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[5].color = new Color(1f, 100f / 255f, 237f / 255f);

            if(Dialogue[Index + 19] == "Алексей")
                Name[4].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[4].color = new Color(1f, 100f / 255f, 237f / 255f);

            if(Dialogue[Index + 18] == "Алексей")
                Name[3].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[3].color = new Color(1f, 100f / 255f, 237f / 255f);

            if(Dialogue[Index + 17] == "Алексей")
                Name[2].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[2].color = new Color(1f, 100f / 255f, 237f / 255f);
                
            if(Dialogue[Index + 16] == "Алексей")
                Name[1].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[1].color = new Color(1f, 100f / 255f, 237f / 255f);

            if(Dialogue[Index + 15] == "Алексей")
                Name[0].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[0].color = new Color(1f, 100f / 255f, 237f / 255f);
        }
        else if(Index >= MaxIndex)
        {
            anim.Play("AnswerClose");
            Max = true;
        }

        Index++;
    }

    public void Close()
    {
        Index = 0;
        PlayerPrefs.SetInt("DialogueActive", 1);
        PlayerPrefs.SetInt("IndexDialogue", Complete);

        Dis = true;
        Delay2 = 0.7f;

        foreach (Animator msgA in MessageAnim)
        {
            msgA.Play("End");
        }

        UpdateDialogue.UpdateDialogue();
    }
    public void StartDialogue()
    {
        if(PlayerPrefs.GetInt("DialogueActive", 0) == 0)
        {
            Activate.Activate();
        }
    }
}
