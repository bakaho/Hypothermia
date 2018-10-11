using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour {
    public Transform player1Pos;
    public Transform player2Pos;
    public GameObject player1;
    public GameObject player2;
    public float tempAdd = 0.02f;
    public int timer = 0;
    Vector3 direction1to2;
    Vector3 direction2to1;

    private Vector3 moveDir;
    public float speed = 10f;
    public float accleration = 1f; 

    private float dist;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(player1Pos.position, player2Pos.position);
        if(dist<2){
            print("close");
            char_tempreture.temp += tempAdd;
            char_tempreture1.temp += tempAdd;
            timer += 1;
        }

        if(timer > 200 && dist<5){
            print("too long");
            //direction1to2 = (player2Pos.position - player1Pos.position).normalized;
            //Vector3 diff = player2Pos.position - player1Pos.position;
            //Vector3 projected = Vector3.ProjectOnPlane(diff, Camera.main.transform.forward);
            //origin.transform.rotation = Quaternion.LookRotation(projected);
            player1.GetComponent<Rigidbody>().AddForce(((player1Pos.position - player2Pos.position).normalized) * 30);
            player2.GetComponent<Rigidbody>().AddForce(((player2Pos.position - player1Pos.position).normalized) * 30);
            char_energy.energy -= 0.5f;
            char_energy1.energy -= 0.5f;



            //moveDir = (player2Pos.position - player1Pos.position).normalized;
            //moveDir = transform.TransformDirection(moveDir);
            //speed = speed + accleration;
            //moveDir *= speed;
            //player2.GetComponent<CharacterController>().Move(moveDir * Time.deltaTime);
            //player1.GetComponent<CharacterController>().Move(-moveDir * Time.deltaTime);
            ////player2Pos.position += moveDir * Time.deltaTime;
        }



	}
}
