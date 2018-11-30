using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thisDrag : MonoBehaviour {
    public bool canDragX = false;
    public bool canDragZ = false;
    public bool isLinkedX = false;
    public bool isLinkedZ = false;

    GameObject[] stdPuzs;
    //-----------this class is only for PC-----------

	// Use this for initialization
	void Start () {
        stdPuzs = GameObject.FindGameObjectsWithTag("stadiumPuz");
	}
	
	// Update is called once per frame
	void Update () {

        //if is linked, move along with the dragged object
         if (isLinkedX)
         {
  
            this.transform.position += new Vector3(1.5f * Mathf.RoundToInt(Input.GetAxis("Mouse X")), 0, 0);
         }
        if (isLinkedZ)
        {

            this.transform.position += new Vector3(0, 0, 1.5f * Mathf.RoundToInt(Input.GetAxis("Mouse Y")));
        }


		
	}

    //if the current cube is being dragged
    void OnMouseDrag()
    {
        //move the cube along with the mouse
        if(canDragX){
            this.transform.position += new Vector3(1.5f * Mathf.RoundToInt(Input.GetAxis("Mouse X")),0 , 0);
            foreach (GameObject sp in stdPuzs)
            {
                //if in the same row, add to linkage
                if (Mathf.Abs(sp.transform.position.z - (this.transform.position.z)) < 0.05f)
                {
                    sp.GetComponent<thisDrag>().isLinkedX = true;
                }
            } 
            //turn of its linkage of itself
            isLinkedX = false;
        }

        if (canDragZ)
        {
            this.transform.position += new Vector3(0, 0, 1.5f * Mathf.RoundToInt(Input.GetAxis("Mouse Y")));
            foreach (GameObject sp in stdPuzs)
            {
                if (Mathf.Abs(sp.transform.position.x - (this.transform.position.x)) < 0.05f)
                {
                    sp.GetComponent<thisDrag>().isLinkedZ = true;
                }
            }
            isLinkedZ = false;
        }

    }

    void OnMouseUp()
    {
        //if let go, turn off everything
        if (canDragX)
        {           
            foreach (GameObject sp in stdPuzs)
            {
                if (Mathf.Abs(sp.transform.position.z - (this.transform.position.z)) < 0.05f)
                {
                    sp.GetComponent<thisDrag>().isLinkedX = false;
                }
            }
        }

        if (canDragZ)
        {
            foreach (GameObject sp in stdPuzs)
            {
                if (Mathf.Abs(sp.transform.position.x - (this.transform.position.x)) < 0.05f)
                {
                    sp.GetComponent<thisDrag>().isLinkedZ = false;
                }
            }
        }

    }
}
