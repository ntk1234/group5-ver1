using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public float moveSpeed = 3f;
    public GameObject damageEffectPrefab;
    public int scoreValue = 10; // 增加分数

    private Transform target;

    private void Start()
    {
        target = FindObjectOfType<CharController>().transform;
        target = FindObjectOfType<CharController1>().transform;
    }

    private void Update()
    {
        transform.LookAt(target);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        moveSpeed = Mathf.Clamp(moveSpeed, 0f, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharController playerController = other.gameObject.GetComponent<CharController>();
            CharController1 playerController1 = other.gameObject.GetComponent<CharController1>();
            ;

            if (playerController != null)
            {
                playerController.TakeDamage(damage);
            }
            if (playerController1 != null)
            {
                playerController1.TakeDamage(damage);
            }
            TakeDamageEffect(damage);
            Die();
        }
    }

    private void Die()
    {
       CharController playerController = FindObjectOfType<CharController>();
        CharController1 playerController1 = FindObjectOfType<CharController1>();
        
        if (playerController != null)
        {
            playerController.AddScore(scoreValue); // 增加分数
        }
        if (playerController1 != null)
        {
            playerController1.AddScore(scoreValue); // 增加分数
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