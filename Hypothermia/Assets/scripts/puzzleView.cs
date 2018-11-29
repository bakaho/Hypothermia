using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleView : MonoBehaviour {

    public float rotSpeed = 5;
    public Camera uiCam;
    bool rotateAllow = false;
    Touch initTouch;

    // Update is called once per frame
    void Update()
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                initTouch = t;
                Ray ray = uiCam.ScreenPointToRay(initTouch.position);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject == this.gameObject)
                    {
                        print("hit!");
                        rotateAllow = true;
                    }
                }
            }
            else if (t.phase == TouchPhase.Moved)
            {
                float xMoved = initTouch.position.x - t.position.x;
                float yMoved = initTouch.position.y - t.position.y;
                float distance = Mathf.Sqrt((xMoved * xMoved) + (xMoved * xMoved));
                if(rotateAllow){
                    float rotX = xMoved / 5f * rotSpeed * Mathf.Deg2Rad;
                    float rotY = yMoved / 5f * rotSpeed * Mathf.Deg2Rad;

                    transform.Rotate(Vector3.up, rotX);
                    transform.Rotate(Vector3.right, rotY);
                }

            }
            else if (t.phase == TouchPhase.Ended)
            {
                rotateAllow = false;
            }
        }
    }
}
