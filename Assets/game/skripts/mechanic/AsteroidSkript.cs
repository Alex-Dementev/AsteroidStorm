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

        // итоговая масса с разбросом ±0.2 и округлением до сотых
        float rawMass = baseMass + Random.Range(-0.2f, 0.2f);
        mass = Mathf.Round(rawMass * 100f) / 100f;
    }

    public void asvoid()
    {
        float totalMass = PlayerPrefs.GetFloat("totalMass", 0f);
        totalMass += mass;
        PlayerPrefs.SetFloat("totalMass", totalMass);

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
