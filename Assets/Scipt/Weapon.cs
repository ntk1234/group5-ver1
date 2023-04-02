using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public CapsuleCollider attackRangeObject;
    public int damage = 20;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapCapsule(
            attackRangeObject.transform.position + attackRangeObject.center - Vector3.up * attackRangeObject.height / 2f,
            attackRangeObject.transform.position + attackRangeObject.center + Vector3.up * attackRangeObject.height / 2f,
            attackRangeObject.radius);

        foreach (Collider enemy in hitEnemies)
        {
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackRangeObject.bounds.center, attackRangeObject.radius);
    }
}