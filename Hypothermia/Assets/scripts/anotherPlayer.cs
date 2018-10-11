using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anotherPlayer : MonoBehaviour {
    public float speed = 5.0f;
    public float rotateSpeed = 240.0f;
    private float gravity = 20.0f;
    private Vector3 moveDir = Vector3.zero;
    public static bool moving;


    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey("l"))
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        else if (Input.GetKey("j"))
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        else
            transform.Rotate(0, 0 * Time.deltaTime, 0);


            if (Input.GetKey("i"))
            {
                moveDir = Vector3.forward * -1;
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= speed;
                moving = true;
            }
            else if (Input.GetKey("k"))
            {
                moveDir = Vector3.forward * 1;
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= speed;
                moving = true;
            }
            else
            {
                moveDir = Vector3.forward * 0;
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= speed;
                moving = false;
            }


        moveDir.y -= gravity * Time.deltaTime;
        Vector3 newPos = transform.position + moveDir * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(newPos);

    }
}
