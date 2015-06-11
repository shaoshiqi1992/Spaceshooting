﻿using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}
public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Jump") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot,shotSpawn.position,shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody> ().velocity = movement * speed;
		GetComponent<Rigidbody> ().position = new Vector3 (Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax));
	}
}
