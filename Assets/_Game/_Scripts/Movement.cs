using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 6f;
     public CharacterController controller;
	public Transform playerCam;

	public float turnSmoothTime = .1f;


	float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        if (direction.magnitude >=.1f)
        {
			float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + playerCam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

			Vector3 MoveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(MoveDir.normalized * movementSpeed * Time.deltaTime);
        }
    }
}
