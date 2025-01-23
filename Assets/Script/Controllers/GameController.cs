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
			SessionData data = manager.Load();
			if (data != null)
			{
				player.transform.position = data.player.position;
				player.transform.rotation = data.player.rotation;
				player.stats = data.player.stats;

				foreach (var item in data.inventory.item) 
				{
					inventory.AddItem(item);
				}

				EquipmentData equipment = data.equipment;
				for(int i = 0; i < data.equipment.slots.Count; i++)
				{
					inventory.equipmentControl.SetEqupment(equipment.collectable[i]);
				}
			}

			StartCoroutine(AutoSave());
		}

		public void EndSession()
		{
			SessionData data = new();
			data.player.position = player.transform.position;
			data.player.rotation = player.transform.rotation;
			data.player.stats = player.stats;
			for(int i = 0; i < inventory.ItemCount; i++) 
			{ 
				data.inventory.item.Add(inventory.GetItem(i));
			}
			foreach (var equip in inventory.equipmentControl.equipment)
			{
				data.equipment.slots.Add(equip.slot);
				data.equipment.collectable.Add(equip.collectable);
			}

			manager.Save(data);
		}

		public IEnumerator AutoSave()
		{
			while (true)
			{
				yield return new WaitForSeconds(10f);
				EndSession();
				Debug.Log("Сессия записана");
			}
		}
	}
}
