using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletSpawn : MonoBehaviour {

	//Shot Variables
	public GameObject shot;
	public float shotSpeed;
	public float shotDamage;
	public float shotLifetime;

	//Shot Spawning Variables
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;


	// Scene initialization
	void Start () {
		//Debug.Log (shotAccelerator.speed);
		
	}


	// Update is called once per frame
	void Update () {

		if (Time.time > nextFire){
			nextFire = Time.time + fireRate;
			GameObject bulletClone = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			BulletAccelerator bulletAccelerator = bulletClone.gameObject.GetComponent<BulletAccelerator> ();
			bulletAccelerator.initialize (shotSpeed, shotLifetime, shotDamage);
		}
	}
}
