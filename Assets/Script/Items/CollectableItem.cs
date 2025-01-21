using Assets.Script.Items;
using System;
using UnityEngine;

namespace Assets.Script {
	[Serializable]
	public class CollectableItem : MonoBehaviour
	{
		public Item item;
		public Stats.Stats stats;

		public EquipmentSlot Slot { set; get; }
		public AmmoType AmmoType { set; get; }
	}
}
