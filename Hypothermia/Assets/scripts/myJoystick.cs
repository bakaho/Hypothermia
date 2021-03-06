﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class myJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler 
{
    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputVector;

    void Start(){
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        //if draging in the rectangle of the joystick, calculate position
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform
                                                                   ,ped.position
                                                                  ,ped.pressEventCamera
                                                                   ,out pos))
        {
            //get relative position
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.01) ? inputVector.normalized : inputVector;
            joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3)
                                                                     , inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3),0);

        }
    }

    public virtual void OnPointerDown(PointerEventData ped){
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        //bounce back to zero point if move up
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;

    }

    //use these data to set the horizontal and vertical value
    public float Horizontal(){
        if(inputVector.x != 0){
            print("0");
            return inputVector.x;

        }else{
            //print("1");
            return Input.GetAxis("Horizontal");

        }
    }

    public float Vertical(){
        if (inputVector.z != 0)
        {
            //print("2");
            return inputVector.z;

        }
        else
        {
            //print("3");
            return Input.GetAxis("Vertical");
           
        }
    }

}
