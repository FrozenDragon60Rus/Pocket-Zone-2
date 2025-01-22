using System.Collections.Generic;

namespace Assets.Script.Session
{
	[System.Serializable]
	public class InventoryData
	{
		public List<Items.Item> item = new();
		public List<CollectableItem> collectable = new();
	}
}
