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



    //---------------
    public float tempAdd = 0.02f;
    //public int[] timer = new int[20];
    //public int timer = new int[20];
    List<int> timer = new List<int>();
    List<int> met = new List<int>();
    public float theForce = 50f;

    private Vector3 moveForceDir;

    private float dist;






	// Use this for initialization
	void Start () {
        if(!isLocalPlayer){
            showBar = false;
            return;
        }


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
            float h = joystick.Horizontal();
            float v = joystick.Vertical();

            //if(Input.touchCount>0){
            //    Touch touch = Input.GetTouch(0);
            //    touch.position
            //}

            transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);

            bool move = (v != 0) || (h != 0);
            moving = move;

            moveDir = Vector3.zero;
            moveDir.x = speed * h * Time.deltaTime;
            moveDir.z = speed * v * Time.deltaTime;

            if (move)
            {
                Vector3 movement = new Vector3(-h, 0.0f, -v);
                transform.rotation = Quaternion.LookRotation(movement);
            }

            Vector3 newPos = transform.position + moveDir;
            GetComponent<Rigidbody>().MovePosition(newPos);


            Vector3 newCamPos = transform.position + cameraOffset;
            CameraTransform.position = Vector3.Slerp(CameraTransform.position, newCamPos, smoothFactor);




            GameObject[] players;
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject thePlayer in players)
            {
                if (met.FindIndex(i => i == thePlayer.GetInstanceID()) == -1)
                {
                    met.Add(thePlayer.GetInstanceID());
                    timer.Add(0);
                }
                dist = Vector3.Distance(transform.position, thePlayer.transform.position);
                if (dist < 2)
                {

                    timer[met.FindIndex(i => i == thePlayer.GetInstanceID())] += 1;

                    print("close");
                    char_tempreture.temp += tempAdd;



                }

                if (timer[met.FindIndex(i => i == thePlayer.GetInstanceID())] > 200 && dist < 5 && dist > 0)
                {
                    print("too long");
                    GetComponent<Rigidbody>().AddForce(((transform.position - thePlayer.transform.position).normalized) * theForce);
                    char_energy.energy -= 0.5f;
                }

                if (timer[met.FindIndex(i => i == thePlayer.GetInstanceID())] > 0 && dist > 30)
                {
                    timer[met.FindIndex(i => i == thePlayer.GetInstanceID())]--;
                    print(timer[met.FindIndex(i => i == thePlayer.GetInstanceID())]);

                }
            }


        }

		
	}

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.grey;


    }
}
