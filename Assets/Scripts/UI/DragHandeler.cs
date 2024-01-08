using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
        startPosition = transform.position;        
        
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
        //transform.localPosition = eventData.position;
        Vector3 curScreenPt = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
        Vector3 curPos = Camera.main.ScreenToWorldPoint(curScreenPt);
        transform.position = new Vector3(curPos.x, curPos.y);

    }

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if(transform.parent == startParent){
            transform.position = startPosition;            
        }
	}

	#endregion



}
