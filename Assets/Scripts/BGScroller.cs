﻿using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {
	public float scrollSpeed;
	public float scrollSize;

	private Vector3 startPosition;

	void Start(){
		startPosition = this.transform.position;
	}
	void Update(){
		float positionChange = Mathf.Repeat (Time.time * scrollSpeed, scrollSize);
		this.transform.position = startPosition + Vector3.forward * positionChange;
	}
	//public float scrollSpeed;
	//public float tileSizeZ;
	
	//private Vector3 startPosition;
	
	//void Start ()
	//{
	//	startPosition = transform.position;
	//}
	
	//void Update ()
	//{
	//	float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
	//	transform.position = startPosition + Vector3.forward * newPosition;
	//}
}
