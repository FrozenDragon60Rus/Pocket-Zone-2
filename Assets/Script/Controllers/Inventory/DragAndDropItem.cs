using Assets.Script;
using Assets.Script.GUI;
using Assets.Script.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
	private Vector2 currentPosition;
	public Inventory inventory;
	public CollectableItem collectable;
	private Vector3 MouseWorldPosition
	{
		get
		{
			var mouseScreenPos = Input.mousePosition;
			mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
			return Camera.main.WorldToScreenPoint(mouseScreenPos);
		}
	}

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
	public void OnMouseUp()
	{
		Collider2D collider = GetComponent<Collider2D>();

		collider.enabled = false;
		var rayOrigin = Camera.main.transform.position;
		var rayDirection = MouseWorldPosition - rayOrigin;
		RaycastHit2D hit;

		if (hit = Physics2D.Raycast(rayOrigin, rayDirection))
		{
			if (hit.transform.CompareTag("SlotTrash"))
			{
				var item = collectable.item;
				inventory.RemoveItem(item);
			}
		}

		collider.enabled = false;
	}
}
