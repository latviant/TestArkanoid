using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Animator))]
public class PlayerPlatform : MonoBehaviour
{
    [SerializeField] private float speed; /// <summary> �������� �������� ��������� </summary>
    [SerializeField] private float minLeft; /// <summary> ����������� ����� �� ��� �, �� ������� ����� ����� ��������� </summary>
    [SerializeField] private float maxRight; /// <summary> ������������ ����� �� ��� �, �� ������� ����� ����� ��������� </summary>
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Defeat() //����� �������� ��� ���������
    {
        animator.Play("PlatformDefeat");
    }

    public void TryMoveLeft() //�������� �����, ���� ��� ��������
    {
        if (transform.position.x > minLeft)
        {
            ChangePosition(-speed);
        }
    }

    public void TryMoveRight() //�������� ������, ���� ��� ��������
    {
        if (transform.position.x < maxRight)
        {
            ChangePosition(speed);
        }
    }

    private void ChangePosition(float speed) //��������� ������� ���������
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
