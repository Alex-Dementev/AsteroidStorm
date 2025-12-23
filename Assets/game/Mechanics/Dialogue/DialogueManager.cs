using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Реплики для диалогов")]
    public string[] Dialogue0;
    public string[] Dialogue1;

    public float[] Float0;
    public float[] Float1;

    [Header("Для скрипта")]
    public Text[] Name;
    public Text[] Text;
    public GameObject[] Message;

    public Animator anim;
    public Animator[] MessageAnim;
    

    
    public ActivateDisActivatePanels Activate;

    private float Delay = 3;
    private float Delay2;

    private int IndexDialogue;
    private int Index;

    private bool Max;
    private bool Dis;
    private bool Dis2;

    public int MaxIndex;

    void Start()
    {
        foreach (GameObject msg in Message)
        {
            msg.SetActive(false);
        }

        
        StartDialogue();

        PlayerPrefs.SetInt("DialogueActive", 0);
    }

    void Update()
    {
        if(Max == false)
            Delay -= Time.deltaTime;

        if(Delay <= 0)
            Next();

        Delay2 -= Time.deltaTime;

        if(Delay2 <= 0 && Dis2)
        {
            foreach (GameObject msg in Message)
            {
                msg.SetActive(false);
            }

            Dis2 = false;
        }
    }

    public void Next()
    {
        if(Index <= 5)
        {
            if(IndexDialogue == 0)
            {
                Delay = Float0[Index];
                Message[Index].SetActive(true);
                Text[Index].text = Dialogue0[Index];
                Name[Index].text = Dialogue0[Index + 10];

                if(Dialogue0[Index + 20] == "Алексей")
                {
                    Name[Index].color = new Color(113/255f, 224/255f, 107/255f);
                }
            }
        }
        else if(Index >= 6 && Index <= 8)
        {
            Delay = Float0[Index];

            Text[0].text = Dialogue0[Index - 5];
            Name[0].text = Dialogue0[Index + 15];
            Text[1].text = Dialogue0[Index - 4];
            Name[1].text = Dialogue0[Index + 16];
            Text[2].text = Dialogue0[Index - 3];
            Name[2].text = Dialogue0[Index + 17];
            Text[3].text = Dialogue0[Index - 2];
            Name[3].text = Dialogue0[Index + 18];
            Text[4].text = Dialogue0[Index - 1];
            Name[4].text = Dialogue0[Index + 19];
            Text[5].text = Dialogue0[Index];
            Name[5].text = Dialogue0[Index + 20];

            if(Dialogue0[Index + 20] == "Алексей")
                Name[5].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[5].color = new Color(1f, 100f / 255f, 237f / 255f);

            if(Dialogue0[Index + 19] == "Алексей")
                Name[4].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[4].color = new Color(1f, 100f / 255f, 237f / 255f);

            if(Dialogue0[Index + 18] == "Алексей")
                Name[3].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[3].color = new Color(1f, 100f / 255f, 237f / 255f);

            if(Dialogue0[Index + 17] == "Алексей")
                Name[2].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[2].color = new Color(1f, 100f / 255f, 237f / 255f);
                
            if(Dialogue0[Index + 16] == "Алексей")
                Name[1].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[1].color = new Color(1f, 100f / 255f, 237f / 255f);

            if(Dialogue0[Index + 15] == "Алексей")
                Name[0].color = new Color(113/255f, 224/255f, 107/255f);
            else
                Name[0].color = new Color(1f, 100f / 255f, 237f / 255f);
        }
        else if(Index >= MaxIndex)
        {
            if(!Max && !Dis)
            {
                Delay = 3;
                Dis = true;
            }

            if(!Max)
            {
                anim.Play("AnswerClose");
                Max = true;
            }
        }

        Index++;
    }

    public void Close()
    {
        Index = 0;
        PlayerPrefs.SetInt("DialogueActive", 1);

        Dis2 = true;
        Delay2 = 0.7f;

        foreach (Animator msgA in MessageAnim)
        {
            msgA.Play("End");
        }
    }
    public void StartDialogue()
    {
        if(PlayerPrefs.GetInt("DialogueActive", 0) == 0)
        {
            Activate.Activate();
            IndexDialogue = PlayerPrefs.GetInt("IndexDialogue", 0);
            Next();
        }
    }
}
