using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitForce : MonoBehaviour
{
    public float hitForce = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                rb.AddForce(direction * hitForce, ForceMode.Impulse);
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(10);
            
                }
            }
        }
    }
}
