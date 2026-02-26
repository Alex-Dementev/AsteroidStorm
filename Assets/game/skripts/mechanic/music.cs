using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource ad1;     // Первая музыка
    public AudioSource ad1_2;   // Вторая музыка
    public AudioSource ad1_3;   // Третья музыка
    public float musics;

    [Header("Определяет, используется ли музыка для игровой сцены")]
    public bool isGameScene = false;
    private bool PashalkMusic;
    private bool PashalkMusicIs1;

    private int is15;

    void Update()
    {
        Debug.Log(PashalkMusicIs1);
        Debug.Log(PashalkMusic);
        musics = PlayerPrefs.GetFloat("musics", 0.5f);
        ad1.volume = musics;
        ad1_2.volume = musics;
        ad1_3.volume = musics / 4.5f;

        if(!PashalkMusic)
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                ad1.enabled = true;
                ad1_2.enabled = true;

                // Определяем, какое сохранение использовать
                string key = isGameScene ? "musicint_game" : "musicint_menu";
                int next = PlayerPrefs.GetInt(key, 0);

                if (next == 0 && !ad1.isPlaying && !ad1_2.isPlaying)
                {
                    ad1.Play();
                    PlayerPrefs.SetInt(key, 1);
                }
                else if (next == 1 && !ad1.isPlaying && !ad1_2.isPlaying)
                {
                    ad1_2.Play();
                    PlayerPrefs.SetInt(key, 0);
                }
            }
            else
            {
                ad1.enabled = false;
                ad1_2.enabled = false;
                ad1_3.enabled = false;
            }
        }
        else if(!ad1_3.isPlaying)
        {
            ad1.enabled = false;
            ad1_2.enabled = false;
            ad1_3.enabled = true;
            ad1_3.Play();
            PashalkMusicIs1 = true;
        }

        if (PlayerPrefs.GetInt("music") == 1)
        {
            ad1_3.enabled = false;
        }
    }

    public void NextMusicManual()
    {
        is15++;

        if(is15 < 15)
        {
            if (PlayerPrefs.GetInt("music") == 1) return;

            string key = isGameScene ? "musicint_game" : "musicint_menu";
            int next = PlayerPrefs.GetInt(key, 0);

            ad1.Stop();
            ad1_2.Stop();

            if (next == 0)
            {
                ad1.Play();
                PlayerPrefs.SetInt(key, 1);
            }
            else
            {
                ad1_2.Play();
                PlayerPrefs.SetInt(key, 0);
            }
        }
        else
            PashalkMusic = true;
    }
}
