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
    public float theForce = 50f;

    private Vector3 moveDir;

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
        }else{
            
        }

        if(timer > 200 && dist<5){
            print("too long");
            player1.GetComponent<Rigidbody>().AddForce(((player1Pos.position - player2Pos.position).normalized) * theForce);
            player2.GetComponent<Rigidbody>().AddForce(((player2Pos.position - player1Pos.position).normalized) * theForce);
            char_energy.energy -= 0.5f;
            char_energy1.energy -= 0.5f;
        }

        if (timer > 0 && dist > 30)
        {
            timer--;
            print(timer);

        }


	}
}
