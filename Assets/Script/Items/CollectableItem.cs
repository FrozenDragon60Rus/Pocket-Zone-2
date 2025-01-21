using Assets.Script.Items;
using UnityEngine;

namespace Assets.Script {
	public class CollectableItem : MonoBehaviour
	{
		public Item item;
		public Stats.Stats stats;

		public EquipmentSlot Slot { set; get; }
		public AmmoType AmmoType { set; get; }
	}
}
