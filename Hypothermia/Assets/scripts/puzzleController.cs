using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class puzzleController : MonoBehaviour {

    public GameObject buttonX;
    public GameObject buttonZ;

    public String theTag = "stadiumPuz";

    GameObject[] stdPuzs;
    Vector3[] originalPos = new Vector3[150];
    public float startZpos = -12.75f; //18x
    public float startYpos = -1.2f; //3x
    public float startXpos = -6.75f; //15x
    public float cubeSize = 1.5f;
    public Vector3 centerPoint = new Vector3(5.25f, -1.2f, 0f);
    public float boundStartXposL = -8.25f; //18x -8.25f
    public float boundStartZposL = -14.25f; //15x
    public float boundStartXposH = 18.75f; //18x 18.75f
    public float boundStartZposH = 14.25f; //15x
    public int shuffleLB = 2;
    public int shuffleHB = 5;
    public int shuffleTime = 15;

    List<GameObject>[] sameX = new List<GameObject>[20];
    List<GameObject>[] sameZ = new List<GameObject>[20];

    List<int> moveZ = new List<int>();
    List<int> moveX = new List<int>();


    System.Random rnd = new System.Random();


    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < 20; i++){
            sameX[i] = new List<GameObject>();
            sameZ[i] = new List<GameObject>();
        }
        stdPuzs = GameObject.FindGameObjectsWithTag(theTag);
        for (int i = 0; i < stdPuzs.Length; i++){
            originalPos[i] = new Vector3(stdPuzs[i].transform.position.x,stdPuzs[i].transform.position.y,stdPuzs[i].transform.position.z);
        }
        for (int i = 0; i < shuffleTime;i++){
            shuffle();
            print("shuffle");
        }

        for (int i = 0; i < moveX.Count; i++){
            Vector3 spawnPos = new Vector3(-15.75f, -1.5f, startZpos + moveX[i]*cubeSize);
            Instantiate(buttonX, spawnPos, Quaternion.Euler(0f, 90f, 0f));
        }

        for (int i = 0; i < moveZ.Count; i++)
        {
            Vector3 spawnPos = new Vector3(startXpos + moveZ[i] * cubeSize, -1.5f, -15.75f);
            Instantiate(buttonZ, spawnPos, Quaternion.Euler(0f, 0f, 0f));
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
                    print("steps1");
                    sameZ[index][i].transform.position = new Vector3((float)(sameZ[index][i].transform.position.x + dir * 1.5f), sameZ[index][i].transform.position.y, sameZ[index][i].transform.position.z);
                    if (!moveX.Contains(index))
                    {
                        moveX.Add(index);
                    }
                }
                
            }
        }
        else
        {//sameX moveZ
            for (int i = 0; i < sameX[index].Count; i++)
            {
             
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
                    print("steps2");
                    sameX[index][i].transform.position = new Vector3(sameX[index][i].transform.position.x, sameX[index][i].transform.position.y, (float)(sameX[index][i].transform.position.z + dir * 1.5f));
                    if (!moveZ.Contains(index))
                    {
                        moveZ.Add(index);
                    }


                }

            }
        }

        
    }

    void groupCubes()
    {         for (int j = 0; j < 20; j++)         {             for (int i = 0; i < stdPuzs.Length; i++)             {                 if (Mathf.Abs(stdPuzs[i].transform.position.x - (boundStartXposL + j * cubeSize)) < 0.1f)                 {                     sameX[j].Add(stdPuzs[i]);                 }             }         }         for (int j = 0; j < 20; j++)         {             for (int i = 0; i < stdPuzs.Length; i++)             {                 if (Mathf.Abs(stdPuzs[i].transform.position.z - (boundStartZposL + j * cubeSize)) < 0.1f)                  {                     sameZ[j].Add(stdPuzs[i]);                 }             }         }     } }
