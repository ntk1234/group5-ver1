using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int health = 100; // 當前的生命值

    void Start()
    {
        // 讀取保存的生命值
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
        // 當生命值小於等於 0 時，切換到 GameOver 畫面
        if (health <= 0)
        {
            SceneManager.LoadScene("title");
        }
    }

    public static void SaveHealth()
    {
        // 保存當前的生命值
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.Save();
    }
}