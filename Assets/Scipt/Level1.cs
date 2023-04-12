using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    public GameObject MyPauseMenu;
    // 需要在Inspector中賦值
    
    void Start()
    {
        // 讀取當前的生命值和各項能力系數
        int health = PlayerPrefs.GetInt("health");
        float attack = PlayerPrefs.GetFloat("attack");

        // 輸出讀取到的數據
        Debug.Log("Health: " + health);
        Debug.Log("Attack: " + attack);

    }

    void Update()
    {
        if (MyPauseMenu == null)
        {
            MyPauseMenu = GameObject.Find("MyPauseMenu");
        }
        // 自動保存生命值，然後切換到 Level 2
        if (Time.timeSinceLevelLoad >= 15f)
        {
            // 保存生命值和攻擊力
            PlayerPrefs.SetInt("health", 50);
            PlayerPrefs.SetFloat("attack", 20f);
            /*MyPauseMenu.SetActive(true);*/
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}