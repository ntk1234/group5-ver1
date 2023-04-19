using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingHPUP : MonoBehaviour
{
    public int health = 100;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    

    private void Die()
    {
        CharController playerController = FindObjectOfType<CharController>();
        
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        
    }

}


}
