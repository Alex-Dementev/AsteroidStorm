using UnityEngine;

public class GetPets : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;

    private int Pets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.GetString("BackPet1", "") == "P1")
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet1", "") == "P2")
        {
            Instantiate(prefab2, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet1", "") == "P3")
        {
            Instantiate(prefab3, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet1", "") == "P4")
        {
            Instantiate(prefab4, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet1", "") == "P5")
        {
            Instantiate(prefab5, Vector3.zero, Quaternion.identity);
        }

        if(PlayerPrefs.GetString("BackPet2", "") == "P1")
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet2", "") == "P2")
        {
            Instantiate(prefab2, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet2", "") == "P3")
        {
            Instantiate(prefab3, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet2", "") == "P4")
        {
            Instantiate(prefab4, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet2", "") == "P5")
        {
            Instantiate(prefab5, Vector3.zero, Quaternion.identity);
        }

        if(PlayerPrefs.GetString("BackPet3", "") == "P1")
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet3", "") == "P2")
        {
            Instantiate(prefab2, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet3", "") == "P3")
        {
            Instantiate(prefab3, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet3", "") == "P4")
        {
            Instantiate(prefab4, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet3", "") == "P5")
        {
            Instantiate(prefab5, Vector3.zero, Quaternion.identity);
        }

        if(PlayerPrefs.GetString("BackPet4", "") == "P1")
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet4", "") == "P2")
        {
            Instantiate(prefab2, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet4", "") == "P3")
        {
            Instantiate(prefab3, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet4", "") == "P4")
        {
            Instantiate(prefab4, Vector3.zero, Quaternion.identity);
        }
        if(PlayerPrefs.GetString("BackPet4", "") == "P5")
        {
            Instantiate(prefab5, Vector3.zero, Quaternion.identity);
        }
    }
}
