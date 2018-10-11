using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderPos : MonoBehaviour {
    public Image tempslider;
	
	// Update is called once per frame
	void Update () {
        Vector3 sldPos = Camera.main.WorldToScreenPoint(this.transform.position);
        tempslider.transform.position = sldPos;
		
	}
}
