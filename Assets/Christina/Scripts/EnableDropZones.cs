using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class EnableDropZones : MonoBehaviour {
	VRTK_SnapDropZone thisSnap;
	public GameObject[] otherSnaps;

	void Start() {
		thisSnap = transform.GetComponent<VRTK_SnapDropZone>();
	}

	void Update () {
		if (thisSnap.GetCurrentSnappedObject() == null) {
			foreach (GameObject obj in otherSnaps) {
				obj.SetActive (false);
			}
		} else {
			foreach (GameObject obj in otherSnaps) {
				obj.SetActive (true);
			}
		}
	}
}
