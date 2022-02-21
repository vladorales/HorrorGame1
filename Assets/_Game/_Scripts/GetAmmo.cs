using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAmmo : MonoBehaviour
{
	public GameObject PlayerObject;
	public float ammoAmount = 10f;
    public Renderer box;

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
            Debug.Log("Refilling...");
            box.material.color = Color.red;
			PlayerObject.GetComponent<GunWithObject>().bulletAmmo += ammoAmount;
		}
		else
		{
			return;
		}
	}
}
