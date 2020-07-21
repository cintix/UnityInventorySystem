using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {

    public void OnDrop (PointerEventData eventData) {
        Debug.Log ("Drop: " + eventData);
        if (eventData.pointerDrag != null) {
            Debug.Log ("eventData.pointerDrag");
            eventData.pointerDrag.GetComponent<RectTransform> ().anchoredPosition = GetComponent<RectTransform> ().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform> ().SetParent (GetComponent<RectTransform> ());
        }
    }

}