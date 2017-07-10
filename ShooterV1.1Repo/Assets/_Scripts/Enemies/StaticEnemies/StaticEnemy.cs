using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour {
	//Enemy variables
	public float health;

	//Object movement
	public float rotSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Rotates object
		gameObject.transform.eulerAngles += new Vector3 (0f, rotSpeed, 0f);
	}
		
	void OnTriggerEnter(Collider col){
		
		//PBullet Detection
		if (col.gameObject.tag == "PBullet") {
			Destroy (col.gameObject);
			health -= 1;
		}

		//Destroy object if health <= 0
		if (health <= 0) {
			Destroy (this.gameObject);
		}

	}
}
