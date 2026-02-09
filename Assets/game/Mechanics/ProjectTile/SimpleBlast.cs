using System.Collections.Generic;
using UnityEngine;

public class SimpleBlast : MonoBehaviour
{
    private float maxRadius;


    private HashSet<Collider> hitAlready = new HashSet<Collider>();

    public void StartBlast()
    {
        // Проверяем все астероиды в радиусе
        Collider[] hits = Physics.OverlapSphere(transform.position, maxRadius);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("obstacle") && !hitAlready.Contains(hit) || hit.CompareTag("obstraclemini") && !hitAlready.Contains(hit))
            {
                hitAlready.Add(hit);

                AsteroidSkript asteroid = hit.GetComponent<AsteroidSkript>();
                if (asteroid != null)
                {
                    asteroid.asvoid();
                }

                Destroy(hit.gameObject);
            }
        }

        // Удаляем сам объект со скриптом
        Destroy(this.gameObject);
    }

    void Start()
    {
        maxRadius = PlayerPrefs.GetInt("ProjectileRadius", 0);
    }
}