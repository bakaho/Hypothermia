﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class playerController1 : NetworkBehaviour {
    //player basic settings for moving
    public float speed = 2.0f;
    public float rotateSpeed = 240.0f;
    private CharacterController character_Controller;
    private float gravity = 20.0f;
    private Vector3 moveDir = Vector3.zero;
    public static bool moving;
    public static bool isAlive = true;

    public myJoystick joystick;
    public static bool showBar = true; 
    public static Transform PlayerTransform;

    public static String themePuz = "pGrass";

    public GameObject[] puzPrefabs;
    public String[] themeSet = { "pGrass", "pWall" ,"pChair"};

    //public GameObject tombPrefab;
    //public static bool needTomb = false;


    //camera following
    public Transform CameraTransform;
    private Vector3 cameraOffset;
    private Vector3 rotationOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;



    //player interaction
    public float tempAdd = 0.02f;
    //public int[] timer = new int[20];
    //public int timer = new int[20];
    List<int> timer = new List<int>();
    List<int> met = new List<int>();
    public float theForce = 50f;
    private float dist;

    static Animator anim;




	void Start () {
        //check if local
        if(!isLocalPlayer){
            showBar = false;
            return;
        }

        //connect to joystick
        joystick = GameObject.FindWithTag("joystick").GetComponent<myJoystick>();
        showBar = true;

        //initialization of camera
        CameraTransform = GameObject.FindWithTag("MainCamera").transform;
        cameraOffset = CameraTransform.transform.position - new Vector3(0f, 0f, 0f);

        anim = GetComponent<Animator>();


        //transform.position

	}

    // Update is called once per frame
    void Update()
    {
        //check if local
        if(!isLocalPlayer){
            return;
        }  
        if (isAlive) {

            //initial info
            float h = joystick.Horizontal();
            float v = joystick.Vertical();
            transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);

            bool move = (v != 0) || (h != 0);
            moving = move;

            //set moving data
            moveDir = Vector3.zero;
            moveDir.x = speed * h * Time.deltaTime;
            moveDir.z = speed * v * Time.deltaTime;

            //turn to face forward
            if (move)
            {
                Vector3 movement = new Vector3(-h, 0.0f, -v);
                transform.rotation = Quaternion.LookRotation(-movement);
                anim.SetBool("isWalking", true);
            }else{
                anim.SetBool("isWalking", false);
            }



            Vector3 newPos = transform.position + moveDir;
            GetComponent<Rigidbody>().MovePosition(newPos);


            //camera following
            Vector3 newCamPos = transform.position + cameraOffset;
            CameraTransform.position = Vector3.Slerp(CameraTransform.position, newCamPos, smoothFactor);
            //CameraTransform.LookAt(PlayerTransform);

            //camera rotation
            //Quaternion toRot;
            //Quaternion curRot;
            //if (move)
            //{
            //     toRot = Quaternion.LookRotation(transform.position - CameraTransform.position, transform.up);
            //     curRot = Quaternion.Slerp(CameraTransform.rotation, toRot, 10 * Time.deltaTime);

            //}
            //CameraTransform.rotation = curRot;


            //interaction
            GameObject[] players;
            //search for all of the players
            players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject thePlayer in players)
            {
                //and the new comer to the list of met players
                if (met.FindIndex(i => i == thePlayer.GetInstanceID()) == -1)
                {
                    met.Add(thePlayer.GetInstanceID());
                    timer.Add(0);
                }

                //calculate distance between
                dist = Vector3.Distance(transform.position, thePlayer.transform.position);

                //if too close, calculate time
                if (dist < 2 && dist > 0)
                {

                    timer[met.FindIndex(i => i == thePlayer.GetInstanceID())] += 1;

                    print("close");
                    char_tempreture.temp += tempAdd;

                }

                //if too close for some time
                if (timer[met.FindIndex(i => i == thePlayer.GetInstanceID())] > 200 && dist < 5 && dist > 0)
                {
                    print("too long");
                    //add force to bounce back
                    GetComponent<Rigidbody>().AddForce(((transform.position - thePlayer.transform.position).normalized) * theForce);

                    //if try to deny the force, decrease energy
                    char_energy.energy -= 0.5f;
                }

                //if far enough, decrease 'close time'
                if (timer[met.FindIndex(i => i == thePlayer.GetInstanceID())] > 0 && dist > 30)
                {
                    timer[met.FindIndex(i => i == thePlayer.GetInstanceID())]--;
                    print(timer[met.FindIndex(i => i == thePlayer.GetInstanceID())]);

                }
            }

        }
        //if(needTomb){
        //    buildTomb();
        //}
		
	}


    public override void OnStartLocalPlayer()
    {
        //set the local players skin to differ ot from other characters
        //GetComponent<MeshRenderer>().material.color = Color.grey;

    }

    //check trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("buttonPuz"))
        {
            other.gameObject.transform.position = other.gameObject.transform.position - new Vector3(0, other.gameObject.transform.position.y + 1.8f, 0);

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("buttonPuz"))
        {
            other.gameObject.transform.position = other.gameObject.transform.position - new Vector3(0, other.gameObject.transform.position.y+1.8f, 0);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("buttonPuz"))
        {
            other.gameObject.transform.position = other.gameObject.transform.position - new Vector3(0, other.gameObject.transform.position.y + 1.5f, 0);
        }
    }



    //public void buildTomb(){
    //    Vector3 spawnPos = transform.position;
    //    Quaternion spawnRot = Quaternion.Euler(0f, 0f, 0f);
    //    GameObject tomb = (GameObject)Instantiate(tombPrefab, spawnPos, spawnRot);
    //    NetworkServer.Spawn(tomb);
    //    needTomb = false;
    //}
}
