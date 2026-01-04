using UnityEngine;

public class AsteroidSkript : MonoBehaviour
{
    [Range(0f, 100f)]
    private float firstChance = 40f;

    public Material bronzeMaterial;
    public Material silverMaterial;
    public Material goldMaterial;
    public Material diamondMaterial;
    public Material defaultMaterial;

    public float baseMass = 1f;

    public int Metals;

    public Renderer mainRenderer;
    public Renderer secondRenderer;

    public bool happened = false;
    public int asteroidType = 0;
    public float mass;

    void Start()
    {
        asteroidType = 0;

        mainRenderer.material = defaultMaterial;
        if (secondRenderer != null)
            secondRenderer.material = defaultMaterial;

        float roll1 = Random.Range(0f, 100f);
        if (roll1 < firstChance)
        {
            happened = true;
            float roll2 = Random.Range(0f, 100f);

            if (roll2 < 1f)
            {
                asteroidType = 4;
                ApplyMaterial(diamondMaterial);
            }
            else if (roll2 < 8f)
            {
                asteroidType = 3;
                ApplyMaterial(goldMaterial);
            }
            else if (roll2 < 30f)
            {
                asteroidType = 2;
                ApplyMaterial(silverMaterial);
            }
            else
            {
                asteroidType = 1;
                ApplyMaterial(bronzeMaterial);
            }
        }

        float rawMass = baseMass - ((baseMass - (Random.Range(-0.5f, 0.5f) * baseMass)) * 0.5f);
        mass = Mathf.Round(rawMass * 100f) / 100f;
    }

    void ApplyMaterial(Material mat)
    {
        mainRenderer.material = mat;
        if (secondRenderer != null)
            secondRenderer.material = mat;
    }

    public void asvoid()
    {
        if (PlayerPrefs.GetInt("Boost3", 0) >= 1)
            mass *= 1.5f;

        float totalMass = PlayerPrefs.GetFloat("totalMass", 0f);
        totalMass += mass;
        PlayerPrefs.SetFloat("totalMass", totalMass);

        Metals = PlayerPrefs.GetInt("PermanentTaskMetalls", 0);
        Metals++;
        PlayerPrefs.SetInt("PermanentTaskMetalls", Metals);

        if (mass <= 0.6f)
            PlayerPrefs.SetInt("TruekMetalls", 1);

        string key = "";
        switch (asteroidType)
        {
            case 1: key = "bronzeMass"; break;
            case 2: key = "silverMass"; break;
            case 3: key = "goldMass"; break;
            case 4: key = "diamondMass"; break;
        }

        if (!string.IsNullOrEmpty(key))
        {
            float currentMass = PlayerPrefs.GetFloat(key, 0f);
            currentMass += mass;
            PlayerPrefs.SetFloat(key, currentMass);
        }

        PlayerPrefs.Save();
    }
}
