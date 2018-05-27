using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoPyramid : MonoBehaviour {

	[SerializeField]
	private string pyramidSpawn;
	public string PyramidSpawn
	{
		get { return pyramidSpawn; }
		set { pyramidSpawn = value; }
	}
		
	void OnTriggerEnter(Collider other)
	{
		GameObject spawn = GameObject.Find(pyramidSpawn);
		Vector3 spawnLocation = spawn.transform.position;
		if(other.gameObject.CompareTag("Player"))
		{
			other.gameObject.transform.position = spawnLocation;
		}
	}

}
