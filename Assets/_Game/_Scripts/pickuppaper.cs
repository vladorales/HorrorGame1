using System;
using UnityEngine;
using System.Collections.Generic;

public class pickuppaper : MonoBehaviour
{
	// Start is called before the first frame update
	public float paperGotten = 0f;
	public float range = 100f;


	[SerializeField] Camera fpsCam;

	public AudioSource ripSound;
	public AudioSource DoorSound;


	void Update()
	{
		PressCheck();
	}

	void PressCheck()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			LookAt();
		}
	}


	void LookAt()
{
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);
			Debug.DrawRay(transform.position, transform.forward, Color.green);
			GameObject objectHit = hit.transform.gameObject;
			PaperCollect paperCollect;
				

			if (objectHit.transform.gameObject.tag == "Paper")
			{
				paperCollect = objectHit.GetComponent<PaperCollect>();
				paperCollect.changeActive();
				ripSound.Play();
			}
			else
			{

			}
				


		}
	}
}

