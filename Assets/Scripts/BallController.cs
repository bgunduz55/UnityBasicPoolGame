using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public GameObject movementCntrlr;
	// public VolumeController volumeController;
	private bool redHit;
	private bool yellowHit;
	private MovementController movementScript;
	private bool canScore = true;
	// Use this for initialization
	void Start () {
		movementScript = movementCntrlr.GetComponent<MovementController>();
		redHit = false;
		yellowHit = false;
		canScore = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col){
		// When hit any object called this
		if(canScore && col.transform.tag == "RedBall") {
			// If hitted object is redBall then redhit is true
			redHit = true;
			if(yellowHit) {
				// If already hitted other ball then increase score and clear hit values
				movementScript.score += 1;
				ClearHit();
			}
		} else if(canScore && col.transform.tag == "YellowBall") {
			// If hitted object is yellowBall then redhit is true
			yellowHit = true;
			if(redHit) {
				// If already hitted other ball then increase score and clear hit values
				movementScript.score += 1;
				ClearHit();
			}
		}
		// Debug.Log(col.relativeVelocity.magnitude);
		movementCntrlr.GetComponent<MovementController>().PlayAudio(1,col.relativeVelocity.magnitude);
	}

	public void ClearHit() {
		redHit = yellowHit = false;
	}
	public void changeCanScore(bool _canScore) {
		canScore = _canScore;
	}
	public void resetValues() {
		// Reset varables to Start values
		redHit = false;
		yellowHit = false;
	}
}
