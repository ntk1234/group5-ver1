using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buidingHit : MonoBehaviour
{

    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharController playerController = other.gameObject.GetComponent<CharController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage);
            }
            
        }
    }
}
