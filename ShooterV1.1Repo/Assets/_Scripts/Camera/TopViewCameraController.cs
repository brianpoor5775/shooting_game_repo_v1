﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewCameraController : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, transform.position.y, player.transform.position.z);
	}
}
