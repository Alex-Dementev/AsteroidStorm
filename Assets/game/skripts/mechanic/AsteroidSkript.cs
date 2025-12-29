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

    public Texture normalMap; // твоя нормалка

    public float baseMass = 1f; // масса, задаваемая вручную в инспекторе

    public int Metals;

    private Renderer rend;
    public bool happened = false;
    public int asteroidType = 0; // 0=камень,1=бронза,2=серебро,3=золото,4=алмаз
    public float mass; // итоговая масса (с разбросом)

    void Start()
    {
        rend = GetComponent<Renderer>();

        asteroidType = 0;
        rend.material = defaultMaterial;

        float roll1 = Random.Range(0f, 100f);
        if (roll1 < firstChance)
        {
            happened = true;
            float roll2 = Random.Range(0f, 100f);

            if (roll2 < 1f)
            {
                asteroidType = 4; 
                rend.material = diamondMaterial;
            }
            else if (roll2 < 8f)
            {
                asteroidType = 3; 
                rend.material = goldMaterial;
            }
            else if (roll2 < 30f)
            {
                asteroidType = 2; 
                rend.material = silverMaterial;
            }
            else
            {
                asteroidType = 1; 
                rend.material = bronzeMaterial;
            }
        }

        // **Применяем нормалку сразу после выбора материала**
        if (normalMap != null)
        {
            rend.material.SetTexture("_BumpMap", normalMap);
            rend.material.SetFloat("_BumpScale", 1f);
        }

        float rawMass = baseMass - ((baseMass - (Random.Range(-0.5f, 0.5f) * baseMass)) * 0.5f);
        mass = Mathf.Round(rawMass * 100f) / 100f;
    }

    public void asvoid()
    {
        if(PlayerPrefs.GetInt("Boost3", 0) >= 1)
            mass = mass * 1.5f;
        
        float totalMass = PlayerPrefs.GetFloat("totalMass", 0f);
        totalMass += mass;
        PlayerPrefs.SetFloat("totalMass", totalMass);

        Metals = PlayerPrefs.GetInt("PermanentTaskMetalls", 0);
        Metals++;
        PlayerPrefs.SetInt("PermanentTaskMetalls", Metals);
        
        if(mass <= 0.6)
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
