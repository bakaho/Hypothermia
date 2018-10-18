using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    private Vector3 ply1DeadPos;
    private Vector3 ply2DeadPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!playerController.isAlive){
            ply1DeadPos = player1.transform.position;
            //player1.GetComponent<Rigidbody>().velocity = -player1.transform.up*100*Time.deltaTime;
            //Vector3 newPos = player1.transform.position + new Vector3(0, 1, 0)* Time.deltaTime*200;
            //player1.GetComponent<Rigidbody>().MovePosition(newPos);
            player1.GetComponent<Collider>().enabled = false;
            player1.GetComponent<Rigidbody>().isKinematic = true;
            Collider[] colChildren = player1.GetComponentsInChildren<Collider>();
            foreach (Collider collider1 in colChildren)
            {
                collider1.enabled = false;
            }
            print("player1 is dead");
        }
        if (!anotherPlayer.isAlive)
        {
            ply2DeadPos = player2.transform.position;
            //player2.GetComponent<Rigidbody>().velocity = -player2.transform.up * 100*Time.deltaTime;
            //Vector3 newPos = player2.transform.position + new Vector3(0, 1, 0)*Time.deltaTime*200;
            //player2.GetComponent<Rigidbody>().MovePosition(newPos);
            player2.GetComponent<Collider>().enabled = false;
            player2.GetComponent<Rigidbody>().isKinematic = true;
            Collider[] colChildren = player2.GetComponentsInChildren<Collider>();
            foreach (Collider collider2 in colChildren)
            {
                collider2.enabled = false;
            }
            print("player2 is dead");
        }
		
	}
}
