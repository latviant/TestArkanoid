using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] Transform ballPosition;  /// <summary> Точка, в которой вначале игры появлется шар </summary>
    private Vector2 ballForce = new Vector2 (15f, 50f); /// <summary> Сила, которая запускает движение шара </summary>
    private Rigidbody2D rigidbody2D; /// <summary> Rididbody шара </summary>
    private int reward = 1; /// <summary> награда за разбитый блок </summary>
    private bool IsActive = false; /// <summary> Состояние активности/неактивности шарв </summary>

    public event UnityAction<int> Rewarding;
 
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        transform.position = ballPosition.position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && IsActive == false )
        {
            Push();
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Block>(out Block block))
        {
            Rewarding?.Invoke(reward);
        }
    }

    private void Push() //Запуск движение
    {
        transform.SetParent(null);
        IsActive = true;
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        rigidbody2D.AddForce(ballForce);
    }
}