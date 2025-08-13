using UnityEngine;

public class ParticleLoader : MonoBehaviour
{
    public ParticleSystem[] particles; // сюда в инспекторе закидываешь все партиклы, которые должны подхватить цвет и скорость

    void Start()
    {
        // Загружаем сохранённые параметры
        float iR = PlayerPrefs.GetFloat("Red", 0.85f);
        float iG = PlayerPrefs.GetFloat("Green", 0f);
        float iB = PlayerPrefs.GetFloat("Blue", 0f);
        float iSpeed = PlayerPrefs.GetFloat("PartSpeed", 5f);

        // Применяем цвет
        Color c = new Color(iR, iG, iB);
        foreach (var ps in particles)
        {
            if (ps != null)
            {
                ps.GetComponent<ParticleSystemRenderer>().material.SetColor("_Color", c);

                // Если имя НЕ начинается с "s" или "S", меняем скорость
                if (!ps.name.StartsWith("s") && !ps.name.StartsWith("S"))
                {
                    var main = ps.main;
                    main.startSpeed = iSpeed;
                }
            }
        }
    }
}
