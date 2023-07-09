using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public float moveSpeed = 3f;
    public GameObject damageEffectPrefab;
    public int scoreValue = 10;

    public float detectionRadius = 10f;
    public Transform[] targets;
    private Transform currentTarget;

    private void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        targets = new Transform[playerObjects.Length];
        for (int i = 0; i < playerObjects.Length; i++)
        {
            targets[i] = playerObjects[i].transform;
        }
    }

    private void Update()
    {
        // Check the distance to all targets and select the closest one
        float closestDistance = Mathf.Infinity;
        for (int i = 0; i < targets.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, targets[i].position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                currentTarget = targets[i];
            }
        }

        // Move towards the current target
        if (currentTarget != null && closestDistance < detectionRadius)
        {
            transform.LookAt(currentTarget);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            moveSpeed = Mathf.Clamp(moveSpeed, 0f, 10f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharController playerController = other.gameObject.GetComponent<CharController>();
            CharController1 playerController1 = other.gameObject.GetComponent<CharController1>();

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
            playerController.AddScore(scoreValue);
        }
        if (playerController1 != null)
        {
            playerController1.AddScore(scoreValue);
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