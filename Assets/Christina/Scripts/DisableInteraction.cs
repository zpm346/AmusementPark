using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DisableInteraction : MonoBehaviour {
	VRTK_SnapDropZone headSnap;
	public GameObject SnowmanPart;

	void Start () {
		headSnap = transform.GetComponent<VRTK_SnapDropZone>();
	}

	void Update () {
		Collider collider = SnowmanPart.GetComponent<Collider> ();

		if (headSnap.GetCurrentSnappedObject () != null) {
			collider.enabled = false;
		} else {
			collider.enabled = true;
		}
	}
}