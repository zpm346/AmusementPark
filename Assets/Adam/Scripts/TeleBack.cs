using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleBack : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        GameObject spawn = GameObject.Find("EndWater");
        Vector3 spawnLocation = spawn.transform.position;
        if (other.gameObject.CompareTag("Player"))
        {            
            other.gameObject.transform.position = spawnLocation;
        }
    }
}
