using Assets.Script.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Script.GUI
{
	[CustomEditor(typeof(Inventory))]
	public class InventoryGui : Editor
	{
		public Dictionary<EquipmentSlot, CollectableItem> collectable = new()
		{
			{ EquipmentSlot.Weapon, null },
			{ EquipmentSlot.Head, null },
			{ EquipmentSlot.Body, null },
			{ EquipmentSlot.Hand, null },
			{ EquipmentSlot.Leg, null },
			{ EquipmentSlot.Bag, null }
		};
		bool show = true;

		public override void OnInspectorGUI()
		{
			var inventory = (Inventory)target;

			DrawDefaultInspector();

			string[] slots = Enum.GetValues(typeof(EquipmentSlot))
				.Cast<int>()
				.Select(x => x.ToString())
				.ToArray();
			EquipmentSlot slotType;

			show = EditorGUILayout.BeginFoldoutHeaderGroup(show, "Equipment");
			if (show)
			{
				EditorGUI.indentLevel++;
				foreach (var slot in Enum.GetValues(typeof(EquipmentSlot)))
				{
					slotType = (EquipmentSlot)slot;
					collectable[slotType] = (CollectableItem)EditorGUILayout.ObjectField(
						slot.ToString(),
						collectable[slotType],
						typeof(CollectableItem),
						true
					);

					if (collectable[slotType] == null)
						continue;
					if (collectable[slotType].Slot != slotType)
						collectable[slotType] = null;

					inventory.equipment[slotType] = collectable[slotType];
				}
				EditorGUI.indentLevel--;
			}
			EditorGUILayout.EndFoldoutHeaderGroup();
		}
	}
}
