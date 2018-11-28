using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class puzzleController : MonoBehaviour {

    GameObject[] stdPuzs;
    Vector3[] originalPos = new Vector3[150];
    public float startZpos = -12.75f; //18x
    public float startYpos = -1.2f; //3x
    public float startXpos = -6.75f; //15x
    public float cubeSize = 1.5f;
    public Vector3 centerPoint = new Vector3(5.25f, -1.2f, 0f);
    public float boundStartZposL = -8.25f; //18x
    public float boundStartXposL = -14.25f; //15x
    public float boundStartZposH = 18.75f; //18x
    public float boundStartXposH = 14.25f; //15x
    public int shuffleLB = 2;
    public int shuffleHB = 5;
    public int shuffleTime = 15;

    List<GameObject>[] sameX = new List<GameObject>[20];
    List<GameObject>[] sameZ = new List<GameObject>[20];

    System.Random rnd = new System.Random();


    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < 20; i++){
            sameX[i] = new List<GameObject>();
            sameZ[i] = new List<GameObject>();
        }
        stdPuzs = GameObject.FindGameObjectsWithTag("stadiumPuz");
        for (int i = 0; i < stdPuzs.Length; i++){
            originalPos[i] = new Vector3(stdPuzs[i].transform.position.x,stdPuzs[i].transform.position.y,stdPuzs[i].transform.position.z);
            //print(originalPos[i].x +" " +originalPos[i].y+" "+originalPos[i].z);
        }
        for (int i = 0; i < shuffleTime;i++){
            shuffle();
            print("shuffle");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void shuffle(){
        groupCubes();
        int rnd4axis = rnd.Next(0, 19);
        int theAxis = 0;
        int line = 0;

        if(rnd4axis<10){
            theAxis = 0;
            do
            {
                line = rnd.Next(0, 19);
            } while (sameZ[line].Count == 0);
        }else{
            theAxis = 1;
            do
            {
                line = rnd.Next(0, 19);
            } while (sameX[line].Count == 0);
        }
        int theStep = rnd.Next(shuffleLB, shuffleHB);


        int preDir = rnd.Next(0, 19);
        int theDir = 0;

        if (preDir < 10)
        {
            theDir = -1;
        }
        else
        {
            theDir = 1;
        }

        for (int i = 0; i < theStep; i++){
            step(theAxis, theDir, line);
        }


        
    }

    void step(int axis, int dir, int index){
        //detect colli
        //detect bound

        bool canMove = true;
        if (axis == 0)
        {//sameZ moveX
            for (int i = 0; i < sameZ[index].Count; i++)
            {
                print("steps1");
                Vector3 testPos = new Vector3((float)(sameZ[index][i].transform.position.x + dir * 1.5f), sameZ[index][i].transform.position.y, sameZ[index][i].transform.position.z);
                if (testPos.x >= boundStartXposH || testPos.x <= boundStartXposL)
                {
                    print("steps111111111");
                    canMove = false;
                    break;
                }
            }
            if (canMove){
                for (int i = 0; i < sameZ[index].Count; i++)
                {
                    
                    sameZ[index][i].transform.position = new Vector3((float)(sameZ[index][i].transform.position.x + dir * 1.5f), sameZ[index][i].transform.position.y, sameZ[index][i].transform.position.z);
                }
                
            }
        }
        else
        {//sameX moveZ
            for (int i = 0; i < sameX[index].Count; i++)
            {
             print("steps2");
             Vector3 testPos = new Vector3(sameX[index][i].transform.position.x, sameX[index][i].transform.position.y, (float)(sameX[index][i].transform.position.z+ dir * 1.5f));
                if (testPos.z >= boundStartZposH || testPos.z <= boundStartZposL)
                {
                    print("steps222222222");    
                    canMove = false;
                    break;
                }
            } 
            if (canMove)
            {
                for (int i = 0; i < sameX[index].Count; i++)
                {
                    
                    sameX[index][i].transform.position = new Vector3(sameX[index][i].transform.position.x, sameX[index][i].transform.position.y, (float)(sameX[index][i].transform.position.z + dir * 1.5f));
                }

            }
        }

        
    }

    void groupCubes(){
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < stdPuzs.Length; i++)
            {
                if (stdPuzs[i].transform.position.x == startXpos + j * cubeSize)
                {
                    sameX[j].Add(stdPuzs[i]);
                }
            }
        }
        for (int j = 0; j < 20; j++)
        {
            for (int i = 0; i < stdPuzs.Length; i++)
            {
                if (stdPuzs[i].transform.position.z == startZpos + j * cubeSize)
                {
                    sameZ[j].Add(stdPuzs[i]);
                }
            }
        }
    }

    void checkCollision(){
        
    }
}
