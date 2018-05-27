using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisFlameEvent : MonoBehaviour {

	public GameObject flameEffect;
	public Transform flameLocation1;

	void OnTriggerEnter(Collider player) {
		if (player.gameObject.tag == "Player") {
			GameObject tempFlame = (GameObject)Instantiate (flameEffect, flameLocation1.position, flameLocation1.rotation);
			StartCoroutine (DestroyClone (tempFlame));
		}
	}

	IEnumerator DestroyClone(GameObject temp) {
		yield return new WaitForSeconds (5);
		Destroy (temp);
	}
}
