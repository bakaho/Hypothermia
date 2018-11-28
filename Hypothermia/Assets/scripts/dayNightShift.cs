using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class dayNightShift : MonoBehaviour {

    // Update is called once per frame
    //public override void OnStartServer()
    //{
    //}
	void Update () {
        this.transform.Rotate(new Vector3(10, 0, 0) * Time.deltaTime);
        if (this.transform.rotation.eulerAngles.x > 170 || this.transform.rotation.eulerAngles.x<-30){
            print("here");
            this.transform.Rotate(new Vector3(50, 0, 0) * Time.deltaTime);
        }
	}
}
