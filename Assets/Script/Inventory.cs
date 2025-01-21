using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.Items;
using System;

namespace Assets.Script
{
	[Serializable]
	public class Inventory : MonoBehaviour
	{
		public GameObject canvas; // Панель инвентаря
		public GameObject inventoryPanel; // Панель слотов инвентаря
		public GameObject equipmentPanel; // Панель слотов снаряжения
		public Dictionary<EquipmentSlot, CollectableItem> equipment = new();

		private readonly List<Item> items = new(); // Список предметов в инвентаре
		public int slotCount => 2;

		void Start()
		{
			canvas.SetActive(false); // Скрыть инвентарь при старте
			UpdateInventoryUI();
		}

		public void OnClick()
		{
			canvas.SetActive(!canvas.activeSelf);
		}

		// Добавление предмета в инвентарь
		public void AddItem(Item item)
		{
			if(items.Count < slotCount)
			{
				items.Add(item);
				UpdateInventoryUI();
			}
		}
		public void RemoveItem(Item item)
		{
			items.Remove(item);
			UpdateInventoryUI();	
		}
		public Item GetItem(int index) =>
			items[index];
		public int ItemCount =>
			items.Count;
		public void SetEquipment(CollectableItem collectable)
		{
			EquipmentSlot slot = collectable.Slot;
			equipment[slot] = collectable;
		}
		public void RemoveEquipment(CollectableItem collectable)
		{
			EquipmentSlot slot = collectable.Slot;
			equipment[slot] = null;
		}

		// Обновление UI инвентаря
		void UpdateInventoryUI()
		{
			foreach (Transform slot in inventoryPanel.transform)
			{
				slot.GetChild(0).GetComponent<Image>().sprite = null;
				slot.GetChild(0).GetComponent<CollectableItem>().item = Item.Empty;
			}

			int i = 0;
			foreach (Item item in items)
			{
				Transform slot = inventoryPanel.transform.GetChild(i++);
				slot.GetChild(0).GetComponent<Image>().sprite = item.icon;
				slot.GetChild(0).GetComponent<CollectableItem>().item = item;
			}
		}
	}
}
