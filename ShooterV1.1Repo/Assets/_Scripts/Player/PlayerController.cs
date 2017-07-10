using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	//~~~~~~~~~~~~~~~~~~Variables~~~~~~~~~~~~~~~//
	//Player movement variables
	CharacterController charController;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	//Shot initialization variables
	public GameObject shot;
	public float shotSpeed;
	public float shotDamage;
	public float shotLifetime;

	//Shot spawner
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	//Physics Variables
	public Rigidbody rb;

	//~~~~~~~~~~~~~~~~~~Methods~~~~~~~~~~~~~~~~~~//
	//Scene Initialization
	void Start () {
		charController = GetComponent<CharacterController>();
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Detects fire button
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject bulletClone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			BulletAccelerator bulletAccelerator = bulletClone.gameObject.GetComponent<BulletAccelerator> ();
			bulletAccelerator.initialize (shotSpeed, shotLifetime, shotDamage);
		}

		//Moves controller
		if (charController.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
			//moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
		charController.Move(moveDirection * Time.deltaTime);

		//Jump
		if (Input.GetButton("Jump"))
			moveDirection.y = jumpSpeed;

		//Rotates player
		if (Input.GetButton ("RotateHorizontal")|| Input.GetButton ("RotateVertical")) {
			float y = Input.GetAxis ("RotateHorizontal");
			float x = Input.GetAxis ("RotateVertical");
			float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg; 
			float temp = Mathf.LerpAngle (transform.eulerAngles.y, angle, 0.05f);
			transform.rotation = Quaternion.Euler(new Vector3(0, temp, 0));
			
		}

	}
}
