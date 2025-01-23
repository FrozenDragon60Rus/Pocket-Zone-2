using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Character
{
	[System.Serializable]
	public class Equipment
	{
		public EquipmentSlot slot;
		public CollectableItem collectable;
		public List<GameObject> parent;
		public bool equiped;
	}
}
