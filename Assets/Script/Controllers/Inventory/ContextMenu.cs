using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Controllers.Inventory
{
	public class ContextMenu : MonoBehaviour
	{
		public Script.Inventory inventory;
		public GameObject contextMenu;
		private GameObject menu;
		public CollectableItem collectable;
		private bool enable = false;

		public void OnRemove()
		{
			inventory.RemoveItem(collectable);
			Close();
		}

		public void OnEquip()
		{

		}

		public void Show()
		{
			if(enable)
				return;

			if (collectable.item.type == Items.ItemType.Empty)
				return;

			menu = Instantiate(contextMenu);
			menu.transform.SetParent(transform, false);

			var context = menu.transform.GetChild(0).GetComponent<ContextMenuClose>();
			context.menu = this;

			RectTransform rect = menu.GetComponent<RectTransform>();
			RectTransform rectPrefab = contextMenu.GetComponent<RectTransform>();

			rect.sizeDelta = rectPrefab.sizeDelta;
			rect.localPosition = rectPrefab.localPosition;
			rect.anchoredPosition = rectPrefab.anchoredPosition;
			rect.pivot = rectPrefab.pivot;
			rect.anchorMin = rectPrefab.anchorMin;
			rect.anchorMax = rectPrefab.anchorMax;

			Transform Panel = menu.transform.GetChild(0);
			Button removeButton = Panel.Find("RemoveButton").GetComponent<Button>();	
			removeButton.onClick.AddListener(OnRemove);

			enable = true;
		}

		public void Close()
		{
			Destroy(menu);
			enable = false;
		}
	}
}
