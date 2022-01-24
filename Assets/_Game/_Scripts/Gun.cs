using UnityEngine;

public class Gun : MonoBehaviour
{
	// Start is called before the first frame update
	public float damage = 10f;
	public float range = 100f;
	public float fireRate = 15f;
	public float impactForce = 30f;

	[SerializeField] Camera fpsCam;
	public ParticleSystem MuzzleFlash;
	public GameObject impactEffect;

	private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
		if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)

		{
			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot();
			
		}
    }
	void Shoot()
	{
		MuzzleFlash.Play();
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);

			S_Target target = hit.transform.GetComponent<S_Target>();
			if (target != null)
			{
				target.TakeDamage(damage);
			}

			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForce(-hit.normal * impactForce);
			}

			GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO, 2f);
		}
	}
}
