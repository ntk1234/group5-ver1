using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public float moveSpeed = 3f;

    private Transform target;

    private void Start()
    {
        target = FindObjectOfType<CharController>().transform;
    }

    private void Update()
    {
        transform.LookAt(target);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        moveSpeed = Mathf.Clamp(moveSpeed, 0f, 10f); // 使用Mathf.Clamp方法限制移動速度範圍
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharController playerController = other.GetComponent<CharController>();
            if (playerController != null)
            {
                playerController.health -= damage;
                Die();
            }
        }
    }

    private void Die()
    {
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