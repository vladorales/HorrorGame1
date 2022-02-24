using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	public CharacterController controller;
    //public GunWithObject gunReload;
	public float speed = 12f;
	public float gravity = -9.81f;
	public float jumpHeight = 3f;

	Vector3 velocity;
	bool isGrounded;

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	public bool isMoving = true;

	// Update is called once per frame
    void Update()
	{

       
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}
		if (isMoving == true)
		{
		NotInput();
		}
		else if (isMoving == false)
		{
			return;
			//stops movement
		}

	}

	

	private void NotInput()
	{
		

		float x = UnityEngine.Input.GetAxis("Horizontal");
		float z = UnityEngine.Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		controller.Move(move * speed * Time.deltaTime);
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

		if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

			velocity.y += gravity * Time.deltaTime;

			controller.Move(velocity * Time.deltaTime);
		}
	}

}
