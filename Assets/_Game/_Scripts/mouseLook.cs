﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
	public float mouseSensitivity = 100f;
	public Transform playerBody;

	public bool isMoving = true;

	float xrotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
	{
		if (isMoving == true)
		{
			MouseInput();
		}
		else if(isMoving == false)
		{
			return;
		}
	}

	private void MouseInput()
	{
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		xrotation -= mouseY;
		xrotation = Mathf.Clamp(xrotation, -90f, 90f);
		transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
	}
}
