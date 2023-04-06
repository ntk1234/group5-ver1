using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int health = 100; // ��e���ͩR��

    void Start()
    {
        // Ū���O�s���ͩR��
        if (PlayerPrefs.HasKey("health"))
        {
            health = PlayerPrefs.GetInt("health");
        }
        else
        {
            health = 100;
        }
    }

    void Update()
    {
        // ��ͩR�Ȥp�󵥩� 0 �ɡA������ GameOver �e��
        if (health <= 0)
        {
            SceneManager.LoadScene("title");
        }
    }

    public static void SaveHealth()
    {
        // �O�s��e���ͩR��
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.Save();
    }
}