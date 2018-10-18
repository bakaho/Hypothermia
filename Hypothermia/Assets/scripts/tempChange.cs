using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class tempChange : MonoBehaviour {
    public float stillLose = 0.1f;
    public float movingLose = 0.05f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if moving,changing speed is slow if stay still, change faster
        if(!playerController.moving)
            char_tempreture.temp -= stillLose;
        else
            char_tempreture.temp -= movingLose;

        //if no tempreture, die
        if(char_tempreture.temp<=0){
            playerController1.isAlive = false;
        }
	}
}
