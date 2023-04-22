using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5.0f;
    public float explosionForce = 1000.0f;
    public int damage = 50;
    public GameObject explosionEffectPrefab;
    public AudioClip explosionSound;

    private void OnTriggerEnter(Collider other)
    {
        // 如果碰撞物体是玩家，则触发爆炸效果
        CharController player = other.GetComponent<CharController>();
        if (player != null)
        {
            Explode();
        }
    }

    private void Explode()
    {
        // 在炸弹位置产生爆炸效果
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        // 播放声音
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }

        // 查找所有在爆炸半径内的敌人，并对其造成伤害和推力
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider enemy in hitEnemies)
        {
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                Vector3 direction = enemy.transform.position - transform.position;
                enemyComponent.TakeDamage(damage);
                enemyComponent.GetComponent<Rigidbody>().AddForce(direction.normalized * explosionForce);
            }
        }

        // 销毁炸弹对象
        Destroy(gameObject);
    }
}