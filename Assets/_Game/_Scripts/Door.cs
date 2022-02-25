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

    void OnTriggerEnter()
    {

        GameObject[] keys;

        keys =
        GameObject.FindGameObjectsWithTag("Key");

        if (keys[1])
        {
            {
                OpenDoor();
            }
        }
        else
        {
            return;
        }
        }

        void OpenDoor()
        {
        Debug.Log("keyfound");
            chain.SetActive(false);
            anim.SetBool("hasKey", true);
        KeyFunction key
        = gameObject.GetComponent<KeyFunction>();
        key.DestroyKEY();
        }
    }

