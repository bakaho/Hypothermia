using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempChange1 : MonoBehaviour {
    public float stillLose = 0.2f;
    public float movingLose = 0.05f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!anotherPlayer.moving)
            char_tempreture1.temp -= stillLose;
        else
            char_tempreture1.temp -= movingLose;
	}
}
