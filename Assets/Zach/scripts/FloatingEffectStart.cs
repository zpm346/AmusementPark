using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEffectStart : MonoBehaviour {
	
	public Transform cloudSpawn;
	public GameObject clouds;
	public GameObject cloudSpawnObj;
	public AudioSource audioToStop;
	public Transform parentObject;

	void OnTriggerStay(Collider playerEnter) {
		if (playerEnter.gameObject.tag == "Player")
			audioToStop.Stop ();
	}

	void OnTriggerEnter(Collider player) {
		if (player.gameObject.tag == "Player") {
			cloudSpawnObj = (GameObject)Instantiate (clouds, cloudSpawn.position, cloudSpawn.rotation);
			cloudSpawnObj.transform.SetParent (parentObject);
		}
	}

}
