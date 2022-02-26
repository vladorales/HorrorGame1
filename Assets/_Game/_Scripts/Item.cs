using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    protected Vector3 pos;
    public Camera uiCam;
    public Transform Inventory;
    float speed = 15f;
    public GameObject Key;
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
                Debug.Log("transfered");
                Key.transform.parent = Inventory;
                Key.transform.rotation = Inventory.transform.rotation;
                Key.transform.position = Inventory.transform.position;
            Feedback.Play();
            Destroy(gameObject, 1.5f);

        }
    }
}
