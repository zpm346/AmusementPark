using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleToSlide : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        GameObject spawn = GameObject.Find("Cabana 1");
        Vector3 spawnLocation = spawn.transform.position;
        if (other.gameObject.CompareTag("Player"))
        {            
            spawnLocation.y = -102;
            other.gameObject.transform.position = spawnLocation;
            other.gameObject.transform.eulerAngles = new Vector3(
                other.gameObject.transform.eulerAngles.x,
                other.gameObject.transform.eulerAngles.y + 180,
                other.gameObject.transform.eulerAngles.z);
        }
    }
}
