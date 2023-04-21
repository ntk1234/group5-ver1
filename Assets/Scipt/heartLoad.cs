using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartLoad : MonoBehaviour
{
    public GameObject Heart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 5f)
        {
            Heart.SetActive(true);


        }
    }
}
