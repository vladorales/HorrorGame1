using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFunction : MonoBehaviour
{
    public GameObject[] doors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void DestroyKEY()
    {
        Debug.Log("DestroyingKey");
        Destroy(gameObject, 1f);
    }
}
