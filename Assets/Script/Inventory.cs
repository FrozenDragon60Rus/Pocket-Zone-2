﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.Items;
using System;
using Assets.Script.Character;

namespace Assets.Script
{
	[Serializable]
	public class Inventory : MonoBehaviour
	{
		public GameObject canvas; // Панель инвентаря
		public GameObject inventoryPanel; // Панель слотов инвентаря
		public GameObject equipmentPanel; // Панель слотов снаряжения
		public EquipmentControl equipmentControl; // Снаряжение

		private readonly List<Item> items = new(); // Список предметов в инвентаре
		public int slotCount => 2;

		void Start()
		{
			canvas.SetActive(false); // Скрыть инвентарь при старте
		}

		public void OnClick()
		{
			if(!canvas.activeSelf)
				UpdateInventoryUI();
			canvas.SetActive(!canvas.activeSelf);
		}

		// Добавление предмета в инвентарь
		public bool AddItem(CollectableItem collectable)
		{
			if(items.Count < slotCount)
			{
				items.Add(collectable.item);
				UpdateInventoryUI();
				return true;
			}
			return false;
		}
		public bool AddItem(Item item)
		{
			if (items.Count < slotCount)
			{
				items.Add(item);
				UpdateInventoryUI();
				return true;
			}
			return false;
		}
		public void RemoveItem(CollectableItem collectable)
		{
			items.Remove(collectable.item);
			UpdateInventoryUI();	
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

		// Обновление UI инвентаря
		void UpdateInventoryUI()
		{
			foreach (Transform slot in inventoryPanel.transform)
			{
				slot.GetChild(0).GetComponent<Image>().sprite = null;
				slot.GetChild(0).GetComponent<CollectableItem>().SetItem(Item.Empty);
			}

			int i = 0;
			foreach (Item item in items)
			{
				Transform slot = inventoryPanel.transform.GetChild(i++);
				slot.GetChild(0).GetComponent<Image>().sprite = item.icon;
				slot.GetChild(0).GetComponent<CollectableItem>().SetItem(item);
			}
		}
	}
}
