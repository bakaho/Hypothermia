﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderPos : MonoBehaviour {
    public Image tempslider;
    private void Start()
    {
        tempslider = GameObject.FindWithTag("sliderEner").GetComponent<Image>();
    }
	// Update is called once per frame
	void Update () {
        if (playerController1.showBar)
        {
            Vector3 sldPos = Camera.main.WorldToScreenPoint(this.transform.position);
            tempslider.transform.position = sldPos;
        }
		
	}
}
