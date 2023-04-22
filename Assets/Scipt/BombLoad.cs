using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLoad : MonoBehaviour
{
    public GameObject bombPrefab;
    public float delayTime = 7.0f;

    private bool hasBomb;

    private void Start()
    {
        Invoke("SpawnBomb", delayTime);
    }

    private void SpawnBomb()
    {
        if (!hasBomb)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            hasBomb = true;
        }
    }
}