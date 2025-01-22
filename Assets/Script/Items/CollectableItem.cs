using Assets.Script.Items;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script {
	[Serializable]
	public class CollectableItem : MonoBehaviour
	{
		public Item item;
		public Stats.Stats stats;
		public Text textField;

		public EquipmentSlot Slot { set; get; }
		public AmmoType AmmoType { set; get; }

		public void DrawStack()
		{
			textField.text = GetStack();
		}

		public string GetStack() =>
			item.stack > 1 ? item.stack.ToString() : string.Empty;
		
		/// <summary>
		/// Обновление сведений о предмете с отрисовкой количества
		/// </summary>
		public void SetItem(Item item)
		{
			this.item = item;
			DrawStack();
		}
	}
}
