using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private bool isTeleporting = false;
    public bool IsTeleporting
    {
        get { return isTeleporting; }
        set { isTeleporting = value; }
    }

    // Use this for initialization
    void Start()
    {
        Debug.Log("Test");
    }

    // Update is called once per frame
    void Update()
    {

    }

}