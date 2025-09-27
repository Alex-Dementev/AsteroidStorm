using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // обязательно для Text и Slider

public class lombardScript : MonoBehaviour
{
    [Header("Всего тон")]
    public Text ton1;
    public Text ton2;
    public Text ton3;
    public Text ton4;

    [Header("Цена продажи игроку")]
    public Text tonsell1;
    public Text tonsell2;
    public Text tonsell3;
    public Text tonsell4;

    [Header("Процент ломбарда")]
    public Text percent1;
    public Text percent2;
    public Text percent3;
    public Text percent4;

    [Header("Слайдеры цен")]
    public Slider SliderSell1;
    public Slider SliderSell2;
    public Slider SliderSell3;
    public Slider SliderSell4;

    [Header("Общие цены")]
    public Text allcoins1;
    public Text allcoins2;
    public Text allcoins3;
    public Text allcoins4;

    void Start()
    {
        
    }

    void Update()
    {
        // Пока пусто, потом можно обновлять динамически
    }
}
