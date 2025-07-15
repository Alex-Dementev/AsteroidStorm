using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public AudioSource ad1;     // Первая музыка
    public AudioSource ad1_2;   // Вторая музыка
    public float musics;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Не уничтожать объект при смене сцены
        }
        else
        {
            Destroy(gameObject); // Удалить дубликат
        }
    }

    void Update()
    {
        musics = PlayerPrefs.GetFloat("musics", 0.5f);
        ad1.volume = musics;
        ad1_2.volume = musics;

        if (PlayerPrefs.GetInt("music") == 0)
        {
            ad1.enabled = true;
            ad1_2.enabled = true;

            // Получаем, какой трек сейчас должен быть (0 — ad1, 1 — ad1_2)
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
        else // Отключение музыки
        {
            ad1.enabled = false;
            ad1_2.enabled = false;
        }
    }
}
