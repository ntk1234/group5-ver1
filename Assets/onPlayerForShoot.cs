using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPlayerForShoot : MonoBehaviour
{
    public GameObject myBullet;
    public GameObject myFirePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject bullet = Instantiate(myBullet, myFirePoint.transform.position, myFirePoint.transform.rotation) as GameObject;
            bullet.name = "bullet";

        }
    }
    
}
