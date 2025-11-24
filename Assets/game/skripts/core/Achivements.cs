using UnityEngine;

public class Achivements : MonoBehaviour
{
    public Animator Camera;
    public Animator Canvass;

    public void Open()
    {
        Camera.Play("Camera");
        Canvass.Play("AchAnim");
    }
    public void Close()
    {
        Camera.Play("Camera 0");
        Canvass.Play("AchAnim 0");
    }
}
