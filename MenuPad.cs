using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPad : MonoBehaviour
{
    [SerializeField] private GameManager manager; /// <summary> GameManager, �� �������� �������� ���������� � ����� ���� (������� Endding) </summary>
    [SerializeField] private DefeatPoint defeatPoint; /// <summary> �����, �� ������� �������� ���������� � ��������� ������ </summary>

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

    public void OpenPad(GameObject pad) //��������� UI ������
    {
        pad.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePad(GameObject pad)  //����������� UI ������
    {
        pad.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()  //����� �� ����������
    {
        Application.Quit();
    }

    public void Restart() //������������ ������
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
