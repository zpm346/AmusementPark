using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class PinballEntry : MonoBehaviour {

	public GameObject pinball;
	public bool ridePinball = false;

	private GameObject player;
	private Vector3 pinball_location;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}


	void OnTriggerEnter(Collider cartEntry){
		
		if(cartEntry.gameObject.CompareTag("Player"))
		{
			ridePinball = true;
			pinball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			player.GetComponent<CapsuleCollider>().enabled = false;
			player.GetComponent<VRTK_BodyPhysics>().enableBodyCollisions = false;
		}
	}


	void Update(){
		if(ridePinball)
		{
			pinball_location = pinball.transform.position;

			//player.transform.position(new Vector3(pinball_location.x, pinball_location.y+1, pinball_location.z));
			player.transform.position = new Vector3(pinball_location.x, pinball_location.y + 3, pinball_location.z);
		}


	}



}
