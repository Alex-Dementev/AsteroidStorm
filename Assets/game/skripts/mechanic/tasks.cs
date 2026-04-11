using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tasks : MonoBehaviour
{
    public Text task1Text;
    public Slider task1Slider;
    public Text task2Text;
    public Slider task2Slider;

    public Text task1RewardText;
    public Text task2RewardText;

    public int[] rewardsBlock1 = new int[6];
    public int[] rewardsBlock2 = new int[6];

    public AudioSource rewardSound;
    public Animator TaskAttract;

    private int[] block1 = { 0, 1, 2, 3, 4, 5 };
    private int[] block2 = { 0, 1, 2, 3, 4, 5 };

    private int currentTask1 = -1;
    private int currentTask2 = -1;

    private bool task1Completed = false;
    private bool task2Completed = false;

    void Start()
    {
        LoadTasks();
        UpdateUI();
    }

    void LoadTasks()
    {
        currentTask1 = PlayerPrefs.GetInt("currentTask1", -1);
        currentTask2 = PlayerPrefs.GetInt("currentTask2", -1);

        if (currentTask1 == -1)
        {
            currentTask1 = RandomTask(block1);
            PlayerPrefs.SetInt("ScoreTask", PlayerPrefs.GetInt("allscore", 0));
            PlayerPrefs.SetInt("CasinoTask", PlayerPrefs.GetInt("Casino", 0));
        }
        if (currentTask2 == -1)
        {
            currentTask2 = RandomTask(block2);
            PlayerPrefs.SetInt("AllBuyedModulsTask", PlayerPrefs.GetInt("AllBuyedModuls", 0));
            PlayerPrefs.SetFloat("diamondMassTask", PlayerPrefs.GetFloat("diamondMass", 0));
        }

        PlayerPrefs.SetInt("currentTask1", currentTask1);
        PlayerPrefs.SetInt("currentTask2", currentTask2);
    }

    int RandomTask(int[] block)
    {
        return block[Random.Range(0, block.Length)];
    }

    void UpdateUI()
    {
        // Блок 1
        switch (currentTask1)
        {
            case 0:
                task1Text.text = "Использовать способность 10 раз";
                task1Slider.maxValue = 10;
                task1Slider.value = PlayerPrefs.GetInt("abilityt", 0);
                break;
            case 1:
                task1Text.text = "Провести в игре 10 минут";
                task1Slider.maxValue = 600;
                task1Slider.value = PlayerPrefs.GetFloat("taskTime", 0);
                break;
            case 2:
                task1Text.text = "Набрать 700 очков без повреждений";
                task1Slider.maxValue = 700;
                task1Slider.value = PlayerPrefs.GetInt("scoreNoDamage", 0);
                break;
            case 3:
                task1Text.text = "Набрать 700 очков без использования способности";
                task1Slider.maxValue = 700;
                task1Slider.value = PlayerPrefs.GetInt("scoreNoAbility", 0);
                break;
            case 4:
                task1Text.text = "Набрать 2500 очков";
                task1Slider.maxValue = 2500;
                task1Slider.value = PlayerPrefs.GetInt("allallscore", 0) - PlayerPrefs.GetInt("ScoreTask", 0);
                break;
            case 5:
                task1Text.text = "Сыграть в казино 7 раз";
                task1Slider.maxValue = 50;
                task1Slider.value = PlayerPrefs.GetInt("Casino", 0) - PlayerPrefs.GetInt("CasinoTask", 0);
                break;
        }
        task1RewardText.text = "Награда: " + rewardsBlock1[currentTask1] + " монет";

        // Блок 2
        switch (currentTask2)
        {
            case 0:
                task2Text.text = "3 раза закончи вылет окончанием топлива";
                task2Slider.maxValue = 3;
                task2Slider.value = PlayerPrefs.GetInt("DeathOnFuel", 0);
                break;
            case 1:
                task2Text.text = "Собрать бонус 10 раз";
                task2Slider.maxValue = 10;
                task2Slider.value = PlayerPrefs.GetInt("collectBonus", 0);
                break;
            case 2:
                task2Text.text = "Потерять жизнь 15 раз";
                task2Slider.maxValue = 15;
                task2Slider.value = PlayerPrefs.GetInt("loseLife", 0);
                break;
            case 3:
                task2Text.text = "Использовать способность при >80% энергии";
                task2Slider.maxValue = 1;
                task2Slider.value = PlayerPrefs.GetInt("abilityOver80", 0);
                break;
            case 4:
                task2Text.text = "Купить 2 новых модуля";
                task2Slider.maxValue = 2;
                task2Slider.value = PlayerPrefs.GetInt("AllBuyedModuls", 0) - PlayerPrefs.GetInt("AllBuyedModulsTask", 0);
                break;
            case 5:
                task2Text.text = "Собрать алмазы";
                task2Slider.maxValue = 0.1f;
                task2Slider.value = PlayerPrefs.GetFloat("diamondMass", 0) - PlayerPrefs.GetFloat("diamondMassTask", 0);
                break;
        }
        task2RewardText.text = "Награда: " + rewardsBlock2[currentTask2] + " монет";
    }

    void Update()
    {
        UpdateUI();
        CheckTask1Completion();
        CheckTask2Completion();
        HandleAnimation();
    }

    void CheckTask1Completion()
    {
        if (task1Completed) return;

        bool completed = false;
        switch (currentTask1)
        {
            case 0: if (PlayerPrefs.GetInt("abilityt", 0) >= 10) completed = true; break;
            case 1: if (PlayerPrefs.GetFloat("taskTime", 0) >= 600) completed = true; break;
            case 2: if (PlayerPrefs.GetInt("scoreNoDamage", 0) >= 700 && PlayerPrefs.GetInt("isbtotask") == 1)
                { completed = true; PlayerPrefs.SetInt("isbtotask", 0); } break;
            case 3: if (PlayerPrefs.GetInt("scoreNoAbility", 0) >= 700) completed = true; break;
            case 4: if (PlayerPrefs.GetInt("allscore", 0) - PlayerPrefs.GetInt("ScoreTask", 0) >= 2500) completed = true; break;
            case 5: if (PlayerPrefs.GetInt("Casino", 0) - PlayerPrefs.GetInt("CasinoTask", 0) >= 7) completed = true; break;
        }

        if (completed) task1Completed = true;
    }

    void CheckTask2Completion()
    {
        if (task2Completed) return;

        bool completed = false;
        switch (currentTask2)
        {
            case 0: if (PlayerPrefs.GetInt("DeathOnFuel", 0) >= 3) completed = true; break;
            case 1: if (PlayerPrefs.GetInt("collectBonus", 0) >= 10) completed = true; break;
            case 2: if (PlayerPrefs.GetInt("loseLife", 0) >= 15) completed = true; break;
            case 3: if (PlayerPrefs.GetInt("abilityOver80", 0) >= 1) completed = true; break;
            case 4: if (PlayerPrefs.GetInt("AllBuyedModuls", 0) - PlayerPrefs.GetInt("AllBuyedModulsTask", 0) >= 2) completed = true; break;
            case 5: if (PlayerPrefs.GetFloat("diamondMass", 0) - PlayerPrefs.GetFloat("diamondMassTask", 0) >= 0.1f) completed = true; break;
        }

        if (completed) task2Completed = true;
    }

    void HandleAnimation()
    {
        bool hasSimpleTask = task1Completed || task2Completed;
        bool hasPermanentTask = CheckPermanentTasks();

        if (hasSimpleTask || hasPermanentTask)
            TaskAttract.SetBool("IsTrue", true);
        else
            TaskAttract.SetBool("IsTrue", false);
    }

    bool CheckPermanentTasks()
    {
        if(PlayerPrefs.GetInt("LevelTask1", 0) == 0 && PlayerPrefs.GetInt("PermanentTaskFuel", 0) >= 300) return true;
        if(PlayerPrefs.GetInt("LevelTask1", 0) == 1 && PlayerPrefs.GetInt("PermanentTaskFuel", 0) >= 800) return true;
        if(PlayerPrefs.GetInt("LevelTask1", 0) == 2 && PlayerPrefs.GetInt("PermanentTaskFuel", 0) >= 2000) return true;

        if(PlayerPrefs.GetInt("LevelTask2", 0) == 0 && PlayerPrefs.GetInt("PermanentTaskEnergy", 0) >= 1200) return true;
        if(PlayerPrefs.GetInt("LevelTask2", 0) == 1 && PlayerPrefs.GetInt("PermanentTaskEnergy", 0) >= 3500) return true;
        if(PlayerPrefs.GetInt("LevelTask2", 0) == 2 && PlayerPrefs.GetInt("PermanentTaskEnergy", 0) >= 10000) return true;

        if(PlayerPrefs.GetInt("LevelTask3", 0) == 0 && PlayerPrefs.GetInt("PermanentTaskLife", 0) >= 30) return true;
        if(PlayerPrefs.GetInt("LevelTask3", 0) == 1 && PlayerPrefs.GetInt("PermanentTaskLife", 0) >= 95) return true;
        if(PlayerPrefs.GetInt("LevelTask3", 0) == 2 && PlayerPrefs.GetInt("PermanentTaskLife", 0) >= 200) return true;

        if(PlayerPrefs.GetInt("LevelTask4", 0) == 0 && PlayerPrefs.GetInt("PermanentTaskMetalls", 0) >= 500) return true;
        if(PlayerPrefs.GetInt("LevelTask4", 0) == 1 && PlayerPrefs.GetInt("PermanentTaskMetalls", 0) >= 850) return true;
        if(PlayerPrefs.GetInt("LevelTask4", 0) == 2 && PlayerPrefs.GetInt("PermanentTaskMetalls", 0) >= 1450) return true;

        return false;
    }

    public void CollectTask1Reward()
    {
        if (!task1Completed) return;

        GiveReward(rewardsBlock1[currentTask1]);
        task1Completed = false;

        int[] remaining = RemainingTasks(block1, currentTask1);
        currentTask1 = remaining[Random.Range(0, remaining.Length)];
        PlayerPrefs.SetInt("currentTask1", currentTask1);
        ResetTask1Progress();

        PlayerPrefs.SetInt("ScoreTask", PlayerPrefs.GetInt("allscore", 0));
        PlayerPrefs.SetInt("CasinoTask", PlayerPrefs.GetInt("Casino", 0));

        UpdateUI();
    }

    public void CollectTask2Reward()
    {
        if (!task2Completed) return;

        GiveReward(rewardsBlock2[currentTask2]);
        task2Completed = false;

        int[] remaining = RemainingTasks(block2, currentTask2);
        currentTask2 = remaining[Random.Range(0, remaining.Length)];
        PlayerPrefs.SetInt("currentTask2", currentTask2);
        ResetTask2Progress();
        
        PlayerPrefs.SetInt("AllBuyedModulsTask", PlayerPrefs.GetInt("AllBuyedModuls", 0));
        PlayerPrefs.SetFloat("diamondMassTask", PlayerPrefs.GetFloat("diamondMass", 0));

        UpdateUI();
    }

    void GiveReward(int rewardAmount)
    {
        int coins = PlayerPrefs.GetInt("coins", 0);
        int allcoins = PlayerPrefs.GetInt("allcoins", 0);
        coins += rewardAmount;
        allcoins += rewardAmount;
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("allcoins", allcoins);

        Debug.Log("🎉 Игрок получил " + rewardAmount + " монет!");
        if (rewardSound != null) rewardSound.Play();
    }

    int[] RemainingTasks(int[] block, int done)
    {
        List<int> rem = new List<int>();
        foreach (var t in block) if (t != done) rem.Add(t);
        return rem.ToArray();
    }

    void ResetTask1Progress()
    {
        switch (currentTask1)
        {
            case 0: PlayerPrefs.SetInt("abilityt", 0); break;
            case 1: PlayerPrefs.SetFloat("taskTime", 0); break;
            case 2: PlayerPrefs.SetInt("scoreNoDamage", 0); break;
            case 3: PlayerPrefs.SetInt("scoreNoAbility", 0); break;
            case 4: PlayerPrefs.SetInt("ScoreTask", 0); break;
            case 5: PlayerPrefs.SetInt("CasinoTask", 0); break;
        }
    }

    void ResetTask2Progress()
    {
        switch (currentTask2)
        {
            case 0: PlayerPrefs.SetInt("DeathOnFuel", 0); break;
            case 1: PlayerPrefs.SetInt("collectBonus", 0); break;
            case 2: PlayerPrefs.SetInt("loseLife", 0); break;
            case 3: PlayerPrefs.SetInt("abilityOver80", 0); break;
            case 4: PlayerPrefs.SetInt("AllBuyedModulsTask", 0); break;
            case 5: PlayerPrefs.SetFloat("diamondMassTask", 0); break;
        }
    }
}