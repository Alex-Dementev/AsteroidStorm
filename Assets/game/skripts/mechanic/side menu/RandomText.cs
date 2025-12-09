using UnityEngine;
using UnityEngine.UI;

public class RandomWorldName : MonoBehaviour
{
    public Text output;

    // === 1% редкая фраза ===
    private string rarePhrase = "Тоскующий физик";

    // ===== Тематические группы =====
    private string[][] adjectivesGroups =
    {
        new string[]{ "ржавый", "осколочный", "древний", "пустотный", "туманный" },
        new string[]{ "забытые", "разрушенные", "холодные", "обугленные", "мертвые" },
        new string[]{ "космический", "магнитный", "гравитационный", "орбитальный", "пылевой" },
        new string[]{ "призрачные", "сияющие", "пепельные", "тоскливые", "шепчущие" }
    };

    private string[][] nounsGroups =
    {
        new string[]{ "разлом", "шторм", "предел", "сектор", "полет" },
        new string[]{ "руины", "пустоши", "коридоры", "каньоны", "обрывы" },
        new string[]{ "пояс", "спутник", "массив", "узел", "купол" },
        new string[]{ "обелиск", "туман", "переход", "мегалит", "круг" }
    };

    void Start()
    {
        if (output == null) return;

        // === 1% шанс на редкое название ===
        if (Random.Range(0, 100) == 0)
        {
            output.text = rarePhrase;
            output.color = Color.red;  // только тут меняем цвет
            return;
        }

        // === Выбор совместимой группы ===
        int group = Random.Range(0, adjectivesGroups.Length);

        string adj = adjectivesGroups[group][Random.Range(0, adjectivesGroups[group].Length)];
        string noun = nounsGroups[group][Random.Range(0, nounsGroups[group].Length)];

        // Первая буква — заглавная
        adj = char.ToUpper(adj[0]) + adj.Substring(1);

        // Устанавливаем текст, но НЕ трогаем цвет
        output.text = adj + " " + noun;
    }
}
