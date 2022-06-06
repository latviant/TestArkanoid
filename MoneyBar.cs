using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private TMP_Text bar; /// <summary> ����� ��� ������������ ����� ����� </summary>
    [SerializeField] private Ball ball; /// <summary> ��� </summary>
    private int money; /// <summary> ���� ������ </summary>

    private void OnEnable()
    {
        bar.text = money.ToString();
         ball.Rewarding += AddMoney;
    }

    private void OnDisable()
    {
        ball.Rewarding -= AddMoney;
    }

    public void AddMoney(int reward) //���������� �����
    {
        money += reward;
        bar.text = money.ToString();
    }
}
