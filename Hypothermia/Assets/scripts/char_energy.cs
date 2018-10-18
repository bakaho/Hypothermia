using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class char_energy : MonoBehaviour {

    Image energyBar;
    float maxEnergy = 500f;
    public static float energy;
    // Use this for initialization
    void Start()
    {
        energyBar = GetComponent<Image>();
        energy = maxEnergy;

    }

    // Update is called once per frame
    void Update()
    {
        energyBar.fillAmount = energy / maxEnergy;

    }
}
