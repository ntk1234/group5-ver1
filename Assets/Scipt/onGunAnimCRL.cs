using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onGunAnimCRL : MonoBehaviour
    
{
    public int myAniMod;
    public GameObject myFather;
    // Start is called before the first frame update
    void Start()
    {
        myFather = GameObject.Find("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            myAniMod = 1;
        }
        switch (myAniMod)
        {
            case 0:
                gameObject.GetComponent<Animator>().Play("Idle");
                break;
            case 1:
                gameObject.GetComponent<Animator>().Play("gunplay");
                break;
            default:
                break;

        }
    }
    public void myFireTimeFN()
    {
        myFather.GetComponent<onPlayerForShoot>().SendMessage("myFire");
    }
    public void myFireLastFramFN()
    {
        myAniMod = 0;
    }

}
