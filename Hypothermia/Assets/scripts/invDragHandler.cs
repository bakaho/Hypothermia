using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class invDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler{

    //if dragging, update position accordingly
    public void OnDrag(PointerEventData eventData)
	{
        transform.position = Input.mousePosition;
	}

    //if let go, move back
	public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }

}
