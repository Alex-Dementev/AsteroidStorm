using System;
using UnityEngine;

public class Cheaters : MonoBehaviour
{
    void Start()
    {
        CheckTimeCheat();
    }

    void CheckTimeCheat()
    {
        string lastTimeStr = PlayerPrefs.GetString("lastPlayTime", "");
        DateTime lastTime;

        if (!string.IsNullOrEmpty(lastTimeStr) && DateTime.TryParse(lastTimeStr, out lastTime))
        {
            DateTime now = DateTime.Now;

            // Если время откатили назад
            if (lastTime > now)
            {
                TimeSpan diff = lastTime - now;

                // Если "откат" меньше 10 лет
                if (diff.TotalDays < 3650) 
                {
                    int fiveMinuteSteps = (int)(diff.TotalMinutes / 5);
                    int penalty = fiveMinuteSteps * 20;

                    int coins = PlayerPrefs.GetInt("coins", 0);
                    int wincoins = PlayerPrefs.GetInt("wincoins", 0);

                    if (coins >= penalty)
                    {
                        coins -= penalty;
                    }
                    else
                    {
                        penalty -= coins;
                        coins = 0;

                        if (wincoins >= penalty)
                        {
                            wincoins -= penalty;
                        }
                        else
                        {
                            wincoins = 0;
                        }
                    }

                    PlayerPrefs.SetInt("coins", coins);
                    PlayerPrefs.SetInt("wincoins", wincoins);
                }
            }
        }

        // Обновляем время
        PlayerPrefs.SetString("lastPlayTime", DateTime.Now.ToString());
        PlayerPrefs.Save();
    }
}
