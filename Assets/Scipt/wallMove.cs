using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMove : MonoBehaviour
{
    public float Speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(28.1f, 14.057f, -0.9326f), Speed * Time.deltaTime);

    }
}
