using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{

    

    CharController charController;

    void Start()
    {
        charController = GetComponent<CharController>();
        charController = FindObjectOfType<CharController>();
        if (charController.score >= 200)
        {
            DestroyBuilding();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    public GameObject buildingToDestroy;

   

    void DestroyBuilding()
    {
        Destroy(buildingToDestroy);
    }
}
