using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kickevent : MonoBehaviour
{
    public GameObject kickbox;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ActivatePunchHitbox()
    {
        kickbox.SetActive(true);
    }
    public void DeactivatePunchHitbox()
    {
        kickbox.SetActive(false);
    }

}
