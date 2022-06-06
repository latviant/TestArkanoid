using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Block> prefabs; /// <summary> ������� ������ </summary>
    [SerializeField] GameObject spawn; /// <summary> ����� ������ </summary>
    [SerializeField] private int rows; /// <summary> ����� ����������� �����</summary>
    [SerializeField] private int columm; /// <summary> ����� ����������� �������� </summary>
    [SerializeField] private GameObject screen; /// <summary> UI ������, ������� ������������ ��� ������� Ennding </summary> 
    private int numberBlock = 0; /// <summary> ����� ��������� ������ </summary>
    private List<GameObject> blocks = new List<GameObject>(); /// <summary> ������ ��������� ������ </summary>

    public event UnityAction<GameObject> Endding; /// <summary> �������, ������������ ����� ����, ��� ��� ����� ���������� </summary>


    private void Awake()
    {
        for(int i  = 0; i < rows; i++)
        {
            for (int j = 0; j < columm; j++)
            {
                //������������� ������
                GameObject game = Instantiate(prefabs[Random.Range(0, prefabs.Count - 1)].gameObject, new Vector3(spawn.transform.position.x + j, spawn.transform.position.y - i, spawn.transform.position.z), Quaternion.identity);
                numberBlock++;
                //���������� ������ ��������� ������
                blocks.Add(game);
            }
        } 
    }


    //����������� � �������, ������� �������� �� ����������� �����
    private void OnEnable()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].GetComponent<Block>().Diying += RemoveBlock;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].GetComponent<Block>().Diying -= RemoveBlock;
        }
    }

    private void Update()
    {
        if(numberBlock <= 0)
        {
            Endding?.Invoke(screen);
        }
    }

    //���������� ����� ������ � ������
    private void RemoveBlock(int numberRemoveBlock)
    {
        numberBlock -= numberRemoveBlock;
    }
}
