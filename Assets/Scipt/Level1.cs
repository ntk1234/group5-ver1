using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    void Start()
    {
        // �]�m��e���ͩR��
        GameManager.health = 100;
    }

    void Update()
    {
        // �۰ʫO�s�ͩR�ȡA�M������� Level 2
        if (Time.timeSinceLevelLoad >= 15f)
        {
            // �O�s�ͩR��
            GameManager.health = 50;
            GameManager.SaveHealth();

            SceneManager.LoadScene("Level2");
        }
    }
}
