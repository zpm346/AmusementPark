using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MummySound : MonoBehaviour {

	public AudioSource audio;

	void OnTriggerEnter(Collider player) {
		if (player.gameObject.tag == "Player") {
			audio.Play ();
		}
	}
}
