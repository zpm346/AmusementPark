using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCollision : MonoBehaviour {
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Player") {
			Physics.IgnoreCollision(col.collider, GetComponent<Collider>()); 
		}
	}
}
