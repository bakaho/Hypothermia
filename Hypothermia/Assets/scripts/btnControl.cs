using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnControl : MonoBehaviour
{
    public enum thisMode{
        Row,
        Column
    }
    public thisMode myMode;
    Collider cld;
    GameObject[] stdPuzs;


    Touch initTouch;
    bool readyDrag = false;


	// Use this for initialization
	void Start () {
        cld = GetComponent<Collider>();
        stdPuzs = GameObject.FindGameObjectsWithTag("stadiumPuz");
	}

    //void Update(){
    //    foreach(Touch t in Input.touches){
    //        if(t.phase == TouchPhase.Began){
    //            initTouch = t;
    //        }else if(t.phase == TouchPhase.Moved){
    //            //float xMoved = initTouch
    //        }else if (t.phase == TouchPhase.Ended)
    //        {

    //        }
    //    }
    //}
	

    //check trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject sp in stdPuzs)
            {
                //print("!!!!!!!");
                if (myMode == thisMode.Row)
                {
                    if (Mathf.Abs(sp.transform.position.z - (this.transform.position.z)) < 0.05f)
                    {
                        sp.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);

                        //RaycastHit hit = new RaycastHit();
                    }




                }else{
                    if (Mathf.Abs(sp.transform.position.x - (this.transform.position.x)) < 0.05f)
                    {
                        sp.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);
                    }
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject sp in stdPuzs)
            {
                //print("!!!!!!!");
                readyDrag = true;
                if (myMode == thisMode.Row)
                {
                    if (Mathf.Abs(sp.transform.position.z - (this.transform.position.z)) < 0.05f)
                    {
                        sp.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);
                        sp.GetComponent<thisDrag>().canDragX = true;
                        sp.GetComponent<thisDrag>().isLinked = true;

                        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        //RaycastHit hit = new RaycastHit();
                        //if (Physics.Raycast(ray, out hit))
                        //{
                        //    if (hit.transform.gameObject == sp)
                        //    {
                        //        print("test ok");

                        //        readyDrag = true;
                        //    }
                        //}

                    }
                }
                else
                {
                    if (Mathf.Abs(sp.transform.position.x - (this.transform.position.x)) < 0.05f)
                    {
                        sp.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject sp in stdPuzs)
            {
                if (myMode == thisMode.Row)
                {
                    if (Mathf.Abs(sp.transform.position.z - (this.transform.position.z)) < 0.05f)
                    {
                        sp.transform.localScale = new Vector3(0.3F, 0.3F, 0.3F);
                    }
                }
                else
                {
                    if (Mathf.Abs(sp.transform.position.x - (this.transform.position.x)) < 0.05f)
                    {
                        sp.transform.localScale = new Vector3(0.3F, 0.3F, 0.3F);
                    }
                }
            }
        }
    }

    //void OnMouseDrag(){
    //    if (readyDrag)
    //    {
    //        foreach (GameObject sp in stdPuzs)
    //        {
    //            //print("!!!!!!!");
    //            if (myMode == thisMode.Row)
    //            {
    //                if (Mathf.Abs(sp.transform.position.z - (this.transform.position.z)) < 0.05f)
    //                {
    //                    sp.transform.position += new Vector3(0, 0, 10f);
    //                }
    //            }
    //        }
    //    }
    //}


    //}
}
