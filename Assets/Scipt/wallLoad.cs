using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallLoad : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Wall2;
    // Start is called before the first frame update
    void Start()
    {
        Wall.SetActive(false);
        Wall2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 5f)
        {
            Wall.SetActive(true);
            Wall2.SetActive(true);
        }
    }
}
