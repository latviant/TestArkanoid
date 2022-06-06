using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DefeatPoint : MonoBehaviour
{
    [SerializeField] private GameObject panel; /// <summary> панель, которая вызывается при событии Loosing </summary>
    [SerializeField] private PlayerPlatform playerPlatform; /// <summary> Платформа игрока, которой нужна информация о поражении </summary>
    public event UnityAction<GameObject> Loosing; /// <summary> Событие, которое вызывается при касании шаром запретной зоны </summary>

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            playerPlatform.Defeat(); //вызов анимации платформы
            Loosing?.Invoke(panel);
        }
    }
}
   

