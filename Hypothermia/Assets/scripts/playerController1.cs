using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerController1 : NetworkBehaviour {
    public float speed = 5.0f;
    public float rotateSpeed = 240.0f;
    private CharacterController character_Controller;
    private float gravity = 20.0f;
    private Vector3 moveDir = Vector3.zero;
    public static bool moving;
    public static bool isAlive = true;
    public myJoystick joystick;
    public static bool showBar = true; 
    public static Transform PlayerTransform;



    //---------------
    public Transform CameraTransform;
    private Vector3 cameraOffset;
    private Vector3 rotationOffset;


    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;


	// Use this for initialization
	void Start () {
        if(!isLocalPlayer){
            showBar = false;
            return;
        }  
        //character_Controller = GetComponent<CharacterController>();
        joystick = GameObject.FindWithTag("joystick").GetComponent<myJoystick>();
        showBar = true;
        CameraTransform = GameObject.FindWithTag("MainCamera").transform;
        cameraOffset = CameraTransform.transform.position - transform.position;
        //transform.position = new Vector3(0, 1.2f, 0);
	}

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer){
            return;
        }  
        if (isAlive) { 
            //float h = Input.GetAxis("Horizontal");
            //float v = Input.GetAxis("Vertical");
            float h = joystick.Horizontal();
            float v = joystick.Vertical();

            //if(Input.touchCount>0){
            //    Touch touch = Input.GetTouch(0);
            //    touch.position
            //}

            transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);

            bool move = (v != 0) || (h != 0);
            moving = move;

            //moveDir = Vector3.forward * -v;
            //moveDir = transform.TransformDirection(moveDir);
            //moveDir *= speed;
            moveDir = Vector3.zero;
            moveDir.x = speed * h * Time.deltaTime;
            moveDir.z = speed * v * Time.deltaTime;
            //moveDir.y -= gravity * Time.deltaTime;

            if (move)
            {
                Vector3 movement = new Vector3(-h, 0.0f, -v);
                transform.rotation = Quaternion.LookRotation(movement);
            }

            Vector3 newPos = transform.position + moveDir;
            GetComponent<Rigidbody>().MovePosition(newPos);






            Vector3 newCamPos = transform.position + cameraOffset;
            CameraTransform.position = Vector3.Slerp(CameraTransform.position, newCamPos, smoothFactor);




        }

		
	}

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.grey;


    }
}
