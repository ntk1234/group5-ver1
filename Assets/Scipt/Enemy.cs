using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int score = 10;
    public int health = 100;
    public int damage = 10;
    public float moveSpeed = 3f;
    public GameObject damageEffectPrefab;

    private Transform target;

    private void Start()
    {
        target = FindObjectOfType<CharController>().transform;
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
            if (playerController != null)
            {
                playerController.TakeDamage(damage);
            }
            TakeDamageEffect(damage);
            Die();
        }
    }

    private void Die()
    {
        // 增加玩家分數
        CharController playerController = FindObjectOfType<CharController>();
        if (playerController != null)
        {
            playerController.score += score;
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
        // 播放扣血特效
        if (damageEffectPrefab != null)
        {
            GameObject damageEffect = Instantiate(damageEffectPrefab, transform.position, Quaternion.identity);
            Destroy(damageEffect, 1f);
        }
    }
}