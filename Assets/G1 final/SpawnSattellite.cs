using UnityEngine;
using System.Collections;

public class SpawnSattellite : MonoBehaviour
{
    public GameObject S1;
    public GameObject S2;
    private int Ilya;

    private bool canSpawnS1 = false;
    private bool canSpawnS2 = false;

    void Start()
    {
        Ilya = Random.Range(0, 10);
        Debug.Log(Ilya);

        if (Ilya == 1)
            canSpawnS1 = true;

        if (Ilya == 2)
            canSpawnS2 = true;
    }

    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        bool playerNearby = IsPlayerNearbyZ(players);

        if (canSpawnS1 && playerNearby)
            S1.SetActive(true);
        else
            S1.SetActive(false);

        if (canSpawnS2 && playerNearby)
            S2.SetActive(true);
        else
            S2.SetActive(false);
    }

    bool IsPlayerNearbyZ(GameObject[] players)
    {
        foreach (GameObject player in players)
        {
            float zDist = Mathf.Abs(player.transform.position.z - transform.position.z);
            Debug.Log(Ilya + ", " + zDist);

            if (zDist <= 350f)
            {
                if(PlayerPrefs.GetInt("Ach2Level", 0) == 2)
                {
                    PlayerPrefs.SetInt("SattelliteFall", 1);
                    StartCoroutine(SpawnDelay());
                }

                return true;
            }
        }

        return false;
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(8f);

        PlayerPrefs.SetInt("SattelliteFall", 0);
    }
}
