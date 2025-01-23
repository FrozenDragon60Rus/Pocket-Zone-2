using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Script.Character
{
	public class EquipmentControl : MonoBehaviour
	{
		public List<Equipment> equipment;

		public void Start()
		{
			if (equipment == null)
				Debug.LogWarning("Нет ячеек снаряжения");
		}

		public void SetEqupment(CollectableItem collectable)
		{
			if (collectable.item.type != Items.ItemType.Equipmnet ||
				collectable.Slot == 0)
				return;

			var equip = equipment
				.Where(i => i.collectable.Slot == collectable.Slot)
				.Single();
			if (equip.equiped == true)
				RemoveEquipment(equip);
			equip.collectable = collectable;

			foreach(var parent in equip.parent)
				Instantiate(equip.collectable, parent.transform, false);
		}

		public void RemoveEquipment(CollectableItem collectable)
		{
			var equip = equipment
				.Where(i => i.collectable.Slot == collectable.Slot)
				.Single();

			Destroy(equip.collectable.gameObject);
			equip.collectable = null;
		}
		private void RemoveEquipment(Equipment equip)
		{
			Destroy(equip.collectable.gameObject);
			equip.collectable = null;
		}
	}
}
