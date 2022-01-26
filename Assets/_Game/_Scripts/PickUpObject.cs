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
	//public float force = 2000;
	public bool isCarrying = false;

	//Inspect Item Variables
	Vector3 ItemStartPosition;
	Quaternion StartingRot;

	public float Speed = 100f;

	public playerMovement move;
	public mouseLook mouseRotation;

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
				if (hit.transform.gameObject.tag == "Item")
				{
					move.isMoving = false;
					mouseRotation.isMoving = false;
					ItemStartPosition = hit.transform.position; // Item Starting Rotation
					StartingRot = Quaternion.Euler(hit.transform.localEulerAngles); //Item starting Rotation
					hit.transform.position = theDest.position;
					//hit.rigidbody.isKinematic = true;
					hit.transform.parent = theDest.transform;
					weaponSelector.SetActive(false);
					pickedObject = hit.transform.gameObject;
					isCarrying = true;
					RotateItem();

				}
			}
		}
		else if (isCarrying == true)
		{
			pickedObject.transform.parent = null;
			pickedObject.transform.position = ItemStartPosition;
			pickedObject.transform.rotation = Quaternion.Euler(StartingRot.eulerAngles);
			//Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
			//rb.isKinematic = false;
			//rb.AddForce(transform.forward * force);
			//rb.AddForce(fpsCam.transform.forward * force);
			isCarrying = false;
			weaponSelector.SetActive(true);
			move.isMoving = true;
			mouseRotation.isMoving = true;
		}
	}
	public void RotateItem()
	{
		float x = Input.GetAxis("Mouse X") * Speed;
		float y = Input.GetAxis("Mouse Y") * Speed;

		pickedObject.transform.Rotate(-Vector3.up * x, Space.World);
		pickedObject.transform.Rotate(-Vector3.forward * y, Space.World);


	}
}

