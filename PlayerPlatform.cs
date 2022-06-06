using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Animator))]
public class PlayerPlatform : MonoBehaviour
{
    [SerializeField] private float speed; /// <summary> Скорость движения платформы </summary>
    [SerializeField] private float minLeft; /// <summary> минимальная точка по оси Х, до которой пожет дойти платформа </summary>
    [SerializeField] private float maxRight; /// <summary> максимальная точка по оси Х, до которой пожет дойти платформа </summary>
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Defeat() //Вызов анимации при поражении
    {
        animator.Play("PlatformDefeat");
    }

    public void TryMoveLeft() //Движение влево, если это возможно
    {
        if (transform.position.x > minLeft)
        {
            ChangePosition(-speed);
        }
    }

    public void TryMoveRight() //Движение вправо, если это возможно
    {
        if (transform.position.x < maxRight)
        {
            ChangePosition(speed);
        }
    }

    private void ChangePosition(float speed) //Изменение позиции платформы
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
