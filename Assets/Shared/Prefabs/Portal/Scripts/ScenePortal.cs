using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//Attach this script to an object that you wish to use as a portal to a different scene
public class ScenePortal : MonoBehaviour
{
    [SerializeField]
    private string targetScene;
    public string TargetScene
    {
        get { return targetScene; }
        set { targetScene = value; }
    }

    [SerializeField]
    private string spawnPoint;
    public string SpawnPoint
    {
        get { return spawnPoint; }
        set { spawnPoint = value; }
    }

    //private PlayerController pc = GameObject.Find("Player");

    private void Start()
    {
        
    }

    //Teleport the player to a position in a new scene
    private IEnumerator Teleport(GameObject go)
    {
        Debug.Log("Taking portal to " + targetScene);

        string oldScene = "";
        foreach(Scene s in SceneManager.GetAllScenes())
        {
            if(s.name != "vrtk_rigs")
            {
                oldScene = s.name;
            }
        }

		//Find the player
		GameObject player = GameObject.FindGameObjectWithTag("Player");
        
		player.transform.position = new Vector3(-100, -35, -50); //warps to center of temporary warp area
        SceneManager.LoadScene(targetScene, LoadSceneMode.Additive);
        Debug.Log("Loaded scene: " + targetScene);

        yield return null;

        SceneManager.UnloadSceneAsync(oldScene);
        Debug.Log("Unloading scene: " + oldScene);

        //Find the spawnPoint
        GameObject spawn = GameObject.Find(spawnPoint);

        //Loop until the spawnPoint is loaded into the game
        //Necessary because in the first few frames it is possible for the spawnpoint to be null
        while (spawn == null)
        {
            spawn = GameObject.Find(spawnPoint);
            yield return null;
        }

        //Get the spawn location
        Vector3 spawnLocation = spawn.transform.position;
        Debug.Log("Expected location: " + spawnLocation);

//        //Find the player
//        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //Set the player's position
        player.transform.position = spawnLocation;
        Debug.Log("Actual location: " + player.transform.position);

        yield break;
    }

    //Detect when the player enters the teleporter
    void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag("Player") || ObjectHasParent(other.transform, "Player"))
        {

            StartCoroutine(Teleport(other.gameObject));
        }
    }

	bool ObjectHasParent(Transform child, string tag)
	{
		Transform parent = child.parent;
		if (parent.tag == "Player")
			return true;
		
		while (parent.parent != null) {
			parent = parent.parent;
			if (parent.tag == "Player")
				return true;
		}
		return false;
	}
}
