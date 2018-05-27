using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class PinballExit : MonoBehaviour {

	public GameObject pinball;

	private GameObject player;
	private Vector3 pinball_location;
	private GameObject entry;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
		entry = GameObject.Find("OrbEntry");
	}


	void OnTriggerEnter(Collider cartEntry){

		if(cartEntry.gameObject.CompareTag("Respawn"))
		{
			entry.GetComponent<PinballEntry>().ridePinball = false;
			pinball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
			player.GetComponent<CapsuleCollider>().enabled = true;
			player.GetComponent<VRTK_BodyPhysics>().enableBodyCollisions = true;
			pinball.transform.localPosition = new Vector3(10f, 12.5f, -6f);

		}
	}
		



}
