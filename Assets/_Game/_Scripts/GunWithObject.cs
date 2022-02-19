using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunWithObject : MonoBehaviour
{
	public float damage = 10f;
	public float range = 100f;
	public float fireRate = 15f;
	public float impactForce = 30f;
	public float bulletSpeed = 30f;
	public float lifeTime = 3;


	public float bulletAmmo = 30f;
	public Text bulletCount;

	public Camera PlayerCam;
	public ParticleSystem MuzzleFlash;
	public GameObject BulletPrefab;
	public Transform bulletSpawn;
	public Animator GunAnim;

	public float nextTimeToFire = 0f;
	// Update is called once per frame
	void Update()
	{
		bulletCount.text = "Ammo: " + bulletAmmo.ToString();
		GetGunInput();
	}

	private void GetGunInput()
	{
		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)	
		{
			StartCoroutine(GunAnimationWaiting());
			
			if (bulletAmmo > 0)
			{
				nextTimeToFire = Time.time + 1f / fireRate;
				
				Shoot();
				bulletAmmo--;
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
}

