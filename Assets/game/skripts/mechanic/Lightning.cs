using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;
    public ParticleSystem ps5;
    public ParticleSystem ps6;

    public void psStart1()
    {
        ps1.Play();
    }
    public void psStart2()
    {
        ps2.Play();
    }
    public void psStart3()
    {
        ps3.Play();
    }
    public void psStart4()
    {
        ps4.Play();
    }
    public void psStart5()
    {
        ps5.Play();
    }
    public void psStart6()
    {
        ps6.Play();
    }
}
