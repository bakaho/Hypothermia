using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class char_tempreture1 : MonoBehaviour {
    Image tempBar;
    float maxTemp = 100f;
    public static float temp;
	// Use this for initialization
	void Start () {
        tempBar = GetComponent<Image>();
        temp = maxTemp;
		
	}
	
	// Update is called once per frame
	void Update () {
        tempBar.fillAmount = temp / maxTemp;
		
	}
}
