using Assets.Script;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
	private Vector2 currentPosition;
	public Inventory inventory;
	public CollectableItem collectable;

	private void Awake()
	{
		
	}

	public void OnDrag(PointerEventData eventData)
    {
		transform.position = Input.mousePosition;	
	}
	public void OnEndDrag(PointerEventData eventData)
	{
		transform.localPosition = currentPosition;
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		currentPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);
	}
}
