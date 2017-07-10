using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public float health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "EBullet") {
			BulletAccelerator bulletAccelerator = col.gameObject.GetComponent<BulletAccelerator> ();
			health -= bulletAccelerator.getDamage();
			Destroy (col.gameObject);
		}
		if (health <= 0){
			//YOU LOSE
		}
	}
}
