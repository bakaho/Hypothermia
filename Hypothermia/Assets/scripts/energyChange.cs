using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class energyChange : NetworkBehaviour {
    public float stillAdd = 0.01f;
    public float movingLose = 0.2f;
    private NetworkStartPosition[] spawnPoints;
    public GameObject tombPrefab;

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //stay still, energy increase, move decrease energy
        if (!playerController1.moving)
        {
            char_energy.energy += stillAdd;
            if (char_energy.energy >= 500f)
                char_energy.energy = 500f;
        }
        else
            char_energy.energy -= movingLose;

        //if no energy, die
        if (char_energy.energy <= 0)
        {
            buildTomb();
            char_energy.energy = 500f;
            char_tempreture.temp = 500f;
            RpcRespwan();
        }
    }

    [ClientRpc]
    void RpcRespwan()
    {
        if (isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;

            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
            transform.position = spawnPoint;
        }
    }

    public void buildTomb()
    {
        Vector3 spawnPos = transform.position;
        Quaternion spawnRot = Quaternion.Euler(0f, 0f, 0f);
        GameObject tomb = (GameObject)Instantiate(tombPrefab, spawnPos, spawnRot);
        NetworkServer.Spawn(tomb);
    }
}
