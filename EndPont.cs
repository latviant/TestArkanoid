using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class EndPont : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public event UnityAction<GameObject> Endding;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            Endding?.Invoke(panel);
        }
    }
}
