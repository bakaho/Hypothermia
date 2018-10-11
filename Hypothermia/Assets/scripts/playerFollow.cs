using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollow : MonoBehaviour {
    public Transform PlayerTransform;
    private Vector3 cameraOffset;
    public bool LookAtPlayer = false;


    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

	// Use this for initialization
	void Start () {
        cameraOffset = transform.position - PlayerTransform.position;

		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 newPos = PlayerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        if (LookAtPlayer)
            transform.LookAt(PlayerTransform);
	}
}
