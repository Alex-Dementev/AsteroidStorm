using UnityEngine;

public class AsteroidSkript : MonoBehaviour
{
    [Range(0f, 100f)]
    private float firstChance = 65f;

    public Material bronzeMaterial;
    public Material silverMaterial;
    public Material goldMaterial;
    public Material diamondMaterial;
    public Material defaultMaterial;

    public float baseMass = 1f;

    public int Metals;

    public Renderer mainRenderer;

    public bool happened = false;
    public int asteroidType = 0;
    public float mass;

    void Start()
    {
        asteroidType = 0;

        mainRenderer.sharedMaterial = defaultMaterial;

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
            else if (roll2 < 11f)
            {
                asteroidType = 3;
                ApplyMaterial(goldMaterial);
            }
            else if (roll2 < 40f)
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

        float rawMass = baseMass - ((baseMass - (Random.Range(-0.4f, 0.5f) * baseMass)) * 0.5f);
        mass = Mathf.Round(rawMass * 100f) / 100f;
    }

    void ApplyMaterial(Material mat)
    {
        mainRenderer.sharedMaterial = mat;
    }

    public void asvoid()
    {
        if (PlayerPrefs.GetInt("Boost3", 0) >= 1)
            mass *= 1.5f;

        if(asteroidType == 4 && mass >= 0.15f)
        {
            mass /= 1.75f;

            if(mass < 0.1f)
                mass = 0.1f;
        }

        if(mass >= 0.9f)
        {
            Metals = PlayerPrefs.GetInt("AllDestroyedAsteroids", 0);
            Metals++;
            PlayerPrefs.SetInt("AllDestroyedAsteroids", Metals);
        }
        else
        {
            Metals = PlayerPrefs.GetInt("AllUpperAsteroids", 0);
            Metals++;
            PlayerPrefs.SetInt("AllUpperAsteroids", Metals);
        }

        float AllMass = PlayerPrefs.GetFloat("AllAsteroidsMass", 0);
        AllMass += mass;
        PlayerPrefs.SetFloat("AllAsteroidsMass", AllMass);

        if(PlayerPrefs.GetInt("Ach5Level", 0) == 1 && PlayerPrefs.GetInt("Ach5Level0", 0) == asteroidType - 1 && PlayerPrefs.GetInt("ach5", 0) == 2)
            PlayerPrefs.SetInt("Ach5Level0", asteroidType);

        Debug.Log("Тип: " + asteroidType + ", масса: " + mass);

        float totalMass = PlayerPrefs.GetFloat("totalMass", 0f);
        totalMass += mass;
        PlayerPrefs.SetFloat("totalMass", totalMass);

        Metals = PlayerPrefs.GetInt("PermanentTaskMetalls", 0);
        Metals++;
        PlayerPrefs.SetInt("PermanentTaskMetalls", Metals);

        if (mass <= 0.9f)
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
