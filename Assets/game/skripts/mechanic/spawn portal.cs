
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Префаб объекта
    public Transform player; // Ссылка на игрока

    public float spawnInterval = 5f; // Интервал спавна
    public float spawnDistance = 6f; // Расстояние перед игроком
    public float spawnHeightOffset = 0f; // Смещение по высоте
    public float destroyTime = 10f; // Время, через которое объект будет уничтожен

    public Vector3 spawnRotation; // Настраиваемый поворот объекта

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), spawnInterval, spawnInterval);
    }

    private void SpawnObject()
    {
        if (objectPrefab == null || player == null) return;

        // Рассчитываем позицию для спавна
        Vector3 spawnPosition = player.position + player.forward * spawnDistance;
        spawnPosition.y += spawnHeightOffset;

        // Преобразуем в Quaternion на основе заданного угла
        Quaternion rotation = Quaternion.Euler(spawnRotation);

        // Создаём объект с указанной позицией и поворотом
        GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, rotation);

        // Уничтожаем объект через заданное время
        Destroy(spawnedObject, destroyTime);
    }
}