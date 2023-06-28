using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballcd : MonoBehaviour
{
    public GameObject shoot;
    public float cooldownTime = 10.0f; // CD�ɶ���10��
    public KeyCode shootKey = KeyCode.Space; // �g����
    private bool canShoot = true; // �O�_�i�H�g��
    public KeyCode disableKey;

    void Update()
    {
        if (!canShoot)
        {
            // �p�G����g���A�Ұ�CD�p�ɾ�
            cooldownTime -= Time.deltaTime;
            if (cooldownTime <= 0)
            {
                // CD�����A�i�H�A���g��
                canShoot = true;
                cooldownTime = 10.0f;
            }
        }
        else
        {
            // �p�G�i�H�g���A�ˬd�O�_���U�g����
            if (Input.GetKeyDown("[3]"))
            {
                // �g��
             
                disableKey = KeyCode.Keypad3;
                canShoot = false;
            }
        }
    }
}
