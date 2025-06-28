using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour
{
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    public float isdelay = 2;

    public Animator anim;

    private int currentSkin = 0;




    void Update()
    {
        isdelay -= Time.deltaTime;
    }

    void Start()
    {
        anim.Play("anim 17");

        currentSkin = PlayerPrefs.GetInt("CurrentSkin", -1);

        if (currentSkin == -1)
        {
            currentSkin = 3; // По умолчанию - Skin4
            PlayerPrefs.SetInt("CurrentSkin", currentSkin);
            PlayerPrefs.Save();
        }

        ShowSkin(currentSkin);
    }

    public void click()
    {
        if(isdelay <= 0)
        {
        isdelay = 0.6f;
        anim.Play("anim 17 0");

        // Выключаем визуал у всех скинов
        if (s1) SetVisual(s1, false);
        if (s2) SetVisual(s2, false);
        if (s3) SetVisual(s3, false);
        if (s4) SetVisual(s4, false);

        // Перебираем доступные скины
        for (int i = 0; i < 4; i++)
        {
            currentSkin = (currentSkin + 1) % 4;

            if (currentSkin == 0 && PlayerPrefs.GetInt("Skin1", 0) == 1 && s1)
            {
                SetVisual(s1, true);
                PlayerPrefs.SetInt("CurrentSkin", 0);
                PlayerPrefs.Save();
                return;
            }
            else if (currentSkin == 1 && PlayerPrefs.GetInt("Skin2", 0) == 1 && s2)
            {
                SetVisual(s2, true);
                PlayerPrefs.SetInt("CurrentSkin", 1);
                PlayerPrefs.Save();
                return;
            }
            else if (currentSkin == 2 && PlayerPrefs.GetInt("Skin3", 0) == 1 && s3)
            {
                SetVisual(s3, true);
                PlayerPrefs.SetInt("CurrentSkin", 2);
                PlayerPrefs.Save();
                return;
            }
            else if (currentSkin == 3 && s4)
            {
                SetVisual(s4, true);
                PlayerPrefs.SetInt("CurrentSkin", 3);
                PlayerPrefs.Save();
                return;
            }
        }
        }
    }

    private void ShowSkin(int index)
    {
        if (s1) SetVisual(s1, false);
        if (s2) SetVisual(s2, false);
        if (s3) SetVisual(s3, false);
        if (s4) SetVisual(s4, false);

        if (index == 0 && PlayerPrefs.GetInt("Skin1", 0) == 1 && s1)
            SetVisual(s1, true);
        else if (index == 1 && PlayerPrefs.GetInt("Skin2", 0) == 1 && s2)
            SetVisual(s2, true);
        else if (index == 2 && PlayerPrefs.GetInt("Skin3", 0) == 1 && s3)
            SetVisual(s3, true);
        else if (index == 3 && s4)
            SetVisual(s4, true);
    }

    // ВКЛ/ВЫКЛ визуала (спрайты, меши, частицы и т.д.)
    private void SetVisual(GameObject obj, bool isVisible)
    {
        // Все визуальные компоненты (2D, 3D, Line, Trail и т.п.)
        foreach (var renderer in obj.GetComponentsInChildren<Renderer>(true))
            renderer.enabled = isVisible;

        // Частицы
        foreach (var ps in obj.GetComponentsInChildren<ParticleSystem>(true))
        {
            if (isVisible)
                ps.Play();
            else
                ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}
