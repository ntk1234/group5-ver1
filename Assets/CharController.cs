using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
	
	Animator anim;

	public float rotSpeed = 10;
	Vector3 moveDirection;


	void Start()
		{
		anim = GetComponent<Animator>();
		}

		void Update()
		{
			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");
			Vector2 move = new Vector2(h, v);
			anim.SetFloat("speed", move.magnitude);

		moveDirection = new Vector3(h, 0, v);
		moveDirection = Camera.main.transform.TransformDirection(moveDirection);
		moveDirection.y = 0;

		if (moveDirection != Vector3.zero)
		{
			Quaternion newRotation = Quaternion.LookRotation(moveDirection);
			transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotSpeed * Time.deltaTime);
		}
       
	/*	if (anim)
		{
			anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10));
		}
		else
		{
			anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10));
		}
	*/
		if (Input.GetButtonDown("Fire1") 
			//&&!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")
			)
			anim.SetTrigger("attack");

		if (Input.GetButtonDown("Fire2"))
			anim.SetTrigger("moveAttack");
	}
	}
