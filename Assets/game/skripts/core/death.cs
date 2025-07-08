using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RDG;
using UnityEngine.SocialPlatforms.Impl;

public class death : MonoBehaviour
{
    [SerializeField] public GameObject losePanel;
    [SerializeField] public Transform player;
    public int coins;
    public bool b;
    public DoubleTapHandler d;
    private float isdelay = 9999999;
    public Animator anim;
    public Animator anim1;
    public GameObject image;
    public AudioSource ad;
    private float f = 9999999;
    private float isdelay1 = 2;
    private float isdelay2 = 9999999;
    public ParticleSystem ps;
    public int score;
    public int allcoins;

    public GameObject explosionEffect;
    public AudioSource explosionSound1;
    public AudioSource explosionSound2;

    void Start()
    {
        b = false;
        isdelay = 9999999;
    }

    void Update()
    {
        isdelay -= Time.deltaTime;
        f -= Time.deltaTime;
        isdelay1 -= Time.deltaTime;
        isdelay2 -= Time.deltaTime;

        if (isdelay <= 0)
        {
            isdelay = 99999999;
            SceneManager.LoadScene("main");
        }

        if (b == true)
        {
            if (f <= 0)
            {
                restart();
                f = 9999999;
            }
        }

        if (isdelay1 >= 0)
        {
            ps.Stop();
        }

        if (isdelay2 <= 0)
        {
            isdelay1 = 1;
        }
    }

    public void restart()
    {
        image.SetActive(!image.activeSelf);
        anim.Play("anim10 0");
        isdelay = 1.2f;
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.CompareTag("obstacle"))
        {
            if (d.b == true)
            {
                Debug.Log("fly");
                if (explosionEffect != null)
                {
                    Instantiate(explosionEffect, Collision.transform.position, Quaternion.identity);
                }

                int rand = Random.Range(0, 2);
                if (rand == 0 && explosionSound1 != null) explosionSound1.Play();
                else if (rand == 1 && explosionSound2 != null) explosionSound2.Play();

                Destroy(Collision.gameObject);
            }
            else if (b == false)
            {
                losePanel.SetActive(true);
                anim1.Play("anim11");

                coins = PlayerPrefs.GetInt("coins");
                allcoins = PlayerPrefs.GetInt("allcoins");
                score = PlayerPrefs.GetInt("allscore");
                coins += ((int)(player.position.z / 10));
                score += ((int)(player.position.z / 3));
                allcoins += ((int)(player.position.z / 10));
                PlayerPrefs.SetInt("coins", coins);
                PlayerPrefs.SetInt("allcoins", allcoins);
                PlayerPrefs.SetInt("allscore", score);

                if (PlayerPrefs.GetInt("vibration") == 0)
                {
                    Vibration.Vibrate(80, 100);
                }

                ad.Play();
                b = true;
                f = 7;
                ps.Play();
                isdelay2 = 2;
            }
        }
    }
}
