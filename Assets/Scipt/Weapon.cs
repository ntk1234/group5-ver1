using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public BoxCollider attackRangeObject;
    public int integerDamage = 10; // �N��Ƨ����O�אּ integerDamage �ܼ�
    public float damage = 10.0f; // �B�I�Ƨ����O

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
                enemyComponent.TakeDamage(integerDamage); // �ϥ� integerDamage �ܼ�
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackRangeObject.bounds.center, attackRangeObject.bounds.size);
    }
}