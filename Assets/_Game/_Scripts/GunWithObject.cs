using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunWithObject : MonoBehaviour
{
    [Header("BulletLifetime")]
    public float damage = 10f;
	public float range = 100f;
    public float impactForce = 30f;
    public float bulletSpeed = 30f;
    public float lifeTime = 3;

    [Header("BulletStats")]
    public float fireRate = 15f;
    public float reloadTime = 5f;
    public int currentAmmo = 10; //what's in gun rn max 10
	
    public int maxAmmo = 30; //mag dump or whatever
	public Text bulletCount;
	public bool bulletsEmpty = false;

    [Header("Effects and Cam")]
	public Camera PlayerCam;
	public ParticleSystem MuzzleFlash;
	public GameObject BulletPrefab;
	public Transform bulletSpawn;
	public Animator GunAnim;

	private float nextTimeToFire = 0f;
	// Update is called once per frame
	void Update()
	{

     
        //update bullet count
        bulletCount.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
		GetGunInput();

        if (Input.GetKeyUp(KeyCode.R))
        {
            Debug.Log("Reloading");
            //check if reload
            if (currentAmmo < 1 && maxAmmo > 1)
            {
                bulletsEmpty = true;
                StartCoroutine(Reload());

            }
        }
    }

	private void GetGunInput()
	{
		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)	
		{
			StartCoroutine(GunAnimationWaiting());
			
			if (currentAmmo > 0)
			{
				nextTimeToFire = Time.time + 1f / fireRate;
				Shoot();
				currentAmmo--;
			}
			else
			{
				return;
				
			}
           

		}
		
	}

	private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
	{
		yield return new WaitForSeconds(delay);

		Destroy(bullet);
	}
	void Shoot()
	{
		MuzzleFlash.Play();
		GameObject bullet = Instantiate(BulletPrefab);
		Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
			bulletSpawn.parent.GetComponent<Collider>());
		bullet.transform.position = bulletSpawn.transform.position;
		Vector3 rotation = bullet.transform.rotation.eulerAngles;
		bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
		bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.transform.forward * bulletSpeed, ForceMode.Impulse);
		StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));

		
	}
	 IEnumerator GunAnimationWaiting()
	{
		GunAnim.SetBool("isFiring", true);
		yield return new WaitForSeconds(1f);
		GunAnim.SetBool("isFiring", false);
	}

    //take ten from mag add to current
   public IEnumerator Reload()
    {
        Debug.Log("Reload");
        yield return new WaitForSeconds(reloadTime);
        
        if(currentAmmo != 10)
        {
            maxAmmo = maxAmmo - 10;
            currentAmmo = currentAmmo + 10;
        }
    }
}

