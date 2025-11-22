using UnityEngine;

public class UpdateModuls : MonoBehaviour
{
    // ===== КОЛОНКА 1 =====
    public GameObject[] common1, rare1, epic1, legendary1, ultra1;
    // ===== КОЛОНКА 2 =====
    public GameObject[] common2, rare2, epic2, legendary2, ultra2;
    // ===== КОЛОНКА 3 =====
    public GameObject[] common3, rare3, epic3, legendary3, ultra3;

    void Start()
    {
        // Отключаем все при старте — ничего не показываем
        DisableAll(common1, rare1, epic1, legendary1, ultra1);
        DisableAll(common2, rare2, epic2, legendary2, ultra2);
        DisableAll(common3, rare3, epic3, legendary3, ultra3);
    }

    // Метод для обновления магазина (рандомно)
    public void ForceRefresh()
    {
        UpdateAllColumns();
        PlayerPrefs.SetInt("shop_need_refresh", 0);
        PlayerPrefs.Save();
    }

    public void UpdateAllColumns()
    {
        RefreshColumn(1, common1, rare1, epic1, legendary1, ultra1);
        RefreshColumn(2, common2, rare2, epic2, legendary2, ultra2);
        RefreshColumn(3, common3, rare3, epic3, legendary3, ultra3);
    }

    void RefreshColumn(int id, GameObject[] common, GameObject[] rare, GameObject[] epic, GameObject[] legendary, GameObject[] ultra)
    {
        DisableAll(common, rare, epic, legendary, ultra);

        int roll = Random.Range(0, 100);
        int rarity = 0;
        GameObject[] array;

        if (roll < 25) { rarity = 0; array = common; }
        else if (roll < 60) { rarity = 1; array = rare; }
        else if (roll < 85) { rarity = 2; array = epic; }
        else if (roll < 97) { rarity = 3; array = legendary; }
        else { rarity = 4; array = ultra; }

        int index = 0;
        if (array.Length > 0)
        {
            index = Random.Range(0, array.Length);
            array[index].SetActive(true);
        }

        PlayerPrefs.SetInt($"shop_col{id}_rarity", rarity);
        PlayerPrefs.SetInt($"shop_col{id}_index", index);
        PlayerPrefs.Save();
    }

    void DisableAll(params GameObject[][] all)
    {
        foreach (var arr in all)
            foreach (var obj in arr)
                if (obj != null)
                    obj.SetActive(false);
    }
}
