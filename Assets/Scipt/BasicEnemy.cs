using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
	[Header("Stats")]
	public int health;
	public int damage;
	public void TakeDamage(int damge)

	{
		health -= damage;

		if (health <= 0)
			Destroy(gameObject);
	}
}