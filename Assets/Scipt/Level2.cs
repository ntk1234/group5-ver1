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
       
        if (Time.timeSinceLevelLoad >= 20f)
        {
         
        

            SceneManager.LoadScene("Level3");
        }
    }
}