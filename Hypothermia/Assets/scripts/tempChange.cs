using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempChange : MonoBehaviour {
    public float stillLose = 0.1f;
    public float movingLose = 0.05f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!playerController.moving)
            char_tempreture.temp -= stillLose;
        else
            char_tempreture.temp -= movingLose;

        if(char_tempreture.temp<=0){
            playerController.isAlive = false;
        }
	}
}
