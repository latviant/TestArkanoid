using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerPlatform))]
public class PlayerInput : MonoBehaviour
{
    private PlayerPlatform PlayerPlatform; /// <summary> ������� ��������� </summary>
    private Vector2 startPoint = Vector2.zero; /// <summary> ����� ������� </summary>
    private float direction = 0; /// <summary>  ����������, ������������ �����������. ������ ���� - �����, ������ ���� - ������ </summary>

    private void Start()
    {
        PlayerPlatform = GetComponent<PlayerPlatform>();
    }

    private void Update()
    {
        GetTouchInput();
        TryMove();
    }


    private void GetTouchInput() //���������� ������� ������
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    direction = touch.position.x > startPoint.x ? 1f : -1f; //����������� �����������
                    break;
                default:
                    startPoint = touch.position; //���� ��� ������� - �� Moved �������� �� ����������������
                    direction = 0;
                    break;
            }
        }
    }

    private void TryMove() //��������� � ������� ��������� ��� ������������� ��������
    {
        if (direction < 0)
        {
            PlayerPlatform.TryMoveLeft();
        }
        else if (direction > 0)
        {
            PlayerPlatform.TryMoveRight();
        }
    }

}
