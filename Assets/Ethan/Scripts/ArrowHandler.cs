using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHandler : MonoBehaviour {

    public float fadeTime = 2.5f;

    private Rigidbody _rb;

    //Init component references
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
		if( !Mathf.Approximately(GetVelocity().magnitude, 0) )
        {
            transform.LookAt(transform.position + _rb.velocity);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Check that the thing we collided with has a rigidbody
        if( collision.gameObject.GetComponent<Rigidbody>() )
        {
            //Create a fixed joint and connect it to the object we collided with
            FixedJoint joint = gameObject.AddComponent<FixedJoint>() as FixedJoint;
            joint.breakForce = Mathf.Infinity;
            joint.autoConfigureConnectedAnchor = true;  //joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();

            //Force the rigidbody to sleep for one frame so it doesn't shake on impact
            _rb.Sleep();

            //Enable this if arrows should collide with other arrows
            Destroy(GetComponent<BoxCollider>());

			//If it hit the player, trigger a damage noise
			/*
			if (collision.gameObject.tag == "Player") {
				collision.gameObject.GetComponent<AudioSource> ().PlayOneShot ();
			}*/

            //Destroy the object after a certain amount of time
            Destroy(gameObject, fadeTime);
        }
    }

    Vector3 GetVelocity()
    {
        return _rb.velocity;
    }

    public void AddForce(float force)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        _rb.AddForce(forward * force, ForceMode.Impulse);
    }
}
