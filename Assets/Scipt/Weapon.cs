using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public BoxCollider attackRangeObject;
    public int integerDamage = 10; // 將整數攻擊力改為 integerDamage 變數
    public float damage = 10.0f; // 浮點數攻擊力

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
                enemyComponent.TakeDamage(integerDamage); // 使用 integerDamage 變數
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackRangeObject.bounds.center, attackRangeObject.bounds.size);
    }
}