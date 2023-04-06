using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelTimer : MonoBehaviour
{
    // 設定每個關卡的時間間隔（秒）
    public int levelInterval = 300;

    // 設定下一個關卡的名稱
    public string nextLevelName;

    private void Start()
    {
        // 取得現在的時間戳記
        int current_time = (int)System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1)).TotalSeconds;

        // 計算下一個關卡的時間戳記
        int next_level_time = ((current_time / levelInterval) + 1) * levelInterval;

        // 計算現在距離下一個關卡還有多少時間（秒）
        int remaining_time = next_level_time - current_time;

        // 延遲指定的時間後切換到下一個關卡
        Invoke("SwitchToNextLevel", remaining_time);
    }

    // 切換到下一個關卡
    void SwitchToNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}

