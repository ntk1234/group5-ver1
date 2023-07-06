using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level22P : MonoBehaviour
{
    void Start()
    {
        
       
    }

    void Update()
    {
        // �۰ʫO�s�ͩR�ȡA�M������� Level 2
        if (Time.timeSinceLevelLoad >= 60f)
        {
         
        

            SceneManager.LoadScene("Level32p");
        }
    }
}