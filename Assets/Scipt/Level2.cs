using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    void Start()
    {
        
       
    }

    void Update()
    {
        // 自動保存生命值，然後切換到 Level 2
        if (Time.timeSinceLevelLoad >= 18f)
        {
         
        

            SceneManager.LoadScene("Level3");
        }
    }
}