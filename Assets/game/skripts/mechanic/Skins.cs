using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    // Названия и описания для каждой ракеты
    public Text s1Name;
    public Text s1Desc;
    public Text s2Name;
    public Text s2Desc;
    public Text s3Name;
    public Text s3Desc;
    public Text s4Name;
    public Text s4Desc;

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
        if (isdelay <= 0)
        {
            isdelay = 0.6f;
            anim.Play("anim 17 0");

            // Отключаем визуал и текст у всех
            HideAll();

            // Перебираем доступные скины
            for (int i = 0; i < 4; i++)
            {
                currentSkin = (currentSkin + 1) % 4;

                if (currentSkin == 0 && PlayerPrefs.GetInt("Skin1", 0) == 1 && s1)
                {
                    ActivateSkin(s1, s1Name, s1Desc, 0);
                    return;
                }
                else if (currentSkin == 1 && PlayerPrefs.GetInt("Skin2", 0) == 1 && s2)
                {
                    ActivateSkin(s2, s2Name, s2Desc, 1);
                    return;
                }
                else if (currentSkin == 2 && PlayerPrefs.GetInt("Skin3", 0) == 1 && s3)
                {
                    ActivateSkin(s3, s3Name, s3Desc, 2);
                    return;
                }
                else if (currentSkin == 3 && s4)
                {
                    ActivateSkin(s4, s4Name, s4Desc, 3);
                    return;
                }
            }
        }
    }

    private void ShowSkin(int index)
    {
        HideAll();

        if (index == 0 && PlayerPrefs.GetInt("Skin1", 0) == 1 && s1)
            ActivateSkin(s1, s1Name, s1Desc, 0);
        else if (index == 1 && PlayerPrefs.GetInt("Skin2", 0) == 1 && s2)
            ActivateSkin(s2, s2Name, s2Desc, 1);
        else if (index == 2 && PlayerPrefs.GetInt("Skin3", 0) == 1 && s3)
            ActivateSkin(s3, s3Name, s3Desc, 2);
        else if (index == 3 && s4)
            ActivateSkin(s4, s4Name, s4Desc, 3);
    }

    private void HideAll()
    {
        // Выключаем визуалы
        if (s1) SetVisual(s1, false);
        if (s2) SetVisual(s2, false);
        if (s3) SetVisual(s3, false);
        if (s4) SetVisual(s4, false);

        // Выключаем все тексты
        if (s1Name) s1Name.gameObject.SetActive(false);
        if (s1Desc) s1Desc.gameObject.SetActive(false);
        if (s2Name) s2Name.gameObject.SetActive(false);
        if (s2Desc) s2Desc.gameObject.SetActive(false);
        if (s3Name) s3Name.gameObject.SetActive(false);
        if (s3Desc) s3Desc.gameObject.SetActive(false);
        if (s4Name) s4Name.gameObject.SetActive(false);
        if (s4Desc) s4Desc.gameObject.SetActive(false);
    }

    private void ActivateSkin(GameObject skinObj, Text nameText, Text descText, int skinIndex)
    {
        SetVisual(skinObj, true);

        if (nameText) nameText.gameObject.SetActive(true);
        if (descText) descText.gameObject.SetActive(true);

        PlayerPrefs.SetInt("CurrentSkin", skinIndex);
        PlayerPrefs.Save();
    }

    private void SetVisual(GameObject obj, bool isVisible)
    {
        foreach (var renderer in obj.GetComponentsInChildren<Renderer>(true))
            renderer.enabled = isVisible;

        foreach (var ps in obj.GetComponentsInChildren<ParticleSystem>(true))
        {
            if (isVisible)
                ps.Play();
            else
                ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}
