
using System;
using UnityEngine;

public class S_Target : MonoBehaviour
{
	public float health = 50f;

    // Update is called once per frame
    public void TakeDamage(float amount)
    {
		health -= amount;
		if (health <= 0f)
		{
			Die();
		}
    }

	 void Die()
	{
		Destroy(gameObject);
	}
}
