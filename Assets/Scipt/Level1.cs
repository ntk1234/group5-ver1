using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    

    void Start()
    {
        

       
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= 15f)
        {

            SceneManager.LoadScene("Level2");

        }

    }
   

}