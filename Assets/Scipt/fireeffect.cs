using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireeffect : MonoBehaviour
{
    public GameObject explosionEffectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }
    
}
}
