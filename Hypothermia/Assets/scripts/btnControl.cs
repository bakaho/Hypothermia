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

    public float coef = 10000f;
    Collider cld;
    GameObject[] stdPuzs;


    Touch initTouch;
    bool readyDrag = false;


	// Use this for initialization
	void Start () {
        cld = GetComponent<Collider>();
        stdPuzs = GameObject.FindGameObjectsWithTag("stadiumPuz");
	}

    void Update(){
        foreach(Touch t in Input.touches){
            if(t.phase == TouchPhase.Began){
                initTouch = t;
            }else if(t.phase == TouchPhase.Moved){
                float xMoved = initTouch.position.x - t.position.x;
                float yMoved = initTouch.position.y - t.position.y;
                float distance = Mathf.Sqrt((xMoved * xMoved) + (xMoved * xMoved));
                bool swipedLeft = Mathf.Abs(xMoved) > Mathf.Abs(yMoved);
                if(distance > 100){
                        if (readyDrag)
                        {
                            foreach (GameObject sp in stdPuzs)
                            {
                                if (myMode == thisMode.Row)
                                {
                                    if (Mathf.Abs(sp.transform.position.z - (this.transform.position.z)) < 0.05f)
                                    {
                                    sp.transform.position += new Vector3(1.5f * Mathf.RoundToInt(-xMoved/coef), 0, 0);
                                    }
                                }
                            if (myMode == thisMode.Column)
                            {
                                if (Mathf.Abs(sp.transform.position.x - (this.transform.position.x)) < 0.05f)
                                {
                                    sp.transform.position += new Vector3(0, 0, 1.5f * Mathf.RoundToInt(xMoved / coef));
                                }
                            }
                            }
                        }
                    

                }

            }else if (t.phase == TouchPhase.Ended)
            {
                readyDrag = false;
            }
        }
    }
	

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
                        sp.GetComponent<thisDrag>().canDragX = true;
                        //RaycastHit hit = new RaycastHit();
                    }




                }else{
                    if (Mathf.Abs(sp.transform.position.x - (this.transform.position.x)) < 0.05f)
                    {
                        sp.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);
                        sp.GetComponent<thisDrag>().canDragZ = true;
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
                        //sp.GetComponent<thisDrag>().isLinkedX = true;
                        Ray ray = Camera.main.ScreenPointToRay(initTouch.position);
                        RaycastHit hit = new RaycastHit();
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.transform.gameObject == sp)
                            {
                                print("test ok");

                                readyDrag = true;
                            }
                            else{
                                readyDrag = false;
                            }
                        }

                    }
                }
                else
                {
                    if (Mathf.Abs(sp.transform.position.x - (this.transform.position.x)) < 0.05f)
                    {
                        sp.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);
                        sp.GetComponent<thisDrag>().canDragZ = true;
                        Ray ray = Camera.main.ScreenPointToRay(initTouch.position);
                        RaycastHit hit = new RaycastHit();
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.transform.gameObject == sp)
                            {
                                print("test ok");

                                readyDrag = true;
                            }
                            else
                            {
                                readyDrag = false;
                            }
                        }
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
                        sp.GetComponent<thisDrag>().canDragX = false;
                        readyDrag = false;
                    }
                }
                else
                {
                    if (Mathf.Abs(sp.transform.position.x - (this.transform.position.x)) < 0.05f)
                    {
                        sp.transform.localScale = new Vector3(0.3F, 0.3F, 0.3F);
                        sp.GetComponent<thisDrag>().canDragZ = false;
                        readyDrag = false;
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
