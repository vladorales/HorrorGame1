using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blob : MonoBehaviour
{

    [Header("Recognition")]

    public GameObject self;
    public Transform itemCheck;
    public float vibeCheck;

    [Header("Other Settings")]
    public Transform player;
    Transform enemyTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = this.gameObject.transform.localScale.x;
        float y = this.gameObject.transform.localScale.y;
        float z = this.gameObject.transform.localScale.z;
        this.transform.LookAt(player);
        vibeCheck = Vector3.Distance(self.transform.position, itemCheck.transform.position);

        transform.localScale = new Vector3(x + 0.0001f, y + 0.0001f, z + 0.0001f);
    }



    public void Damaged()
    {
        //shrinks this guy
        float x = this.gameObject.transform.localScale.x;
        float y = this.gameObject.transform.localScale.y;
        float z = this.gameObject.transform.localScale.z;
        //Damaged.Play();
        transform.localScale = new Vector3(x * 0.09f, y * 0.09f, z * 0.09f);

        if (x < 0.9)
        {
            Destroy(gameObject);
        }
    }
}