using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Flashlight : MonoBehaviour
{
	public GameObject Flashlight;
	public bool isflashOn;

	// Start is called before the first frame update
	void Start()
	{
		Flashlight.SetActive(false);

	}
	// Update is called once per frame
	void Update()
	{
		PressCheck();
	}

	void PressCheck()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			TurnFlashLight();
		}
	}

	void TurnFlashLight()
	{
		isflashOn = !isflashOn;
		if (isflashOn == false)
		{
			Flashlight.SetActive(true);


		}
		if (isflashOn == true)
		{
			Flashlight.SetActive(false);


		}
	}
}
