using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballcd : MonoBehaviour
{
    public GameObject shoot;
    public float cooldownTime = 10.0f; // CD時間為10秒
    public KeyCode shootKey = KeyCode.Space; // 射擊鍵
    private bool canShoot = true; // 是否可以射擊
    public KeyCode disableKey;

    void Update()
    {
        if (!canShoot)
        {
            // 如果不能射擊，啟動CD計時器
            cooldownTime -= Time.deltaTime;
            if (cooldownTime <= 0)
            {
                // CD結束，可以再次射擊
                canShoot = true;
                cooldownTime = 10.0f;
            }
        }
        else
        {
            // 如果可以射擊，檢查是否按下射擊鍵
            if (Input.GetKeyDown("[3]"))
            {
                // 射擊
             
                disableKey = KeyCode.Keypad3;
                canShoot = false;
            }
        }
    }
}
