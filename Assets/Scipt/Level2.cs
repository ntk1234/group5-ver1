using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    void Start()
    {
        // Ū����e���ͩR�ȩM�U����O�t��
        int health = PlayerPrefs.GetInt("health");
        float power = PlayerPrefs.GetFloat("power");
        float speed = PlayerPrefs.GetFloat("speed");

        // ��XŪ���쪺�ƾ�
        Debug.Log("Health: " + health);
        Debug.Log("Power: " + power);
        Debug.Log("Speed: " + speed);
    }

    void Update()
    {
        // �۰ʫO�s�ͩR�ȡA�M������� Level 2
        if (Time.timeSinceLevelLoad >= 20f)
        {
            // �O�s�ͩR��
            GameManager.health = 50;
            GameManager.SaveHealth();

            SceneManager.LoadScene("Level2");
        }
    }
}