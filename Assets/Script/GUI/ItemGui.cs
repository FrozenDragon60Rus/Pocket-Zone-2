using Assets.Script.Items;
using UnityEditor;

namespace Assets.Script.GUI
{
	[CustomEditor(typeof(CollectableItem),true)]
	public class ItemGui : Editor
	{
		public override void OnInspectorGUI()
		{
			var collectable = (CollectableItem)target;
			var type = collectable.item.type;

			DrawDefaultInspector();

			if (type == ItemType.Equipmnet)
				collectable.Slot = (EquipmentSlot)EditorGUILayout.EnumFlagsField("Слот", collectable.Slot);
			if (type == ItemType.Ammo)
				collectable.AmmoType = (AmmoType)EditorGUILayout.EnumFlagsField("Калибр", collectable.AmmoType);
		}
	}
}
