using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alltime : MonoBehaviour
{
    public float alltimes;
    // Start is called before the first frame update
    void Start()
    {
        alltimes = PlayerPrefs.GetFloat("alltimes", 0);
    }

    // Update is called once per frame
    void Update()
    {
        alltimes += Time.deltaTime;
        PlayerPrefs.SetFloat("alltimes", alltimes);
    }
}
