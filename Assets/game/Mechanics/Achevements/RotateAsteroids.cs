using UnityEngine;

public class SimpleOrbitSelf : MonoBehaviour
{
    public string centerTag = "OrbitCenter";

    public float minSpeed = 10f;
    public float maxSpeed = 40f;

    private Transform center;
    private float speed;
    private float direction;

    void Start()
    {
        center = GameObject.FindGameObjectWithTag(centerTag)?.transform;
        if (center == null)
        {
            Debug.LogError("Orbit center not found");
            enabled = false;
            return;
        }

        speed = Random.Range(minSpeed, maxSpeed);
        direction = Random.value > 0.5f ? 1f : -1f;
    }

    void Update()
    {
        transform.RotateAround(
            center.position,
            Vector3.up,
            speed * direction * Time.deltaTime
        );
    }
}
