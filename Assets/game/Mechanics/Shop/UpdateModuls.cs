using UnityEngine;
using System.Collections;

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
        // выключаем всё перед загрузкой
        DisableAll(common1, rare1, epic1, legendary1, ultra1);
        DisableAll(common2, rare2, epic2, legendary2, ultra2);
        DisableAll(common3, rare3, epic3, legendary3, ultra3);

        // если есть сохранённые модули – загружаем
        LoadSavedState();
    }

    // ==========================
    //      СОХРАНЁННОЕ СОСТОЯНИЕ
    // ==========================
    public bool LoadSavedState()
    {
        bool loaded = false;

        loaded |= LoadColumn(1, common1, rare1, epic1, legendary1, ultra1);
        loaded |= LoadColumn(2, common2, rare2, epic2, legendary2, ultra2);
        loaded |= LoadColumn(3, common3, rare3, epic3, legendary3, ultra3);

        return loaded;
    }

    bool LoadColumn(int id, GameObject[] common, GameObject[] rare, GameObject[] epic, GameObject[] legendary, GameObject[] ultra)
    {
        int rarity = PlayerPrefs.GetInt($"shop_col{id}_rarity", -1);
        int index  = PlayerPrefs.GetInt($"shop_col{id}_index", -1);

        if (rarity == -1 || index == -1)
        {
            Debug.Log($"[SHOP LOAD] Колонка {id} | Ничего не сохранено");
            return false;
        }

        GameObject[] array;

        switch (rarity)
        {
            case 0: array = common; break;
            case 1: array = rare; break;
            case 2: array = epic; break;
            case 3: array = legendary; break;
            case 4: array = ultra; break;
            default: return false;
        }

        if (index >= 0 && index < array.Length)
        {
            array[index].SetActive(true);

            Debug.Log(
                $"[SHOP LOAD] Колонка {id} | Редкость {rarity} | Индекс {index} | Объект: {array[index].name}"
            );
            return true;
        }

        Debug.LogWarning($"[SHOP LOAD] Колонка {id} | Индекс вне диапазона");
        return false;
    }


    // ==========================
    //   ОБНОВЛЕНИЕ МАГАЗИНА
    // ==========================
    public void ForceRefresh()
    {
        UpdateAllColumns();
        PlayerPrefs.Save();
    }

    public void UpdateAllColumns()
    {
        RefreshColumn(1, common1, rare1, epic1, legendary1, ultra1);
        RefreshColumn(2, common2, rare2, epic2, legendary2, ultra2);
        RefreshColumn(3, common3, rare3, epic3, legendary3, ultra3);

        // ===== ДОБАВЛЕНО ПО ТВОЕЙ ПРОСЬБЕ =====
        PlayerPrefs.SetInt("ResetBuyModuls", 1);
        StartCoroutine(DelayOneSecond());
    }

    void RefreshColumn(int id, GameObject[] common, GameObject[] rare, GameObject[] epic, GameObject[] legendary, GameObject[] ultra)
    {
        DisableAll(common, rare, epic, legendary, ultra);

        int roll = Random.Range(0, 100);
        int rarity;
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
    }

    void DisableAll(params GameObject[][] all)
    {
        foreach (var arr in all)
            foreach (var obj in arr)
                if (obj != null)
                    obj.SetActive(false);
    }

    IEnumerator DelayOneSecond()
    {
        yield return new WaitForSeconds(0.5f);

        PlayerPrefs.SetInt("ResetBuyModuls", 0);
    }
}
