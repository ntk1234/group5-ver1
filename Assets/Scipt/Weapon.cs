using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public BoxCollider attackRangeObject;
    public float damage = 10.0f;
    public float attackInterval = 0.5f;
    private float lastAttackTime;
   

    

    void Start()
    {
       
        
    }

    private void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            Attack();
           
        }
        else if (Input.GetKeyDown("k") && Time.time >= lastAttackTime + attackInterval)
        {
            AttackBuilding();
            lastAttackTime = Time.time;
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
                enemyComponent.TakeDamage((int)damage);
            }
        }
    }

    private void AttackBuilding()
    {
        if (attackRangeObject != null)
        {
            Collider[] hitBuildings = Physics.OverlapBox(
                attackRangeObject.bounds.center,
                attackRangeObject.bounds.extents,
                attackRangeObject.transform.rotation);

            foreach (Collider building in hitBuildings)
            {
                Building buildingComponent = building.GetComponent<Building>();
                if (buildingComponent != null)
                {
                    buildingComponent.TakeDamage((int)damage);
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