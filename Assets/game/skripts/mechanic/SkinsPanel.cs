using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsPanel : MonoBehaviour
{
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;

    public Slider R;
    public Slider G;
    public Slider B;
    public Slider Speed; // новый слайдер скорости

    public Image outImage;
    public float iR;
    public float iG;
    public float iB;
    public float iSpeed; // значение скорости

    void Start()
    {
        iR = PlayerPrefs.GetFloat("Red", 0.85f);
        iG = PlayerPrefs.GetFloat("Green", 0);
        iB = PlayerPrefs.GetFloat("Blue", 0);
        iSpeed = PlayerPrefs.GetFloat("PartSpeed", 5f); // дефолтная скорость

        R.value = iR;
        G.value = iG;
        B.value = iB;
        Speed.value = iSpeed;
    }

    void Update()
    {
        // Цвет
        iR = R.value;
        iG = G.value;
        iB = B.value;
        PlayerPrefs.SetFloat("Red", iR);
        PlayerPrefs.SetFloat("Green", iG);
        PlayerPrefs.SetFloat("Blue", iB);
        outImage.color = new Color(iR, iG, iB);

        var c = new Color(iR, iG, iB);
        ps1.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", c);
        ps2.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", c);
        ps3.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", c);
        ps4.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", c);

        // Скорость
        iSpeed = Speed.value;
        PlayerPrefs.SetFloat("PartSpeed", iSpeed);

        SetParticleSpeed(ps1, iSpeed);
        SetParticleSpeed(ps2, iSpeed);
        SetParticleSpeed(ps3, iSpeed);
        SetParticleSpeed(ps4, iSpeed);
    }

    void SetParticleSpeed(ParticleSystem ps, float speed)
    {
        var main = ps.main;
        main.startSpeed = speed;
    }

    // Быстрый выбор цвета
    public void speedRed()   { R.value = 1; G.value = 0; B.value = 0; }
    public void speedBlue()  { R.value = 0; G.value = 0; B.value = 1; }
    public void speedYellow(){ R.value = 1; G.value = 1; B.value = 0; }
    public void speedPink()  { R.value = 1; G.value = 0; B.value = 1; }
    public void speedWhite() { R.value = 1; G.value = 1; B.value = 1; }
    public void speedGreen() { R.value = 0; G.value = 1; B.value = 0; }
}
