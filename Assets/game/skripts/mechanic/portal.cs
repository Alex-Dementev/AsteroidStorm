using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public ScoreCounter s;
    private float isdelay = 9999999;
    public Animator a;

    private void OnCollisionEnter(Collision Collision)
    {
        if(Collision.gameObject.CompareTag("portal"))
        {
            s.isbportal = true;
            isdelay = 25;
            Debug.Log("ss");
            a.Play("anim16 1");
        }
    }

    void Update()
    {
    isdelay -= Time.deltaTime;
    
        if(isdelay <= 0)
        {
            s.isbportal = false;
            isdelay = 9999999;
            a.Play("anim16 2");
        }
    }
}
