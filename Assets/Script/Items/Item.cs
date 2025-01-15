using UnityEngine;

namespace Assets.Script.Items
{
	internal abstract class Item
	{
		[SerializeField]
		private string Name { get; }
		[SerializeField]
		public int Stuck { get; } = 1;
		[SerializeField]
		public string Icon { get; set; }
	}
}
