using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;  //子彈Prefab
    public float interval;  //兩發子彈之間的時間
    public bool followMovement;  //子彈是否隨角色移動而移動
    public float mySpeed;
    float myDestroyTimer;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * mySpeed;
    }

    void Update()
    {
        if (myDestroyTimer > 1)
        {
            Destroy(gameObject);
        }
        else
        {

            myDestroyTimer += Time.deltaTime;
        }
    }


IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            //產生子彈
            GameObject bullet = (Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0.1f), Quaternion.identity) as GameObject);

            //如果要隨主角移動，把子彈設為裝備的子物件
            if (followMovement)
                bullet.transform.parent = transform;

            //等候下一發子彈的時間
            yield return new WaitForSeconds(interval);
        }
    }
}