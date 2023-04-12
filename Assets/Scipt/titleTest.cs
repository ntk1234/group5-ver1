using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleTest : MonoBehaviour

    
{
    public float Speed = 5;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    
    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(-94f, 102.4f, 0), Speed * Time.deltaTime);
        

    }
}

