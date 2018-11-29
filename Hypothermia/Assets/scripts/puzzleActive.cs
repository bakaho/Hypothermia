using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleActive : MonoBehaviour {
    static public bool roundClear = false;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    if (this.gameObject.CompareTag(playerController1.themePuz))
                    {
                        Renderer rend = GetComponentInChildren<Renderer>();
                        rend.enabled = true;
                        roundClear = true;


                    }
                    //this.gameObject.SetActive(true);
                }
            }
        }
	}
}
