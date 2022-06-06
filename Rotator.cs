using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using UnityEngine.Events;

public class Rotator : MonoBehaviour
{
    private Vector3 rotation = new Vector3(0, 90, 0); /// <summary> Шаг для поворота игровой плоскости </summary>

    public void RotateLeft()
    {
        Rotate(-rotation);
    }

    public void RotateRight()
    {
        Rotate(rotation);
    }

    private void Rotate(Vector3 rotation) //Поворот игрового поля
    {
        transform.DORotate(rotation, 2, RotateMode.LocalAxisAdd);
    }
}

