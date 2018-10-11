using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyChange1 : MonoBehaviour {
    public float stillAdd = 0.01f;
    public float movingLose = 0.2f;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (!anotherPlayer.moving)
        {
            char_energy1.energy += stillAdd;
            if (char_energy1.energy >= 100f)
                char_energy1.energy = 100f;
        }
        else
            char_energy1.energy -= movingLose;

        if (char_energy1.energy <= 0)
        {
            anotherPlayer.isAlive = false;

        }
        
    }
}
