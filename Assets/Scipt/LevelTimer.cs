using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelTimer : MonoBehaviour
{
    // �]�w�C�����d���ɶ����j�]��^
    public int levelInterval = 300;

    // �]�w�U�@�����d���W��
    public string nextLevelName;

    private void Start()
    {
        // ���o�{�b���ɶ��W�O
        int current_time = (int)System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1)).TotalSeconds;

        // �p��U�@�����d���ɶ��W�O
        int next_level_time = ((current_time / levelInterval) + 1) * levelInterval;

        // �p��{�b�Z���U�@�����d�٦��h�֮ɶ��]��^
        int remaining_time = next_level_time - current_time;

        // ������w���ɶ��������U�@�����d
        Invoke("SwitchToNextLevel", remaining_time);
    }

    // ������U�@�����d
    void SwitchToNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}

