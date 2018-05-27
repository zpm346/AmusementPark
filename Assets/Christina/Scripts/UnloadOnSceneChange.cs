using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloadOnSceneChange : MonoBehaviour {
	Scene[] scenes;

	// Use this for initialization
	void Start () {
		scenes = SceneManager.GetAllScenes ();
	}

	// Update is called once per frame
	void Update () {
		bool mySceneIsLoaded = false;

		foreach (Scene s in scenes) {
			if (s.name == "Christina") {
				mySceneIsLoaded = true;
			}
		}

		if (!mySceneIsLoaded)
			Object.Destroy (gameObject);
	}
}
