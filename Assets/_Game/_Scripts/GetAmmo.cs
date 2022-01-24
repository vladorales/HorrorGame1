using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAmmo : MonoBehaviour
{
	public GameObject PlayerObject;
	public float ammoAmount = 10f;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
		
		

    }


	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			PlayerObject = other.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject;
			PlayerObject.GetComponent<GunWithObject>().bulletAmmo += ammoAmount;
		}
		else
		{
			return;
		}
	}
}
