using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject chain;
    public Animator anim;
    public GameObject[] keys;
  
    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			KeyFunction keyFunc = other.gameObject.GetComponent<KeyFunction>();
			if (keyFunc.numKey == 1)
			{
				OpenDoor();
				keyFunc.MinusKey();
			}
		}


	}

        void OpenDoor()
        {
        Debug.Log("keyfound");
            chain.SetActive(false);
            anim.SetBool("hasKey", true);
        
        
        }
    }

