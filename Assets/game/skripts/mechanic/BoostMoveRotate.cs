using UnityEngine;

public class BoostMoveRotate : MonoBehaviour
{
    [Header("Движение")]
    public float moveSpeed = 3f; // скорость движения по -Z

    [Header("Вращение")]
    public float rotationSpeed = 60f; // скорость вращения
    private Vector3 randomRotationAxis;

    void Start()
    {
        // Задаем случайную ось вращения (рандомно в любую сторону)
        randomRotationAxis = Random.onUnitSphere;
    }

    void Update()
    {
        // Вращаем объект
        transform.Rotate(randomRotationAxis * rotationSpeed * Time.deltaTime, Space.Self);

        // Двигаем по глобальной оси Z (в сторону камеры / игрока)
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;
    }
}
