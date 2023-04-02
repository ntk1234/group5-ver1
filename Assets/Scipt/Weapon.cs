using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public BoxCollider attackRangeObject;
    public int damage = 10;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapBox(
            attackRangeObject.bounds.center,
            attackRangeObject.bounds.extents,
            attackRangeObject.transform.rotation);

        foreach (Collider enemy in hitEnemies)
        {
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.TakeDamage(damage);
                if (enemyComponent.health <= 0)
                {
                    CharController playerController = GetComponentInParent<CharController>();
                    if (playerController != null)
                    {
                        playerController.score += 10;
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackRangeObject.bounds.center, attackRangeObject.bounds.size);
    }
}