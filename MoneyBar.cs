using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private TMP_Text bar; /// <summary> Текст для демонстрации числа очков </summary>
    [SerializeField] private Ball ball; /// <summary> Шар </summary>
    private int money; /// <summary> Очки игрока </summary>

    private void OnEnable()
    {
        bar.text = money.ToString();
         ball.Rewarding += AddMoney;
    }

    private void OnDisable()
    {
        ball.Rewarding -= AddMoney;
    }

    public void AddMoney(int reward) //Начисление очков
    {
        money += reward;
        bar.text = money.ToString();
    }
}
