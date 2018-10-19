using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class tempChange : NetworkBehaviour {
    public float stillLose = 0.1f;
    public float movingLose = 0.05f;
    private NetworkStartPosition[] spawnPoints;
    public GameObject tombPrefab;


	// Use this for initialization
	void Start () {
        if(isLocalPlayer){
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        //if moving,changing speed is slow if stay still, change faster
        if(!playerController.moving)
            char_tempreture.temp -= stillLose;
        else
            char_tempreture.temp -= movingLose;

        //if no tempreture, die
        if(char_tempreture.temp<=0){
            CmdbuildTomb();
            char_tempreture.temp = 500f;
            char_energy.energy = 500f;
            RpcRespwan();

        }
	}

    [ClientRpc]
    void RpcRespwan(){
        if(isLocalPlayer){
            Vector3 spawnPoint = Vector3.zero;

            if(spawnPoints != null && spawnPoints.Length >0){
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
            transform.position = spawnPoint;
        }
    }

    [Command]
    public void CmdbuildTomb()
    {
        Vector3 spawnPos = transform.position;
        Quaternion spawnRot = Quaternion.Euler(0f, 0f, 0f);
        GameObject tomb = (GameObject)Instantiate(tombPrefab, spawnPos, spawnRot);
        NetworkServer.Spawn(tomb);
    }
}
