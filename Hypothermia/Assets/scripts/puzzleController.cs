using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleController : MonoBehaviour {

    GameObject[] stdPuzs;
    Vector3[] originalPos = new Vector3[150];
    public float startZpos = -12.75f;
    public float startYpos = -1.2f;
    public float startXpos = -6.75f;


    // Use this for initialization
    void Start()
    {
        stdPuzs = GameObject.FindGameObjectsWithTag("stadiumPuz");
        for (int i = 0; i < stdPuzs.Length; i++){
            originalPos[i] = new Vector3(stdPuzs[i].transform.position.x,stdPuzs[i].transform.position.y,stdPuzs[i].transform.position.z);
            print(originalPos[i].x +" " +originalPos[i].y+" "+originalPos[i].z);
        }		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
