using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public AudioSource ad;
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
        ad.volume = musics;


        if (PlayerPrefs.GetInt("music") == 0)
        {
            ad.enabled = true;
        }
    
        if (PlayerPrefs.GetInt("music") == 1)
        {
            ad.enabled = false;
        }
    }
}