﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cart : MonoBehaviour {

	public Transform[] targets;
	public float speed;
	public float rotationSpeed;
	private int current = 0;
	private int audioActivator = 0;
	public AudioSource audio;
	public bool rideIsActive = true;
	public Transform cartPosition;

	public GameObject steamVRCamera;
	public GameObject simulatorCamera;
		
	void Start () {
		simulatorCamera = GameObject.Find ("VRSimulatorCameraRig");
		steamVRCamera = GameObject.Find ("[CameraRig]");
	}

	void Update() {
		if (rideIsActive == false) {
			if (transform.position != targets [current].position) {
				float step = speed * Time.deltaTime;

				float rotationStep = rotationSpeed * Time.deltaTime;

				//works but does both parts separately
				var targetRotation = Quaternion.LookRotation (targets [current].position - transform.position);
				transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotationStep);
				if (steamVRCamera != null) {
					steamVRCamera.transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotationStep);
					steamVRCamera.transform.position = Vector3.MoveTowards (cartPosition.position, transform.position, step);
					if (current >= (targets.Length))
						steamVRCamera.transform.LookAt (targets [0]);
				}
				if (simulatorCamera != null) {
					simulatorCamera.transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotationStep);
					simulatorCamera.transform.position = Vector3.MoveTowards (cartPosition.position, transform.position, step);
					if (current >= (targets.Length))
						simulatorCamera.transform.LookAt (targets [0]);
				}
				Vector3 newPosition = Vector3.MoveTowards (transform.position, targets [current].position, step);
				//works but is an instant snap to the next target
				//transform.LookAt (targets [current]);
				if (current >= (targets.Length))
					transform.LookAt (targets [0]);

				GetComponent<Rigidbody> ().MovePosition (newPosition);
			} else {
				if(current < (targets.Length - 1))
					current = (current + 1) /*% targets.Length*/;
			}
		} else {
			//Debug.Log ("The RideIsActive boolean is " + rideIsActive);
		}
	} 

	void OnTriggerStay(Collider cart){
		if (cart.gameObject.CompareTag ("Player")) {
			rideIsActive = false;
			if (audioActivator == 0) {
				audio.Play ();
				audioActivator++;
			}
		}
	}

	void OnTriggerExit(Collider cart){
		if (cart.gameObject.CompareTag ("Player")) {
			rideIsActive = true;
			if (cart.attachedRigidbody)
				cart.attachedRigidbody.useGravity = true;
			cart.attachedRigidbody.velocity = Vector3.zero;
			audio.Stop ();
			//Reset the cart to 0
			float step = speed * Time.deltaTime;
			float rotationStep = rotationSpeed * Time.deltaTime;
			var targetRotation = Quaternion.LookRotation (targets [0].position - transform.position);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotationStep);
			Vector3 newPosition = Vector3.MoveTowards (transform.position, targets [0].position, step);
		}
	}
}