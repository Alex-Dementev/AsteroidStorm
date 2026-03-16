using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Vector3 randomRotationSpeed;
    private Vector3 startPos;
    private Vector3 moveOffset;
    private float moveSpeed;

    void Start()
    {
        // Сохраняем стартовую позицию
        startPos = transform.position;

        // Рандомная скорость вращения (очень плавная)
        randomRotationSpeed = new Vector3(
            Random.Range(-15f, 15f),
            Random.Range(-15f, 15f),
            Random.Range(-15f, 15f)
        );

        // Случайное направление и скорость лёгкого дрейфа
        moveOffset = new Vector3(
            Random.Range(-0.2f, 0.2f),
            Random.Range(-0.2f, 0.2f),
            Random.Range(-0.2f, 0.2f)
        );

        moveSpeed = Random.Range(0.3f, 1.2f); // скорость плавного колебания
    }

    void Update()
    {
        // Вращаем астероид
        transform.Rotate(randomRotationSpeed * Time.deltaTime);

        // Лёгкое "дыхание" — движение туда-сюда
        transform.position = startPos + moveOffset * Mathf.Sin(Time.time * moveSpeed);
    }
}
