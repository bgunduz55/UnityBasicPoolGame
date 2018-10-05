using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

	bool isReplaying = false;

	public float recordTime = 10f;
	public GameObject mainBall;
	private Rigidbody mainRb;
	List<PointInTime> pointsInTime;
	Rigidbody rb;
	public bool letReplay = false;
	public bool startRecord = false;
	public GameObject movementController;
	// Use this for initialization
	void Start () {
		mainRb = mainBall.GetComponent<Rigidbody>();
		letReplay = false;
		startRecord = false;
		pointsInTime = new List<PointInTime>();
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Jump")){
			DeleteRecord();
			startRecord = true;
		} else if (mainRb.velocity  == Vector3.zero) {
			startRecord = false;
		}
		if (letReplay)
			StartReplay();
		if (Input.GetKeyUp(KeyCode.Return))
			StopReplay();
	}

	void FixedUpdate ()
	{
		if (isReplaying)
			Replay();
		else if (startRecord)
			Record();
		
	}

	void Replay ()
	{
		if (pointsInTime.Count > 0)
		{
			PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
			pointsInTime.RemoveAt(0);
		} else
		{
			StopReplay();
		}
		
	}

	void Record ()
	{
		if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			
			pointsInTime.RemoveAt(0);
		}
		pointsInTime.Insert(pointsInTime.Count, new PointInTime(transform.position, transform.rotation));
	}
	void DeleteRecord() {
		Debug.Log("Cleared");
		pointsInTime.Clear();
	}

	public void StartReplay ()
	{
		movementController.GetComponent<MovementController>().playable = false;
		letReplay = true;
		isReplaying = true;
		rb.isKinematic = true;
	}

	public void StopReplay ()
	{
		movementController.GetComponent<MovementController>().playable = true;
		letReplay = false;
		isReplaying = false;
		rb.isKinematic = false;
		DeleteRecord();
	}
}
