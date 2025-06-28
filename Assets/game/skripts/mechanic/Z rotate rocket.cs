using UnityEngine;

public class RotateRocket : MonoBehaviour
{
    public float rotationSpeed = 100f; // Скорость вращения

    void Update()
    {
        // Вращаем объект вокруг оси Z
        rotationSpeed = PlayerPrefs.GetFloat("R Rotate Speed");
        
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}