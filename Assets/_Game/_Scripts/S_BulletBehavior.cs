using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BulletBehavior : MonoBehaviour
{
	// Start is called before the first frame update
	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag != "Player")
		{
			var joint = gameObject.AddComponent<FixedJoint>();
			joint.connectedBody = collision.rigidbody;
			if (collision.gameObject.GetComponent<Rigidbody>() != null)
			{
				collision.rigidbody.AddRelativeForce(gameObject.transform.forward, ForceMode.Impulse);
			}
			Destroy(gameObject, 3f);

		}
	}

	
}
