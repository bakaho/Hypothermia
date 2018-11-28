using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNightShift : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(10, 0, 0) * Time.deltaTime);
        if (this.transform.rotation.eulerAngles.x > 170 || this.transform.rotation.x<-30){
            print("here");
            this.transform.Rotate(new Vector3(50, 0, 0) * Time.deltaTime);
        }
            

	}
}
