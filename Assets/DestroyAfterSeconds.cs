using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    //�L�X��Ჾ��Game Object
    public float second;

    void Start()
    {
        //second���I�sDestroyGameObject���
        Invoke("DestroyGameObject", second);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}