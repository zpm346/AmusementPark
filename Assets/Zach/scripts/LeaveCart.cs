using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveCart : MonoBehaviour {

	[SerializeField]
	private string cartLeavePoint;
	public string CartLeavePoint
	{
		get { return cartLeavePoint; }
		set { cartLeavePoint = value; }
	}
		
	void OnTriggerStay(Collider other)
	{
		GameObject spawn = GameObject.Find(cartLeavePoint);
		Vector3 spawnLocation = spawn.transform.position;
		if(other.gameObject.CompareTag("Player"))
		{
			other.gameObject.transform.position = spawnLocation;
		}
	}

}
