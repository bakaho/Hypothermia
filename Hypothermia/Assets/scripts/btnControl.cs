using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnControl : MonoBehaviour {
    Collider cld;
    GameObject[] stdPuzs;


	// Use this for initialization
	void Start () {
        cld = GetComponent<Collider>();
        stdPuzs = GameObject.FindGameObjectsWithTag("stadiumPuz");
	}
	
	// Update is called once per frame
	void Update () {
        if(cld.isTrigger == true){
            foreach (GameObject sp in stdPuzs){
                if (Mathf.Abs(sp.transform.position.z - (this.transform.position.z)) < 0.05f) {
                    sp.transform.localScale = new Vector3(0.15F, 0.15F, 0.15F);
                }
            }
                
        }
		
	}
}
