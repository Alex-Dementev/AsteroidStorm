using UnityEngine;

public class RotateRocketA : MonoBehaviour
{
    public float rotationSpeed = -100f; // Скорость вращения

    void Update()
    {
        // Вращаем объект вокруг оси Z
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        rotationSpeed = PlayerPrefs.GetFloat("R Rotate Speed");
        rotationSpeed = rotationSpeed * -1;
    }
}