using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    protected Vector3 pos;
    
    
    float speed = 15f;
    
    public ParticleSystem Feedback;
   // public Transform pickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * speed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
			KeyFunction keyFunc = other.gameObject.GetComponent<KeyFunction>();
			keyFunc.AddToKey();
			Destroy(gameObject);
        }
    }
}
