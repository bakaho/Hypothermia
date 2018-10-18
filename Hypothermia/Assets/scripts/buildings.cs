using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class buildings : NetworkBehaviour {

    public GameObject buildingPrefab;
    public int buildingNum = 15;

	public override void OnStartServer()
	{
        for (int i=0; i< buildingNum; i++){
            Vector3 spawnPos;
            if (Random.Range(0f, 10f) > 5)
            {
                spawnPos = new Vector3(Random.Range(-20f, -3f), -0.7f, Random.Range(-20f, 20f));
            }else{
                spawnPos = new Vector3(Random.Range(20f, 3f), -0.7f, Random.Range(-20f, 20f));
            }
            Quaternion spawnRot = Quaternion.Euler(0f, 0f, 0f);

            GameObject building = (GameObject)Instantiate(buildingPrefab, spawnPos, spawnRot);
            NetworkServer.Spawn(building);
        }
        //base.OnStartServer();{
            
        //}
	}

}
