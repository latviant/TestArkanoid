using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefeatPoint : MonoBehaviour
{
    [SerializeField] private GameObject panel; /// <summary> ������, ������� ���������� ��� ������� Loosing </summary>
    [SerializeField] private PlayerPlatform playerPlatform; /// <summary> ��������� ������, ������� ����� ���������� � ��������� </summary>
    public event UnityAction<GameObject> Loosing; /// <summary> �������, ������� ���������� ��� ������� ����� ��������� ���� </summary>

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            playerPlatform.Defeat(); //����� �������� ���������
            Loosing?.Invoke(panel);
        }
    }
}
   

