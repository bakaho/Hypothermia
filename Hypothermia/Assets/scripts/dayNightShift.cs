﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNightShift : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(50, 0, 0) * Time.deltaTime);
		
	}
}
