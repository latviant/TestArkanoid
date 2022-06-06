using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private int health; /// <summary> ����� ������ ����� </summary>
    [SerializeField] private List<Color> colors;/// <summary> ������ ������������ ������</summary>
    private SpriteRenderer spriteRenderer; /// <summary> SpriteRenderer ����������� ����� </summary>
    private int numberBlock = 1; /// <summary> ��������� ��� �������� ���������� � ����� ��������� ������ </summary>

    public event UnityAction<int> Diying; /// <summary> �������, ���������� � ���������� �������� ����������� </summary>

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = colors[colors.Count - 1];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball)) //��� ������������ � ����� ����������� ���������� ������
        {
            health--;

            if (health <= 0) //���� ����� ������ ������ ��� ����� ����, ���� ��������������
            {
                Die();
            }
            else //� ������ ������ � ���� ���������� ����
            {
                ChangeColor(health);
            }
        }
    }

    protected void ChangeColor(int health) //��������� ����� � ���������� �������� ��������
    {
        spriteRenderer.color = colors[health - 1];
    }

    protected virtual void Die()  //�������� �����������
    {
        gameObject.SetActive(false);
        Diying?.Invoke(numberBlock);
    }
}