using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingUp : MonoBehaviour
{
    public int health = 50;
    public int damage = 10;
    public int uphpValue =30;

    public GameObject damageEffectPrefab;
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
            CharController1 playerController1 = other.gameObject.GetComponent<CharController1>();
            Die();
        }
    }


    private void Die()
    {
        CharController playerController = FindObjectOfType<CharController>();
        CharController1 playerController1 = FindObjectOfType<CharController1>();
        if (playerController != null)
        {
            playerController.AddHealth(uphpValue); 
        }
        if (playerController1 != null)
        {
            playerController1.AddHealth(uphpValue);
        }

        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            TakeDamageEffect(damage);
        }

    }
    private void TakeDamageEffect(int damage)
    {
        if (damageEffectPrefab != null)
        {
            GameObject damageEffect = Instantiate(damageEffectPrefab, transform.position, Quaternion.identity);
            Destroy(damageEffect, 1f);
        }
    }

}
