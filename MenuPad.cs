using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPad : MonoBehaviour
{
    [SerializeField] private GameManager manager; /// <summary> GameManager, от которого получают информацию о конце игры (событие Endding) </summary>
    [SerializeField] private DefeatPoint defeatPoint; /// <summary> Точка, от которой получают информацию о поражении игрока </summary>

    private void OnEnable()
    {
        manager.Endding += OpenPad;
        defeatPoint.Loosing += OpenPad;
    }

    private void OnDisable()
    {
        manager.Endding -= OpenPad;
        defeatPoint.Loosing -= OpenPad;
    }

    public void OpenPad(GameObject pad) //активация UI панели
    {
        pad.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePad(GameObject pad)  //деактивация UI панели
    {
        pad.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()  //Выход из приложения
    {
        Application.Quit();
    }

    public void Restart() //Перезагрузка уровня
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
