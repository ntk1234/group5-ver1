using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    void Start()
    {
        // Ū����e���ͩR�ȩM�U����O�t��
        int health = PlayerPrefs.GetInt("health");
        float power = PlayerPrefs.GetFloat("power");
        float attack = PlayerPrefs.GetFloat("attack");

        // ��XŪ���쪺�ƾ�
        Debug.Log("Health: " + health);
        Debug.Log("Power: " + power);
        Debug.Log("Attack: " + attack);
    }

    void Update()
    {
        // �۰ʫO�s�ͩR�ȡA�M������� Level 2
        if (Time.timeSinceLevelLoad >= 10f)
        {
            // �O�s�ͩR��
            // �O�s�ͩR�ȩM�����O
            /* PlayerPrefs.SetInt("health", 50);
             PlayerPrefs.SetFloat("attack", 20f);*/

            SceneManager.LoadScene("Level2");
}
}
}
