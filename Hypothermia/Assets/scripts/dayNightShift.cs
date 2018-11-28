using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class dayNightShift : MonoBehaviour {
    public bool isNight = false;

    // Update is called once per frame
    //public override void OnStartServer()
    //{
    //}
	void Update () {
        this.transform.Rotate(new Vector3(10, 0, 0) * Time.deltaTime);
        if (this.transform.rotation.eulerAngles.x > 170 || this.transform.rotation.eulerAngles.x<-30){
            isNight = true;
            print("here");
            this.transform.Rotate(new Vector3(50, 0, 0) * Time.deltaTime);
        }else{
            isNight = false;
        }
        if(isNight){
            if(GetComponent<Light>().intensity > 0){
                GetComponent<Light>().intensity -= 0.05f;
            }
        }else{
            if (GetComponent<Light>().intensity < 1f)
            {
                GetComponent<Light>().intensity += 0.05f;
            }
        }
	}
}
