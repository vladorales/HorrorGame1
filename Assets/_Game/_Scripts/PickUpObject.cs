using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
	private Transform theDest;
	public Camera fpsCam;
	public GameObject weaponSelector;
	private GameObject pickedObject;

	public float range = 5f;
	public float force = 2000;
	public bool isCarrying = false;
	public void Start()
	{
		theDest = this.transform; //sets transform
	}

	public void Update()
	{
		CheckInput();
	}

	private void CheckInput()
	{
		if (Input.GetKeyUp(KeyCode.E))
		{
			LiftObject();
		}
	}

	private void LiftObject()
	{
		RaycastHit hit;
		if (isCarrying == false)
		{
			if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
			{
				if (hit.transform.gameObject.tag == "Box")
				{
					hit.transform.position = theDest.position;
					hit.rigidbody.isKinematic = true;
					hit.transform.parent = theDest.transform;
					weaponSelector.SetActive(false);
					pickedObject = hit.transform.gameObject;
					isCarrying = true;
				}
			}
		}
		else if (isCarrying == true)
		{
			pickedObject.transform.parent = null;
			Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
			rb.isKinematic = false;
			//rb.AddForce(transform.forward * force);
			rb.AddForce(fpsCam.transform.forward * force);
			isCarrying = false;
			weaponSelector.SetActive(true);
		}
	}
}

