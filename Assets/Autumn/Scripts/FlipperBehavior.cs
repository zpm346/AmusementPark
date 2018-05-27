using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using VRTK;


public class FlipperBehavior : MonoBehaviour {

	public GameObject flipperL;
	public GameObject flipperR;
	public float flipperSpeed = 2f;
	public AudioSource flip_noise;


	private float originalYLeft;
	private float originalYRight;
	private bool flippingLeft = false;
	private bool flippingRight = false;
	private Rigidbody orb;

	// Use this for initialization
	void Start () {
		originalYLeft = flipperL.transform.localRotation.y;
		originalYRight = flipperR.transform.localRotation.y;
		orb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
		


		//Left Flipper
		if( Input.GetMouseButtonDown(0) || GameObject.Find("LeftController").GetComponent<VRTK_ControllerEvents>().triggerClicked ){
			flippingLeft = true;
		}
		if(Input.GetMouseButtonUp(0)){
			flippingLeft = false;
			}

		if(flippingLeft)
		{
			flipperL.transform.localRotation = Quaternion.Slerp(flipperL.transform.localRotation, Quaternion.Euler(0, -45, 0),   flipperSpeed);
			//if()
		}
		if(!flippingLeft)
		{
			flipperL.transform.localRotation = Quaternion.Slerp(flipperL.transform.localRotation, Quaternion.Euler(0, 0, 0),  flipperSpeed);
		}


		//Right Flipper
		if( Input.GetMouseButtonDown(0) || GameObject.Find("RightController").GetComponent<VRTK_ControllerEvents>().triggerClicked ){
			flippingRight = true;
		}
		if(Input.GetMouseButtonUp(0)){
			flippingRight = false;
		}

		if(flippingRight)
		{
			flipperR.transform.localRotation = Quaternion.Slerp(flipperL.transform.localRotation, Quaternion.Euler(0, -45, 0),   flipperSpeed);
			//if()
		}
		if(!flippingRight)
		{
			flipperR.transform.localRotation = Quaternion.Slerp(flipperL.transform.localRotation, Quaternion.Euler(0, 0, 0),  flipperSpeed);
		}


		
	}

	void OnCollisionEnter (Collision col)
	{
		//Debug.Log(col.gameObject.name);
		if((col.gameObject.name == "Paddle L" || col.gameObject.name == "Paddle R") && (flippingLeft || flippingRight) )
		{
			orb.velocity = new Vector3(0, 0, 10);
			orb.AddForce(new Vector3(0f, 0f, 10f), ForceMode.Impulse);
			flip_noise.Play();
			Debug.Log("Velociy");
		}
	}




}
