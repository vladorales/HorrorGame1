using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
        GameObject[] doors;
        doors =
       GameObject.FindGameObjectsWithTag("Door");
        if (doors[0])
        {
            {
                DestroyKEY();
            }
        }
        else
        {
            return;
        }

       void DestroyKEY(){
            Destroy(gameObject, 1f);
        }
    }
}
