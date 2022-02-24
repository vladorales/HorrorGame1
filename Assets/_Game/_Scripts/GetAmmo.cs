using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAmmo : MonoBehaviour
{
	public GameObject PlayerObject;
    public int ammoAmount = 10;
  //  public Renderer box;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.right * Time.deltaTime);

    }


	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
            Debug.Log("Refilling...");
         //   box.material.color = Color.red;
			PlayerObject.GetComponent<GunWithObject>().maxAmmo += ammoAmount;
            Destroy(gameObject, 2f);
		}
		else
		{
			return;
		}
	}
}
