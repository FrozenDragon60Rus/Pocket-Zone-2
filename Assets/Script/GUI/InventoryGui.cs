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

					inventory.equipment[slotType] = (CollectableItem)EditorGUILayout.ObjectField(
						slotType.ToString(),
						inventory.equipment[slotType],
						typeof(CollectableItem),
						true
					);

					if (inventory.equipment[slotType] == null)
						continue;

					if (inventory.equipment[slotType].Slot != slotType)
						inventory.equipment[slotType] = null;
				}
				EditorGUI.indentLevel--;
			}
			EditorGUILayout.EndFoldoutHeaderGroup();
		}
	}
}
