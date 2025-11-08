using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource ad1;     // Первая музыка
    public AudioSource ad1_2;   // Вторая музыка
    public float musics;

    void Update()
    {
        musics = PlayerPrefs.GetFloat("musics", 0.5f);
        ad1.volume = musics;
        ad1_2.volume = musics;

        if (PlayerPrefs.GetInt("music") == 0)
        {
            ad1.enabled = true;
            ad1_2.enabled = true;

            int next = PlayerPrefs.GetInt("musicint", 0);

            if (next == 0 && !ad1.isPlaying && !ad1_2.isPlaying)
            {
                ad1.Play();
                PlayerPrefs.SetInt("musicint", 1);
            }
            else if (next == 1 && !ad1.isPlaying && !ad1_2.isPlaying)
            {
                ad1_2.Play();
                PlayerPrefs.SetInt("musicint", 0);
            }
        }
        else
        {
            ad1.enabled = false;
            ad1_2.enabled = false;
        }
    }

    public void NextMusicManual()
    {
        if (PlayerPrefs.GetInt("music") == 1) return;

        int next = PlayerPrefs.GetInt("musicint", 0);

        ad1.Stop();
        ad1_2.Stop();

        if (next == 0)
        {
            ad1.Play();
            PlayerPrefs.SetInt("musicint", 1);
        }
        else
        {
            ad1_2.Play();
            PlayerPrefs.SetInt("musicint", 0);
        }
    }
}
