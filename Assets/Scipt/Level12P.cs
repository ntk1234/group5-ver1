using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level12P : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {
        if (Time.timeSinceLevelLoad >= 35f)
        {
            SceneManager.LoadScene("Level22p");
        }


    }
}