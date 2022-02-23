using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    [Header("Setup")]
    public Rigidbody projectile;
    public Transform barrelEnd;
    public AudioSource EnemyRocket;
    public ParticleSystem FireFeedback;
    public AudioSource JustGotHit;
   public float fireRate = 2f;
    float nextFire;
   
    [Header("Recognition")]
    
    public GameObject self;
    public GameObject itemCheck;
    public float vibeCheck;

    [Header("Other Settings")]
    public Transform player;
    Transform enemyTransform;

     void Start()
    {
        float nextFire = Time.time;
     
    }
    void Update()
    {

       this.transform.LookAt(player);
       vibeCheck = Vector3.Distance(self.transform.position, itemCheck.transform.position);


        if (vibeCheck < 50)
        {
            ShootEnemy();
        }

        void ShootEnemy()
        {
            if (Time.time > nextFire)
            {
                FireFeedback.Play();
                Debug.Log("enemy shooting");
                EnemyRocket.Play();
              Rigidbody projectileInstance;
              projectileInstance = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);
              projectileInstance.AddForce(barrelEnd.forward * 1000f);
                nextFire = Time.time + fireRate;
            }
        }
    }
    public void TakeDamage(int enemyDamageIntake)
    {
        //shrinks this guy
        float x = this.gameObject.transform.localScale.x;
        float y = this.gameObject.transform.localScale.y;
        float z = this.gameObject.transform.localScale.z;
        JustGotHit.Play();
        transform.localScale = new Vector3(x / 2, y / 2, z / 2);

        if (x < 0.9)
        {
            Destroy(gameObject);
        }
    }

}