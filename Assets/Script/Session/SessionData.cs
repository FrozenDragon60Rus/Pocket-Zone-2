using Assets.Script.Session;

namespace Assets.Script
{
	[System.Serializable]
	public class SessionData
	{
		public PlayerData player = new();
		public InventoryData inventory = new();
		public EquipmentData equipment = new();
	}
}
