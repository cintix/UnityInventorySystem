using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform currentParent = null;
    void Awake () {
        rectTransform = GetComponent<RectTransform> ();
        canvasGroup = GetComponent<CanvasGroup> ();
    }

    public void OnBeginDrag (PointerEventData eventData) {
        Debug.Log ("OnBeginDrag");
        if (canvasGroup != null) {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.6f;
        }
    }

    public void OnDrag (PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag (PointerEventData eventData) {
        Debug.Log ("OnEndDrag");
        if (canvasGroup != null) {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
        }

        if (rectTransform.parent == canvas.transform && currentParent != null) {
            rectTransform.SetParent (currentParent);
        }

        if (rectTransform.parent != canvas.transform) {
            currentParent = rectTransform.parent;
        }

        transform.localPosition = Vector3.zero;
    }

    public void OnPointerDown (PointerEventData eventData) {
        Debug.Log ("OnPointerDown");
        currentParent = rectTransform.parent;
        rectTransform.SetParent (canvas.transform);
    }

}