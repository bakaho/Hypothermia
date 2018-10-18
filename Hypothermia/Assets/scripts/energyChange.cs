using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyChange : MonoBehaviour {
    public float stillAdd = 0.01f;
    public float movingLose = 0.2f;
    // Use this for initialization
    void Start()
    {

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
            playerController1.isAlive = false;
        }
    }
}
