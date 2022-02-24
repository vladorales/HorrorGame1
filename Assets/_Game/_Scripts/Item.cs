using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    protected Vector3 pos;
    public Camera uiCam;
    public Transform Inventory;
    float speed = 10f;
    public GameObject Key;
   // public Transform pickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //  Destroy(gameObject, 1f);
            Debug.Log("transfered");
            Key.transform.parent = Inventory;
            Key.transform.rotation = Inventory.transform.rotation;
            Key.transform.position = Inventory.transform.position;
            this.gameObject.SetActive(false);
        }
    }

    public void PickedUp()
    {
        //Debug.Log("pickedup");
        //this.transform.position = pickup.position;
        //this.transform.parent = pickup;
    }
}
