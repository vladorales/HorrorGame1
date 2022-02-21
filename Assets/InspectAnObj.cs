using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectAnObj : MonoBehaviour
{
    public Transform dest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    }

    public void Pickedup()
    {
        Debug.Log("PickingUP");
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = dest.position;
        this.transform.parent = GameObject.Find("PickUpBox");
    transform.Rotate(Vector3.right * Time.DeltaTime);
    }

    public void Inventory()
{
    //place PF in inventory
    
}
}