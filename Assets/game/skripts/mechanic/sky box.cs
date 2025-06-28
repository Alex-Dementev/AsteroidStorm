
using UnityEngine;

public class SmoothSkyboxSwitcher : MonoBehaviour
{
    public Material daySkybox;    // Материал дневного скайбокса
    public Material nightSkybox;  // Материал ночного скайбокса
    public float transitionDuration = 3f; // Длительность перехода в секундах

    private Material blendedSkybox; // Промежуточный материал для плавного перехода
    private bool isTransitioning = false; // Флаг, чтобы избежать одновременных переходов
    private float currentBlend = 0f; // Текущее состояние смешивания

    private void Start()
    {
        // Создаём промежуточный материал
        blendedSkybox = new Material(daySkybox.shader);
        blendedSkybox.CopyPropertiesFromMaterial(daySkybox);
        RenderSettings.skybox = blendedSkybox;
    }

    // Метод для переключения на ночной скайбокс
    public void SwitchToNight()
    {
        if (!isTransitioning)
            StartCoroutine(TransitionSkybox(1f)); // Интерполяция к ночи
    }

    private System.Collections.IEnumerator TransitionSkybox(float targetBlend)
    {
        isTransitioning = true;
        float startBlend = currentBlend; // Сохраняем начальное состояние
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;

            // Используем сглаживание через S-образную кривую
            currentBlend = Mathf.Lerp(startBlend, targetBlend, Mathf.SmoothStep(0f, 1f, t));

            // Постепенно смешиваем скайбоксы
            blendedSkybox.Lerp(daySkybox, nightSkybox, currentBlend);

            // Обновляем глобальное освещение
            DynamicGI.UpdateEnvironment();

            yield return null; // Ждём следующий кадр
        }

        // Устанавливаем финальный результат
        blendedSkybox.CopyPropertiesFromMaterial(targetBlend == 0f ? daySkybox : nightSkybox);
        currentBlend = targetBlend; // Обновляем текущее состояние
        isTransitioning = false;
    }
}