using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleController : MonoBehaviour {

    GameObject[] stdPuzs;
    Vector3[] originalPos = new Vector3[150];
    public float startZpos = -12.75f; //18x
    public float startYpos = -1.2f; //3x
    public float startXpos = -6.75f; //15x
    public float cubeSize = 1.5f;
    public Vector3 centerPoint = new Vector3(5.25f, -1.2f, 0f);
    //public float boundStartZpos = -12.75f; //18x
    //public float boundStartYpos = -1.2f; //5x
    //public float boundStartXpos = -6.75f; //15x
    List<GameObject>[] sameX = new List<GameObject>[20];
    List<GameObject>[] sameY = new List<GameObject>[20];
    List<GameObject>[] sameZ = new List<GameObject>[20];


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

    void shuffle(){
        
    }
}
