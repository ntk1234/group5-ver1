using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;  //�l�uPrefab
    public float interval;  //��o�l�u�������ɶ�
    public bool followMovement;  //�l�u�O�_�H���Ⲿ�ʦӲ���
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
            //���ͤl�u
            GameObject bullet = (Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, 0.1f), Quaternion.identity) as GameObject);

            //�p�G�n�H�D�����ʡA��l�u�]���˳ƪ��l����
            if (followMovement)
                bullet.transform.parent = transform;

            //���ԤU�@�o�l�u���ɶ�
            yield return new WaitForSeconds(interval);
        }
    }
}