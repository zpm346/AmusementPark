using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEffectStop : MonoBehaviour {

	public GameObject clouds;
	public AudioSource audioToStart;

	void OnTriggerEnter(Collider playerEnter) {
		if (playerEnter.gameObject.tag == "Player")
			audioToStart.Play ();
	}

	void OnTriggerStay(Collider player) {
		if (player.gameObject.tag == "Player") {
			clouds = GameObject.Find ("FloatingPlatform(Clone)");
			Destroy (clouds);
		}
	}

}
