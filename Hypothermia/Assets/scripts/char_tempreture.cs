using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class char_tempreture : MonoBehaviour {
    
    Image tempBar;
    float maxTemp = 500f;
    public static float temp;


	// Use this for initialization
	void Start () {
        tempBar = GetComponent<Image>();
        temp = maxTemp;		
	}
	
	// Update is called once per frame
	void Update () {
        //show bar length
        tempBar.fillAmount = temp / maxTemp;
		
	}
}
