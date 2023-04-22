using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartLoad : MonoBehaviour
{
    public GameObject heartPrefab;
    public float delayTime = 5.0f;

    private bool hasHeart;

    private void Start()
    {
        Invoke("SpawnHeart", delayTime);
    }

    private void SpawnHeart()
    {
        if (!hasHeart)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
            hasHeart = true;
        }
    }
}
