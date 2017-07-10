using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAccelerator : MonoBehaviour {

	//Private Variables
	private float speed;
	public void setSpeed(float speed){	this.speed = speed;	}

	private float lifetime;
	public void setLifetime(float lifetime){	this.lifetime = lifetime;	}

	private float damage;
	public void setDamage(float damage){	this.damage = damage;	}
	public float getDamage(){	return damage;	}

	//Physics Variables
	private Rigidbody rb;

	//Object Initialization
	public void initialize(float speed, float lifetime, float damage){
		this.speed = speed;
		this.lifetime = lifetime;
		this.damage = damage;
	}

	//Scene Initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
		StartCoroutine ("destroyTime");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Coroutine - Destroys object after <lifetime> seconds
	IEnumerator destroyTime (){
		yield return new WaitForSeconds (lifetime);
		Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider col){
		//Debug.Log ("blah");
		if (col.gameObject.tag == "Wall") {
			Destroy (this.gameObject);
		}
	}
}
