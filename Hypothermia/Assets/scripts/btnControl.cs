using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnControl : MonoBehaviour {
    public enum thisMode{
        Row,
        Column
    }
    public thisMode myMode;
    Collider cld;
    GameObject[] stdPuzs;


	// Use this for initialization
	void Start () {
        cld = GetComponent<Collider>();
        stdPuzs = GameObject.FindGameObjectsWithTag("stadiumPuz");
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
                    }
                }else{
                    if (Mathf.Abs(sp.transform.position.x - (this.transform.position.x)) < 0.05f)
                    {
                        sp.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);
                    }
                }
            }
            Debug.Log("player");
        }
    }

    void OnTriggerStay(Collider other)
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
            Debug.Log("player");
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
            Debug.Log("player");
        }
    }
}
