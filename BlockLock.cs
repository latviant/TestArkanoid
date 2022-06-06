using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockLock : Block
{
    /// <summary>
    /// Частный случай класса Block. Связан с классом Chain
    /// </summary>

    public event UnityAction Dying;/// <summary> Событие вызываемое при уничтожении блока </summary>

    protected override void Die() //Операция деактивации
    {
        Dying?.Invoke();
        base.Die();
    }
}
