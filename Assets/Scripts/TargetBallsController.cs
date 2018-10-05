using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBallsController : MonoBehaviour {

	public GameObject movementCntrlr;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetButtonDown("Jump"))
            {
                Stop();
            }
	}
	void OnCollisionEnter(Collision col){
		// When hit any object called this
		movementCntrlr.GetComponent<MovementController>().PlayAudio(1,col.relativeVelocity.magnitude);
	}

	public void Stop()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
