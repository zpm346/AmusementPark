using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    //The amount of points the player has earned
    private int score = 0;

    //The time that the last arrow was fired
    private float lastShot;

    //Lock so that arrows aren't spammed
    private bool canShoot = true;

    [SerializeField]
    private List<GameObject> launchers;

    [SerializeField]
    private float drawDelay = 0.5f;

    [SerializeField]
    private float interval = 2f;

    [SerializeField]
    private float intervalRange = 1f;

    [SerializeField]
    private float arrowForce = 35f;

    [SerializeField]
    private float arrowForceRange = 5f;

	// Use this for initialization
	void Start ()
    {
        lastShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if( canShoot && TimeSinceLastShot() >= interval)
        {
            //Lock
            canShoot = false;

            //Shoot the arrow
            StartCoroutine( ShootArrow() );
        }
    }

    float TimeSinceLastShot()
    {
        return Time.time - lastShot;
    }

    IEnumerator ShootArrow()
    {
        //Find a launcher
        GameObject launcher = GetRandomLauncher();

        //Should we display some form of indicator on the screen?

        //Play bow draw sound
        launcher.GetComponent<LauncherHandler>().PlayDrawSound();

        //Small wait so the player can adjust and find where it came from.
        yield return new WaitForSeconds(Random.Range(drawDelay - .25f, drawDelay + .25f));

        //Play bow shot sound
        launcher.GetComponent<LauncherHandler>().PlayShootSound();

        //Spawn the arrow
        SpawnArrowAtLauncher(launcher, Random.Range(arrowForce - arrowForceRange, arrowForce + arrowForceRange));

        lastShot = Time.time;

        //Release lock
        canShoot = true;

        yield return null;
    }

    GameObject GetRandomLauncher()
    {
        return launchers[Random.Range(0, launchers.Count)];
    }

    GameObject SpawnArrowAtLauncher(GameObject launcher, float force)
    {
        GameObject arrow = Instantiate(Resources.Load("Arrow"), transform.parent.Find("Arrows"), true) as GameObject;
        arrow.name = "Arrow";
        arrow.tag = "Arrow";
        arrow.transform.position = launcher.transform.position;
        arrow.transform.rotation = launcher.transform.rotation;
        arrow.GetComponent<ArrowHandler>().AddForce( force );

        return arrow;
    }

    public int GetScore() { return score; }

    public void AddPoint(){ score++; }

    public void RemovePoint() { score--; }

    public void StartGame()
    {
        lastShot = Time.time;
    }

    public void Reset()
    {
        score = 0;
    }
}
