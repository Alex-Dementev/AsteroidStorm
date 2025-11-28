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
        G.Play("Activate");
        F.Play("DisActivate");
        E.Play("DisActivate");
        GyperJump.Play("DisActivate");
        Scanner.Play("DisActivate");
        Shield.Play("DisActivate");
        Projectile.Play("DisActivate");
    }
    public void OpenF()
    {
        GOF.SetActive(true);
        G.Play("DisActivate");
        F.Play("Activate");
        E.Play("DisActivate");
        GyperJump.Play("DisActivate");
        Scanner.Play("DisActivate");
        Shield.Play("DisActivate");
        Projectile.Play("DisActivate");
    }
    public void OpenE()
    {
        GOE.SetActive(true);
        G.Play("DisActivate");
        F.Play("DisActivate");
        E.Play("Activate");
        GyperJump.Play("DisActivate");
        Scanner.Play("DisActivate");
        Shield.Play("DisActivate");
        Projectile.Play("DisActivate");
    }
    public void OpenGyperJump()
    {
        GOGyperJump.SetActive(true);
        G.Play("DisActivate");
        F.Play("DisActivate");
        E.Play("DisActivate");
        GyperJump.Play("Activate");
        Scanner.Play("DisActivate");
        Shield.Play("DisActivate");
        Projectile.Play("DisActivate");
    }
    public void OpenScanner()
    {
        GOScanner.SetActive(true);
        G.Play("DisActivate");
        F.Play("DisActivate");
        E.Play("DisActivate");
        GyperJump.Play("DisActivate");
        Scanner.Play("Activate");
        Shield.Play("DisActivate");
        Projectile.Play("DisActivate");
    }
    public void OpenShield()
    {
        GOShield.SetActive(true);
        G.Play("DisActivate");
        F.Play("DisActivate");
        E.Play("DisActivate");
        GyperJump.Play("DisActivate");
        Scanner.Play("DisActivate");
        Shield.Play("Activate");
        Projectile.Play("DisActivate");
    }
    public void OpenProjectile()
    {
        GOProjectile.SetActive(true);
        G.Play("DisActivate");
        F.Play("DisActivate");
        E.Play("DisActivate");
        GyperJump.Play("DisActivate");
        Scanner.Play("DisActivate");
        Shield.Play("DisActivate");
        Projectile.Play("Activate");
    }
}
