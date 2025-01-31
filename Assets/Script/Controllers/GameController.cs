using Assets.Script.Character;
using Assets.Script.Session;
using System.Collections;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Script.Controllers
{
	public class GameController : MonoBehaviour
	{
		SessionManager manager;
		public Script.Inventory inventory;
		public Player player;

		private void Start()
		{
			string dataPath = Path.Combine(Application.persistentDataPath, "session.json");
			manager = new(dataPath);
			Debug.Log(dataPath);

			LoadSession();

			StartCoroutine(AutoSave());
		}

		public void SaveSession()
		{
			SessionData data = new();

			SavePlayer(data);
			SaveInventory(data);
			SaveEquipment(data);

			manager.Save(data);
		}
		public void LoadSession()
		{
			SessionData data = manager.Load();
			if (data != null)
			{
				LoadPlayer(data);
				LoadInventory(data);
				LoadEquipment(data);
			}
		}

		public IEnumerator AutoSave()
		{
			while (true)
			{
				yield return new WaitForSeconds(10f);
				SaveSession();
				Debug.Log("Сессия записана");
			}
		}

		private void SaveEquipment(SessionData data)
		{
			foreach (var equip in inventory.equipmentControl.equipment)
			{
				data.equipment.slots.Add(equip.slot);
				data.equipment.collectable.Add(equip.collectable);
			}
		}
		private void LoadEquipment(SessionData data)
		{
			EquipmentData equipment = data.equipment;
			for (int i = 0; i < data.equipment.slots.Count; i++)
			{
				inventory.equipmentControl.SetEqupment(equipment.collectable[i]);
			}
		}
		private void SaveInventory(SessionData data)
		{
			for (int i = 0; i < inventory.ItemCount; i++)
			{
				data.inventory.item.Add(inventory.GetItem(i));
			}
		}
		private void LoadInventory(SessionData data)
		{
			foreach (var item in data.inventory.item)
			{
				inventory.AddItem(item);
			}
		}
		private void SavePlayer(SessionData data)
		{
			data.player.position = player.transform.position;
			data.player.rotation = player.transform.rotation;
			data.player.stats = player.stats;
		}
		private void LoadPlayer(SessionData data)
		{
			player.transform.position = data.player.position;
			player.transform.rotation = data.player.rotation;
			player.stats = data.player.stats;
		}
	}
}
