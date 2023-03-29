using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement1 : MonoBehaviour
{
    private CharacterController controller;
    public float Speed = 10f;
    public float RotateSpeed = 1f;
    public float Gravity = -9.8f;
    private Vector3 Velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //MoveLikeWow();
        MoveLikeTopDown();
    }

    private void MoveLikeWow()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var move = transform.forward * Speed * vertical * Time.deltaTime;
        controller.Move(move);

        transform.Rotate(Vector3.up, horizontal * RotateSpeed);
    }
    private void MoveLikeTopDown()
    {
        
        var playScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        var point = Input.mousePosition - playScreenPoint;
        var angle = Mathf.Atan2(point.x, point.y) * Mathf.Rad2Deg;

    }
   
    }



