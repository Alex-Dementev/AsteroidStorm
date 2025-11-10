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

    public int[] rewardsBlock1 = new int[4];
    public int[] rewardsBlock2 = new int[4];

    public AudioSource rewardSound;
    public Animator TaskAttract;

    private int[] block1 = { 0, 1, 2, 3 };
    private int[] block2 = { 0, 1, 2, 3 };

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

        if (currentTask1 == -1) currentTask1 = RandomTask(block1);
        if (currentTask2 == -1) currentTask2 = RandomTask(block2);

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
        }
        task1RewardText.text = "Награда: " + rewardsBlock1[currentTask1] + " монет";

        // Блок 2
        switch (currentTask2)
        {
            case 0:
                task2Text.text = "Пробить 2 препятствия способностью за один раз";
                task2Slider.maxValue = 2;
                task2Slider.value = PlayerPrefs.GetInt("breakObstacles", 0);
                break;
            case 1:
                task2Text.text = "Собрать бонус 5 раз";
                task2Slider.maxValue = 5;
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
        if (task1Completed) return; // уже выполнено, ждем сбор

        bool completed = false;
        switch (currentTask1)
        {
            case 0: if (PlayerPrefs.GetInt("abilityt", 0) >= 10) completed = true; break;
            case 1: if (PlayerPrefs.GetFloat("taskTime", 0) >= 600) completed = true; break;
            case 2: if (PlayerPrefs.GetInt("scoreNoDamage", 0) >= 700 && PlayerPrefs.GetInt("isbtotask") == 1)
                    { completed = true; PlayerPrefs.SetInt("isbtotask", 0); } break;
            case 3: if (PlayerPrefs.GetInt("scoreNoAbility", 0) >= 700) completed = true; break;
        }

        if (completed) task1Completed = true;
    }

    void CheckTask2Completion()
    {
        if (task2Completed) return; // уже выполнено, ждем сбор

        bool completed = false;
        switch (currentTask2)
        {
            case 0: if (PlayerPrefs.GetInt("breakObstacles", 0) >= 2) completed = true; break;
            case 1: if (PlayerPrefs.GetInt("collectBonus", 0) >= 5) completed = true; break;
            case 2: if (PlayerPrefs.GetInt("loseLife", 0) >= 15) completed = true; break;
            case 3: if (PlayerPrefs.GetInt("abilityOver80", 0) >= 1) completed = true; break;
        }

        if (completed) task2Completed = true;
    }

    void HandleAnimation()
    {
        TaskAttract.SetBool("IsTrue", task1Completed || task2Completed);
    }

    public void CollectTask1Reward()
    {
        if (!task1Completed) return;

        GiveReward(rewardsBlock1[currentTask1]);
        task1Completed = false;
        TaskAttract.SetBool("IsTrue", false);

        int[] remaining = RemainingTasks(block1, currentTask1);
        currentTask1 = remaining[Random.Range(0, remaining.Length)];
        PlayerPrefs.SetInt("currentTask1", currentTask1);
        ResetTask1Progress();
        UpdateUI();
    }

    public void CollectTask2Reward()
    {
        if (!task2Completed) return;

        GiveReward(rewardsBlock2[currentTask2]);
        task2Completed = false;
        TaskAttract.SetBool("IsTrue", false);

        int[] remaining = RemainingTasks(block2, currentTask2);
        currentTask2 = remaining[Random.Range(0, remaining.Length)];
        PlayerPrefs.SetInt("currentTask2", currentTask2);
        ResetTask2Progress();
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
        }
    }

    void ResetTask2Progress()
    {
        switch (currentTask2)
        {
            case 0: PlayerPrefs.SetInt("breakObstacles", 0); break;
            case 1: PlayerPrefs.SetInt("collectBonus", 0); break;
            case 2: PlayerPrefs.SetInt("loseLife", 0); break;
            case 3: PlayerPrefs.SetInt("abilityOver80", 0); break;
        }
    }
}
