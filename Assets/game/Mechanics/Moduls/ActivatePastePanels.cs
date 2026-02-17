using UnityEngine;

public class ActivatePastePanels : MonoBehaviour
{
    public Animator E;
    public Animator F;
    public Animator G;
    public Animator GyperJump;
    public Animator Scanner;
    public Animator Shield;
    public Animator Projectile;
    public GameObject GOE;
    public GameObject GOF;
    public GameObject GOG;
    public GameObject GOGyperJump;
    public GameObject GOScanner;
    public GameObject GOShield;
    public GameObject GOProjectile;

    public void OpenG()
    {
        GOG.SetActive(true);
        G.CrossFade("Activate", 0.1f);
        F.CrossFade("DisActivate", 0.1f);
        E.CrossFade("DisActivate", 0.1f);
        GyperJump.CrossFade("DisActivate", 0.1f);
        Scanner.CrossFade("DisActivate", 0.1f);
        Shield.CrossFade("DisActivate", 0.1f);
        Projectile.CrossFade("DisActivate", 0.1f);
    }
    public void OpenF()
    {
        GOF.SetActive(true);
        G.CrossFade("DisActivate", 0.1f);
        F.CrossFade("Activate", 0.1f);
        E.CrossFade("DisActivate", 0.1f);
        GyperJump.CrossFade("DisActivate", 0.1f);
        Scanner.CrossFade("DisActivate", 0.1f);
        Shield.CrossFade("DisActivate", 0.1f);
        Projectile.CrossFade("DisActivate", 0.1f);
    }
    public void OpenE()
    {
        GOE.SetActive(true);
        G.CrossFade("DisActivate", 0.1f);
        F.CrossFade("DisActivate", 0.1f);
        E.CrossFade("Activate", 0.1f);
        GyperJump.CrossFade("DisActivate", 0.1f);
        Scanner.CrossFade("DisActivate", 0.1f);
        Shield.CrossFade("DisActivate", 0.1f);
        Projectile.CrossFade("DisActivate", 0.1f);
    }
    public void OpenGyperJump()
    {
        GOGyperJump.SetActive(true);
        G.CrossFade("DisActivate", 0.1f);
        F.CrossFade("DisActivate", 0.1f);
        E.CrossFade("DisActivate", 0.1f);
        GyperJump.CrossFade("Activate", 0.1f);
        Scanner.CrossFade("DisActivate", 0.1f);
        Shield.CrossFade("DisActivate", 0.1f);
        Projectile.CrossFade("DisActivate", 0.1f);
    }
    public void OpenScanner()
    {
        GOScanner.SetActive(true);
        G.CrossFade("DisActivate", 0.1f);
        F.CrossFade("DisActivate", 0.1f);
        E.CrossFade("DisActivate", 0.1f);
        GyperJump.CrossFade("DisActivate", 0.1f);
        Scanner.CrossFade("Activate", 0.1f);
        Shield.CrossFade("DisActivate", 0.1f);
        Projectile.CrossFade("DisActivate", 0.1f);
    }
    public void OpenShield()
    {
        GOShield.SetActive(true);
        G.CrossFade("DisActivate", 0.1f);
        F.CrossFade("DisActivate", 0.1f);
        E.CrossFade("DisActivate", 0.1f);
        GyperJump.CrossFade("DisActivate", 0.1f);
        Scanner.CrossFade("DisActivate", 0.1f);
        Shield.CrossFade("Activate", 0.1f);
        Projectile.CrossFade("DisActivate", 0.1f);
    }
    public void OpenProjectile()
    {
        GOProjectile.SetActive(true);
        G.CrossFade("DisActivate", 0.1f);
        F.CrossFade("DisActivate", 0.1f);
        E.CrossFade("DisActivate", 0.1f);
        GyperJump.CrossFade("DisActivate", 0.1f);
        Scanner.CrossFade("DisActivate", 0.1f);
        Shield.CrossFade("DisActivate", 0.1f);
        Projectile.CrossFade("Activate", 0.1f);
    }


    public float minSwipeDistance = 80f;
    private Vector2 startPos;
    private bool isSwiping = false;

    void Update()
    {
        // Начало касания или клик мышью
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isSwiping = true;
        }

        // Отпускание пальца/мыши
        if (Input.GetMouseButtonUp(0) && isSwiping)
        {
            Vector2 endPos = Input.mousePosition;
            float deltaX = endPos.x - startPos.x;

            if (Mathf.Abs(deltaX) >= minSwipeDistance)
            {
                if (deltaX < 0)
                {
                    // свайп влево
                    ClosePanel();
                }
            }

            isSwiping = false; // сбрасываем флаг
        }
    }

    void ClosePanel()
    {
        G.CrossFade("DisActivate", 0.1f);
        F.CrossFade("DisActivate", 0.1f);
        E.CrossFade("DisActivate", 0.1f);
        GyperJump.CrossFade("DisActivate", 0.1f);
        Scanner.CrossFade("DisActivate", 0.1f);
        Shield.CrossFade("DisActivate", 0.1f);
        Projectile.CrossFade("DisActivate", 0.1f);
    }
}
