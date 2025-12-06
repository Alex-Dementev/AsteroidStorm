using UnityEngine;
using UnityEngine.UI;

public class PermanentTasks : MonoBehaviour
{
    public Text Desc;
    public Text DescPositive;
    public Text LevelDesc;
    public Text Level;
    public Text Task;
    public Slider Slider;
    public int Type;
    public Image Give;
    public GameObject goDesc;
    public GameObject go2;
    public GameObject go3;
    public GameObject goReward;
    public GameObject goSlider;
    public GameObject goGive;
    
    
    public void UpdateDesc()
    {
        goDesc.SetActive(true);
        go2.SetActive(true);
        go3.SetActive(true);
        goReward.SetActive(true);
        goSlider.SetActive(true);
        goGive.SetActive(true);

        PlayerPrefs.SetInt("IndexTypeToPermonentTasks", Type);

        if(Type == 1)
        {
            LevelDesc.text = ("Уровень: " + PlayerPrefs.GetInt("LevelTask1", 0) + "/3");

            if(PlayerPrefs.GetInt("LevelTask1", 0) == 0)
            {
                Desc.text = ("Описание: купи 200 канистр чтобы получить награду");
                LevelDesc.text = ("Уровень: 0/3");
                DescPositive.text = ("-");
                Slider.maxValue = 200;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskFuel", 0);
                Task.text = ("Купленно: " + PlayerPrefs.GetInt("PermanentTaskFuel", 0) + "/200 канистр");
                PlayerPrefs.SetInt("AllColl", 200);

                if(PlayerPrefs.GetInt("PermanentTaskFuel", 0) >= 200)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask1", 0) == 1)
            {
                Desc.text = ("Описание: купи 500 канистр чтобы увеличить награду");
                LevelDesc.text = ("Уровень: 1/3");
                DescPositive.text = ("Награда: скидка на топливо 10%");
                Slider.maxValue = 500;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskFuel", 0);
                Task.text = ("Купленно: " + PlayerPrefs.GetInt("PermanentTaskFuel", 0) + "/500 канистр");
                PlayerPrefs.SetInt("AllColl", 500);
                PlayerPrefs.SetInt("DiscountOnFuel", 9);

                if(PlayerPrefs.GetInt("PermanentTaskFuel", 0) >= 500)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask1", 0) == 2)
            {
                Desc.text = ("Описание: купи 1000 канистр чтобы увеличить награду");
                LevelDesc.text = ("Уровень: 2/3");
                DescPositive.text = ("Награда: скидка на топливо 20%");
                Slider.maxValue = 1000;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskFuel", 0);
                Task.text = ("Купленно: " + PlayerPrefs.GetInt("PermanentTaskFuel", 0) + "/1000 канистр");
                PlayerPrefs.SetInt("AllColl", 1000);
                PlayerPrefs.SetInt("DiscountOnFuel", 8);

                if(PlayerPrefs.GetInt("PermanentTaskFuel", 0) >= 1000)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask1", 0) == 3)
            {
                PlayerPrefs.SetInt("DiscountOnFuel", 7);
                Desc.text = ("Ты выполнил все задания типа канистры");
                DescPositive.text = ("Награда: скидка на топливо 30%");
                go2.SetActive(false);
                go3.SetActive(false);
                goSlider.SetActive(false);
                goGive.SetActive(false);
            }
        }
        if(Type == 2)
        {
            LevelDesc.text = ("Уровень: " + PlayerPrefs.GetInt("LevelTask2", 0) + "/3");

            if(PlayerPrefs.GetInt("LevelTask2", 0) == 0)
            {
                Desc.text = ("Описание: выработай 600 едениц энергии чтобы получить награду");
                LevelDesc.text = ("Уровень: 0/3");
                DescPositive.text = ("-");
                Slider.maxValue = 600;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskEnergy", 0);
                Task.text = ("Выработанно: " + PlayerPrefs.GetInt("PermanentTaskEnergy", 0) + "/600 едениц энергии");
                PlayerPrefs.SetInt("AllColl", 600);

                if(PlayerPrefs.GetInt("PermanentTaskEnergy", 0) >= 600)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask2", 0) == 1)
            {
                Desc.text = ("Описание: выработай 2000 едениц энергии чтобы увеличить награду");
                LevelDesc.text = ("Уровень: 1/3");
                DescPositive.text = ("Награда: эффективность выработки энергии +10%");
                Slider.maxValue = 2000;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskEnergy", 0);
                Task.text = ("Выработанно: " + PlayerPrefs.GetInt("PermanentTaskEnergy", 0) + "/2000 едениц энергии");
                PlayerPrefs.SetInt("AllColl", 2000);
                PlayerPrefs.SetFloat("ProductivityOnEnergy", 1.1f);

                if(PlayerPrefs.GetInt("PermanentTaskEnergy", 0) >= 2000)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask2", 0) == 2)
            {
                Desc.text = ("Описание: выработай 5000 едениц энергии чтобы увеличить награду");
                LevelDesc.text = ("Уровень: 2/3");
                DescPositive.text = ("Награда: эффективность выработки энергии +20%");
                Slider.maxValue = 5000;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskEnergy", 0);
                Task.text = ("Выработанно: " + PlayerPrefs.GetInt("PermanentTaskEnergy", 0) + "/5000 едениц энергии");
                PlayerPrefs.SetInt("AllColl", 5000);
                PlayerPrefs.SetFloat("ProductivityOnEnergy", 1.2f);

                if(PlayerPrefs.GetInt("PermanentTaskEnergy", 0) >= 5000)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask2", 0) == 3)
            {
                PlayerPrefs.SetFloat("ProductivityOnEnergy", 1.3f);
                Desc.text = ("Ты выполнил все задания типа энергия");
                DescPositive.text = ("Награда: эффективность выработки энергии +30%");
                go2.SetActive(false);
                go3.SetActive(false);
                goSlider.SetActive(false);
                goGive.SetActive(false);
            }
        }
        if(Type == 3)
        {
            LevelDesc.text = ("Уровень: " + PlayerPrefs.GetInt("LevelTask3", 0) + "/3");

            if(PlayerPrefs.GetInt("LevelTask3", 0) == 0)
            {
                Desc.text = ("Описание: начни игру 15 раз чтобы получить награду");
                LevelDesc.text = ("Уровень: 0/3");
                DescPositive.text = ("-");
                Slider.maxValue = 15;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskLife", 0);
                Task.text = ("Начато: " + PlayerPrefs.GetInt("PermanentTaskLife", 0) + "/15 залетов");
                PlayerPrefs.SetInt("AllColl", 15);

                if(PlayerPrefs.GetInt("PermanentTaskLife", 0) >= 15)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask3", 0) == 1)
            {
                Desc.text = ("Описание: начни игру 35 раз чтобы увеличить награду");
                LevelDesc.text = ("Уровень: 1/3");
                DescPositive.text = ("Награда: жизни +1");
                Slider.maxValue = 35;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskLife", 0);
                Task.text = ("Начато: " + PlayerPrefs.GetInt("PermanentTaskLife", 0) + "/35 залетов");
                PlayerPrefs.SetInt("AllColl", 35);
                PlayerPrefs.SetInt("LifeToStart", 2);

                if(PlayerPrefs.GetInt("PermanentTaskLife", 0) >= 35)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask3", 0) == 2)
            {
                Desc.text = ("Описание: начни игру 135 раз чтобы увеличить награду");
                LevelDesc.text = ("Уровень: 2/3");
                DescPositive.text = ("Награда: жизни +2");
                Slider.maxValue = 135;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskLife", 0);
                Task.text = ("Начато: " + PlayerPrefs.GetInt("PermanentTaskLife", 0) + "/135 залетов");
                PlayerPrefs.SetInt("AllColl", 135);
                PlayerPrefs.SetInt("LifeToStart", 3);

                if(PlayerPrefs.GetInt("PermanentTaskLife", 0) >= 135)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask3", 0) == 3)
            {
                PlayerPrefs.SetInt("LifeToStart", 4);
                Desc.text = ("Ты выполнил все задания типа жизни");
                DescPositive.text = ("Награда: жизни +3");
                go2.SetActive(false);
                go3.SetActive(false);
                goSlider.SetActive(false);
                goGive.SetActive(false);
            }
        }
        if(Type == 4)
        {
            LevelDesc.text = ("Уровень: " + PlayerPrefs.GetInt("LevelTask4", 0) + "/3");

            if(PlayerPrefs.GetInt("LevelTask4", 0) == 0)
            {
                Desc.text = ("Описание: сломай астероид 350 раз");
                LevelDesc.text = ("Уровень: 0/3");
                DescPositive.text = ("-");
                Slider.maxValue = 350;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskMetals", 0);
                Task.text = ("Уничтоженно: " + PlayerPrefs.GetInt("PermanentTaskMetals", 0) + "/350 астероидов");
                PlayerPrefs.SetInt("AllColl", 350);

                if(PlayerPrefs.GetInt("PermanentTaskMetals", 0) >= 350)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask4", 0) == 1)
            {
                Desc.text = ("Описание: сломай астероид 650 раз");
                LevelDesc.text = ("Уровень: 1/3");
                DescPositive.text = ("Награда: стоимость металлов +10%");
                Slider.maxValue = 650;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskMetals", 0);
                Task.text = ("Уничтоженно: " + PlayerPrefs.GetInt("PermanentTaskMetals", 0) + "/650 астероидов");
                PlayerPrefs.SetInt("AllColl", 650);
                PlayerPrefs.SetFloat("DiscountOnLombart", 0.9f);

                if(PlayerPrefs.GetInt("PermanentTaskMetals", 0) >= 650)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask4", 0) == 2)
            {
                Desc.text = ("Описание: сломай астероид 1300 раз");
                LevelDesc.text = ("Уровень: 2/3");
                DescPositive.text = ("Награда: стоимость металлов +20%");
                Slider.maxValue = 1300;
                Slider.value = PlayerPrefs.GetInt("PermanentTaskMetals", 0);
                Task.text = ("Уничтоженно: " + PlayerPrefs.GetInt("PermanentTaskMetals", 0) + "/1300 астероидов");
                PlayerPrefs.SetInt("AllColl", 1300);
                PlayerPrefs.SetFloat("DiscountOnLombart", 0.8f);

                if(PlayerPrefs.GetInt("PermanentTaskMetals", 0) >= 1300)
                    Give.color = new Color(135f/255f, 0f, 138f/255f);
                else
                    Give.color = new Color(121f/255f, 78f/255f, 119f/255f);
            }
            if(PlayerPrefs.GetInt("LevelTask4", 0) == 3)
            {
                PlayerPrefs.SetFloat("DiscountOnLombart", 0.7f);
                Desc.text = ("Ты выполнил все задания типа металлы");
                DescPositive.text = ("Награда: стоимость металлов +30%");
                go2.SetActive(false);
                go3.SetActive(false);
                goSlider.SetActive(false);
                goGive.SetActive(false);
            }
        }
        if(Type == 0)
        {
            LevelDesc.text = ("-");
            Desc.text = ("Промах");
            DescPositive.text = ("-");
            LevelDesc.text = ("-");
            Task.text = ("-");
            go2.SetActive(false);
            go3.SetActive(false);
            goReward.SetActive(false);
            goSlider.SetActive(false);
            goGive.SetActive(false);
        }
    }
    void Start()
    {
        if(Type == 1)
        Level.text = ("Уровень: " + PlayerPrefs.GetInt("LevelTask1", 0) + "/3");
        if(Type == 2)
        Level.text = ("Уровень: " + PlayerPrefs.GetInt("LevelTask2", 0) + "/3");
        if(Type == 3)
        Level.text = ("Уровень: " + PlayerPrefs.GetInt("LevelTask3", 0) + "/3");
        if(Type == 4)
        Level.text = ("Уровень: " + PlayerPrefs.GetInt("LevelTask4", 0) + "/3");
    }
}
