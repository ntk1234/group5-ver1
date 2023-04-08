using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public CharController charController;
    public Weapon weapon;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnDestroy()
    {
        // 確保 charController 和 weapon 不是空引用對象
        if (charController != null && weapon != null)
        {
            PlayerPrefs.SetInt("health", charController.health);
            PlayerPrefs.SetFloat("attack", weapon.damage);
            PlayerPrefs.Save();
        }
    }
}