using UnityEngine;

public class ProjectilePref : MonoBehaviour
{
    public float speed;
    private float ToBoom = 5.5f;
    private bool BoomActive;
    public SimpleBlast ptb;
    public GameObject prefabToSpawn;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        ToBoom -= Time.deltaTime;

        if(ToBoom <= 0 && !BoomActive)
        {
            BoomActive = true;
            Boom();
        }
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(Collision.gameObject);
            Boom();
        }
    }

    public void Boom()
    {
        Instantiate(prefabToSpawn, transform.position, prefabToSpawn.transform.rotation);
        ptb.StartBlast();
    }
}