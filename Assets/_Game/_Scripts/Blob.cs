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
    public GameObject[] Staples;

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

     void OnTriggerEnter(Collider other)
    {
        Debug.Log("DEATH");
        if(other.tag == "Player")
        {
            playerMovement player
                = other.gameObject.GetComponent<playerMovement>();
            player.Die();
        }

        if(other.tag == "bullet")
        {
            Staples =
            GameObject.FindGameObjectsWithTag("bullet");
            if (Staples[5])
            {
                Debug.Log("BLOB DEFEATED");
            }
        }
    }

    public void Damaged()
    {
        //shrinks this guy
        float x = this.gameObject.transform.localScale.x;
        float y = this.gameObject.transform.localScale.y;
        float z = this.gameObject.transform.localScale.z;
        //Damaged.Play();
        transform.localScale = new Vector3(x - 0.2f, y - 0.2f, z - 0.2f);

        if (x < 1)
        {
            Destroy(gameObject);
        }
    }
}