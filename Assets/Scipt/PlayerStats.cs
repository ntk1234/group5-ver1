using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int health;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnDestroy()
    {
        // �O�s��e�ͩR��
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.Save();
    }
}
