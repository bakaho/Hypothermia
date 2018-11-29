using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class invDropHandler : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform info = transform as RectTransform;
        if(RectTransformUtility.RectangleContainsScreenPoint(info,Input.mousePosition)){
            this.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Something from a stadium";
        }
    }
}
