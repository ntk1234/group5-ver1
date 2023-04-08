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
        // �T�O charController �M weapon ���O�Ťޥι�H
        if (charController != null && weapon != null)
        {
            PlayerPrefs.SetInt("health", charController.health);
            PlayerPrefs.SetFloat("attack", weapon.damage);
            PlayerPrefs.Save();
        }
    }
}