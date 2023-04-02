using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBullet : MonoBehaviour
{
    public float mySpeed;
    float myDestroyTimer;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * mySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (myDestroyTimer > 1)
        {
            Destroy(gameObject);
        }
        else
        {

            myDestroyTimer += Time.deltaTime;
        }
    }
}

