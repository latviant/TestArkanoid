using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockLock : Block
{
    /// <summary>
    /// ������� ������ ������ Block. ������ � ������� Chain
    /// </summary>

    public event UnityAction Dying;/// <summary> ������� ���������� ��� ����������� ����� </summary>

    protected override void Die() //�������� �����������
    {
        Dying?.Invoke();
        base.Die();
    }
}
