using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpHint : MonoBehaviour {
    //set a specific collider to support the raycasting
    private Collider coll;

	private void Start()
	{
        //box collider to distinct with the sphere one (which is a trigger)
        coll = GetComponent<BoxCollider>();
	}

	// Update is called once per frame
	void Update () {
        //check touch
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (coll.Raycast(ray, out hit,1000f))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    //put into the inve  
                    print("picked!!");
                      GameObject.FindGameObjectWithTag("frameSlot1").gameObject.transform.GetChild(0).gameObject.SetActive(true);

                }
            }
        }
		
	}
}
