using UnityEngine;

public class ChangeMusicButton : MonoBehaviour
{
    public void OnClickChangeMusic()
    {
        MusicManager mm = FindObjectOfType<MusicManager>();
        if (mm != null)
        {
            mm.NextMusicManual();
        }
    }
}
