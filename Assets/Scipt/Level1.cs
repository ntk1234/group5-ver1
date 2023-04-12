using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    public GameObject MyPauseMenu;
    // �ݭn�bInspector�����
    
    void Start()
    {
        // Ū����e���ͩR�ȩM�U����O�t��
        int health = PlayerPrefs.GetInt("health");
        float attack = PlayerPrefs.GetFloat("attack");

        // ��XŪ���쪺�ƾ�
        Debug.Log("Health: " + health);
        Debug.Log("Attack: " + attack);

    }

    void Update()
    {
        if (MyPauseMenu == null)
        {
            MyPauseMenu = GameObject.Find("MyPauseMenu");
        }
        // �۰ʫO�s�ͩR�ȡA�M������� Level 2
        if (Time.timeSinceLevelLoad >= 15f)
        {
            // �O�s�ͩR�ȩM�����O
            PlayerPrefs.SetInt("health", 50);
            PlayerPrefs.SetFloat("attack", 20f);
            /*MyPauseMenu.SetActive(true);*/
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}