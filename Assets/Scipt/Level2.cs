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
        // �۰ʫO�s�ͩR�ȡA�M������� Level 2
        if (Time.timeSinceLevelLoad >= 18f)
        {
         
        

            SceneManager.LoadScene("Level3");
        }
    }
}