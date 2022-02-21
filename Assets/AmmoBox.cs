using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public GunWithObject gunWithObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //something something make bullet count back to 30

    void OnTriggerEnter()
    {
        Debug.Log("Collision");
        if(gunWithObject.bulletsEmpty == true)
        {
            gunWithObject.Refill();
        }
    }

   
}
