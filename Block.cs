using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private int health; /// <summary> Число жизней блока </summary>
    [SerializeField] private List<Color> colors;/// <summary> Список используемых цветов</summary>
    private SpriteRenderer spriteRenderer; /// <summary> SpriteRenderer конкретного блока </summary>
    private int numberBlock = 1; /// <summary> Константа для отправки информации о числе удаленных блоков </summary>

    public event UnityAction<int> Diying; /// <summary> Событие, вызываемое в результате операции деактивации </summary>

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = colors[colors.Count - 1];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball)) //При столкновении с шаром уменьшается количество жизней
        {
            health--;

            if (health <= 0) //если число жизней меньше ила равно нулю, блок деактивируется
            {
                Die();
            }
            else //в другом случае у него изменяется цвет
            {
                ChangeColor(health);
            }
        }
    }

    protected void ChangeColor(int health) //Изменение цвета в результате снижения здоровья
    {
        spriteRenderer.color = colors[health - 1];
    }

    protected virtual void Die()  //Операция деактивации
    {
        gameObject.SetActive(false);
        Diying?.Invoke(numberBlock);
    }
}