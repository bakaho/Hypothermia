using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpHint : MonoBehaviour {
    private Collider coll;
	private void Start()
	{
        coll = GetComponent<BoxCollider>();
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (coll.Raycast(ray, out hit,1000f))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                      print("picked!!");
                      GameObject.FindGameObjectWithTag("frameSlot1").gameObject.transform.GetChild(0).gameObject.SetActive(true);

                }
            }
        }
		
	}
}
