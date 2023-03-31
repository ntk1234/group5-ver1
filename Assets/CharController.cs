using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
	
	Animator anim;

	public enum AnimState{ IDLE=0, ATTACK=1,MOVE_ATTACK=2}
	public AnimState _animState = AnimState.IDLE;
	public float rotSpeed = 10;
	Vector3 moveDirection;

	public GameObject projectile;
	public float fireDelta = 0.5F;

	private float nextFire = 0.5F;
	private GameObject newProjectile;
	private float myTime = 0.0F;
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
       
		if(_animState== AnimState.IDLE){ ... }
		else if(_animState == AnimState.ATTACK) { anim.SetTrigger("attack"); }
		else if (_animState == AnimState.MOVE_ATTACK){ ... }
		/*	if (anim)
			{
				anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 1f, Time.deltaTime * 10));
			}
			else
			{
				anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), 0f, Time.deltaTime * 10));
			}
		*/
		//if (Input.GetButtonDown("Fire1") { anim.SetTrigger("attack"); }
		if (Input.GetButtonDown("Fire1")){ _animState=AnimState.ATTACK; }
		if (Input.GetButton("Fire2")){
			
			anim.SetTrigger("moveAttack");

			
		}
		if (Input.GetButtonUp("Fire2"))
			anim.SetTrigger("moveAttackclose");

	}
}
