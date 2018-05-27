using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartEntry : MonoBehaviour {

	public GameObject cart;


	[SerializeField]
	private string rideEntry;
	public string RideEntry
	{
		get { return rideEntry; }
		set { rideEntry = value; }
	}


	void OnTriggerEnter(Collider cartEntry){
		GameObject spawn = GameObject.Find(rideEntry);
		Vector3 spawnLocation = spawn.transform.position;
		if(cartEntry.gameObject.CompareTag("Player"))
		{
			if (cartEntry.attachedRigidbody)
				cartEntry.attachedRigidbody.useGravity = false;
			cartEntry.gameObject.transform.position = spawnLocation;
		}

	}
}
