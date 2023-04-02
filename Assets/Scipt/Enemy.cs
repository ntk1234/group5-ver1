using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float chaseDistance = 10f;
    public float knockbackForce = 10f;

    private Transform target;

    private void Start()
    {
        target = FindObjectOfType<CharController>().transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < chaseDistance)
        {
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharController playerController = other.GetComponent<CharController>();
            if (playerController != null)
            {
                playerController.health -= damage;

                // Add knockback force to enemy
                Vector3 knockbackDirection = (transform.position - other.transform.position).normalized;
                GetComponent<Rigidbody>().AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}