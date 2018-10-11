using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollow : MonoBehaviour {
    public Transform PlayerTransform;
    public Transform CameraTransform;
    private Vector3 cameraOffset;
    private Vector3 rotationOffset;
    public bool LookAtPlayer = false;


    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

	// Use this for initialization
	void Start () {
        cameraOffset = transform.position - PlayerTransform.position;
        //rotationOffset = transform.rotation - PlayerTransform.rotation;

		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 newPos = PlayerTransform.position + cameraOffset;
        //Quaternion rotation = Quaternion.Euler(transform.rotation.x, PlayerTransform.rotation.y,transform.rotation.z);
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10);
    
        if (LookAtPlayer)
            transform.LookAt(PlayerTransform);
	}
}
