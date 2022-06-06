using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    [SerializeField] private List<BlockLock> blockLocks; /// <summary> ������ ������, � ������� ��������� ���� </summary>
    int activeBlocks = 0; /// <summary> ����� �������� ������ </summary>

    private void OnEnable()
    {
        activeBlocks = blockLocks.Count;

        foreach (BlockLock block in blockLocks)
        {
            block.Dying += ChangeList;
        }
    }

    private void OnDisable()
    {
        foreach (BlockLock block in blockLocks)
        {
            block.Dying -= ChangeList;
        }
    }

    private void ChangeList() //����������� ������ ��� �� �����������
    {
        activeBlocks--;

        if(activeBlocks <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
