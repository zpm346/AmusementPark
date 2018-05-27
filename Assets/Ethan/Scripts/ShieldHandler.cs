using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHandler : MonoBehaviour {

    //GameHandler game;

    private void Awake()
    {
        //game = GameObject.Find("GameHandler").GetComponent<GameHandler>() as GameHandler;
    }

    void OnCollisionEnter(Collision c)
    {
        //game.AddPoint();
        //Debug.Log("Score: " + game.GetScore());
        if(c.gameObject.tag == "Arrow")
        {
            GetComponent<AudioSource>().Play();
        }
    }

}
