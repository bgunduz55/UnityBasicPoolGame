using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Vector3 _cameraOffset = new Vector3(0.0f, 9.5f, 7.0f);
    [Range(0.0f, 1.0f)]
    public float smoothFactor = 0.5f;
    public float rotationSpeed = 5.0f;
    public GameObject selectedBall;
    public GameObject menu;
    // Use this for initialization
    void Start()
    {
        _cameraOffset = new Vector3(0.0f, 9.5f, 7.0f);
        //_cameraOffset = transform.position - gameObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!menu.active)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * rotationSpeed, Vector3.up);
            Quaternion camTurnAngle2 = Quaternion.AngleAxis(Input.GetAxis("Vertical") * rotationSpeed, Vector3.left);
            _cameraOffset = camTurnAngle * camTurnAngle2 * _cameraOffset;
            Vector3 newPos = selectedBall.transform.position + _cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
            transform.LookAt(selectedBall.transform);
        }
    }
}
