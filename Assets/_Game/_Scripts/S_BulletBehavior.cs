using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BulletBehavior : MonoBehaviour
{
	public ParticleSystem spark;
	// Start is called before the first frame update
	public void OnCollisionEnter(Collision collision)
	{
		spark.Play();
		if (collision.gameObject.tag != "Player")
		{
			var joint = gameObject.AddComponent<FixedJoint>();
			joint.connectedBody = collision.rigidbody;
			if (collision.gameObject.GetComponent<Rigidbody>() != null)
			{
				collision.rigidbody.AddRelativeForce(gameObject.transform.forward, ForceMode.Impulse);
				Debug.Log("sparking");
				
			}
			Destroy(gameObject, 10f);
        
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        Blob bob
     = other.gameObject.GetComponent<Blob>();

        if (bob != null)
        {

            Debug.Log("Blob hit");
            bob.Damaged();
            Destroy(gameObject);
        }
    }
}
