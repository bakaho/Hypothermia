using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thisDrag : MonoBehaviour {
    public bool canDragX = false;
    public bool canDragZ = false;
    private bool isDragging = false;
    public bool isLinked = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (isLinked && !isDragging)
            {
                this.transform.position += new Vector3(1.5f * Mathf.Floor(Input.GetAxis("Mouse X")), 0, 0);
            }
        }
        isDragging = false;
		
	}

    void OnMouseDrag()
    {
        //move the cube along with the mouse
        if(canDragX){
            this.transform.position += new Vector3(1.5f * Mathf.Floor(Input.GetAxis("Mouse X")),0 , 0);
            isDragging = true;
        }

    }
}
