using System.Collections;
using UnityEngine;

public class Distortion : MonoBehaviour
{
    [Header("Материал, у которого будем менять параметр")]
    public Material mat;

    [Header("Имя параметра в шейдере (например _animAlpha)")]
    public string propertyName = "_animAlpha";

    [Header("Настройки анимации")]
    public float durationUp = 0.5f;   // за сколько поднимается с 0 до 0.5
    public float durationDown = 0.5f; // за сколько опускается обратно
    public float minValue = 0f;
    public float peakValue = 0.5f;

    private Coroutine animCoroutine;

    public void PlayAlphaPulse()
    {
        if (animCoroutine != null) StopCoroutine(animCoroutine);
        animCoroutine = StartCoroutine(AnimateAlpha());
    }

    private IEnumerator AnimateAlpha()
    {
        // --- Плавный рост (0 -> 0.5) ---
        float elapsed = 0f;
        while (elapsed < durationUp)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / durationUp);
            float val = Mathf.Lerp(minValue, peakValue, t);
            mat.SetFloat(propertyName, val);
            yield return null;
        }

        // --- Плавное угасание (0.5 -> 0) ---
        elapsed = 0f;
        while (elapsed < durationDown)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / durationDown);
            float val = Mathf.Lerp(peakValue, minValue, t);
            mat.SetFloat(propertyName, val);
            yield return null;
        }

        mat.SetFloat(propertyName, minValue);
    }
}
