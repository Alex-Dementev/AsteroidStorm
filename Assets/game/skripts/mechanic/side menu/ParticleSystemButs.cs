using UnityEngine;

public class ParticleSystemButs : MonoBehaviour
{
    public ParticleSystem ps;
    
    void Start()
    {
        ps.Stop();
    }
    public void StartPs()
    {
        ps.Play();
    }
    public void StopPs()
    {
        ps.Stop();
    }
}
