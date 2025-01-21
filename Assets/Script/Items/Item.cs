using System;
using UnityEngine;

namespace Assets.Script.Items
{
	[Serializable]
	public class Item
	{
		public string name;
		public int count = 1;
		public int stuck = 1;
		public Sprite icon;
		public ItemType type = ItemType.Empty;

		public static Item Empty =>
			new()
			{
				name = string.Empty,
				count = 1,
				stuck = 1,
				icon = null,
				type = ItemType.Empty
			};

		public bool IsEmpty =>
			type == ItemType.Empty;
	}
}
