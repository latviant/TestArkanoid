using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Block> prefabs; /// <summary> Префабы блоков </summary>
    [SerializeField] GameObject spawn; /// <summary> Точка спавна </summary>
    [SerializeField] private int rows; /// <summary> Число необходимых рядов</summary>
    [SerializeField] private int columm; /// <summary> Число необходимых столбцов </summary>
    [SerializeField] private GameObject screen; /// <summary> UI Панель, которая активируется при событии Ennding </summary> 
    private int numberBlock = 0; /// <summary> Число созданных блоков </summary>
    private List<GameObject> blocks = new List<GameObject>(); /// <summary> Список созданных блоков </summary>

    public event UnityAction<GameObject> Endding; /// <summary> Событие, вызывающиеся после того, как все блоки уничтожены </summary>


    private void Awake()
    {
        for(int i  = 0; i < rows; i++)
        {
            for (int j = 0; j < columm; j++)
            {
                //Инициализация уровня
                GameObject game = Instantiate(prefabs[Random.Range(0, prefabs.Count - 1)].gameObject, new Vector3(spawn.transform.position.x + j, spawn.transform.position.y - i, spawn.transform.position.z), Quaternion.identity);
                numberBlock++;
                //Заполнение списка имеющихся блоков
                blocks.Add(game);
            }
        } 
    }


    //Подключение к событию, которая сообщает об уничтожении блока
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

    //Уменьшение числа блоков в списке
    private void RemoveBlock(int numberRemoveBlock)
    {
        numberBlock -= numberRemoveBlock;
    }
}
