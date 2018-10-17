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

	// Use this for initialization
	void Start () {
        //character_Controller = GetComponent<CharacterController>();
        if (!isLocalPlayer)
        {
            return;
        }
        joystick = GameObject.FindWithTag("joystick").GetComponent<myJoystick>();
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
        }
		
	}

	public override void OnStartLocalPlayer()
	{
        //GetComponent<>
        //base.OnStartLocalPlayer(){
            
        //}
	}
}
