using UnityEngine;

namespace Assets.Script.Session
{
	[System.Serializable]
	public class PlayerData
	{
		public Vector3 position;
		public Quaternion rotation;
		public Stats.CharacterStats stats;
	}
}
