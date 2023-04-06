using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    void Start()
    {
        // 設置當前的生命值
        GameManager.health = 100;
    }

    void Update()
    {
        // 自動保存生命值，然後切換到 Level 2
        if (Time.timeSinceLevelLoad >= 15f)
        {
            // 保存生命值
            GameManager.health = 50;
            GameManager.SaveHealth();

            SceneManager.LoadScene("Level2");
        }
    }
}
