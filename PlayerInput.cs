using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerPlatform))]
public class PlayerInput : MonoBehaviour
{
    private PlayerPlatform PlayerPlatform; /// <summary> Игровая платформа </summary>
    private Vector2 startPoint = Vector2.zero; /// <summary> Точка касания </summary>
    private float direction = 0; /// <summary>  Переменная, обозначающая направление. Меньше нуля - влево, больше нуля - вправо </summary>

    private void Start()
    {
        PlayerPlatform = GetComponent<PlayerPlatform>();
    }

    private void Update()
    {
        GetTouchInput();
        TryMove();
    }


    private void GetTouchInput() //Считывание касание игрока
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    direction = touch.position.x > startPoint.x ? 1f : -1f; //Определение направления
                    break;
                default:
                    startPoint = touch.position; //если тип касания - не Moved движение не инициализируется
                    direction = 0;
                    break;
            }
        }
    }

    private void TryMove() //Обращения к методам платформы для инициализации движения
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
