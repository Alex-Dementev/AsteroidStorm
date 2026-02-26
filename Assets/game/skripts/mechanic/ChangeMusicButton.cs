using UnityEngine;

public class ChangeMusicButton : MonoBehaviour
{
    public MusicManager mm;
    public void OnClickChangeMusic()
    {
        mm.NextMusicManual();
    }
}
