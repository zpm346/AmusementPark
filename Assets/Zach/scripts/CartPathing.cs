using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CartPathing : MonoBehaviour {

	public List<Transform> waypoints = new List<Transform>();
	int index = 0;
	public bool disableInGame;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
		if (!disableInGame) {
			Transform[] temp = GetComponentsInChildren<Transform> ();
			if (temp.Length > 0) {
				waypoints.Clear ();
				index = 0;
				foreach (Transform t in temp) {
					index++;
					t.name = "Way " + index.ToString ();
					waypoints.Add (t);
				}
			}
		}
	}

	void OnDrawGizmos()
	{
		if (waypoints.Count > 0) {

			Gizmos.color = Color.red;

			foreach (Transform t in waypoints)
				Gizmos.DrawSphere (t.position, 0.5f);

			Gizmos.color = Color.blue;

			for(int i = 0; i < waypoints.Count-1;i++)
				Gizmos.DrawLine(waypoints[i].position,waypoints[i+1].position);
		}
	}
}
