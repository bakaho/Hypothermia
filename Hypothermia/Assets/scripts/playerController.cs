using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    public float speed = 5.0f;
    public float rotateSpeed = 240.0f;
    private CharacterController character_Controller;
    private float gravity = 20.0f;
    private Vector3 moveDir = Vector3.zero;
    public static bool moving;

	// Use this for initialization
	void Start () {
        //character_Controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);

        bool move = (v != 0) || (h != 0);
        moving = (v != 0);

        moveDir = Vector3.forward * -v;
        moveDir = transform.TransformDirection(moveDir);
        moveDir *= speed;

        moveDir.y -= gravity * Time.deltaTime;
        Vector3 newPos = transform.position + moveDir * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(newPos);
		
	}
}
