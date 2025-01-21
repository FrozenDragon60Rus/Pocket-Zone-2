using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Character
{
	public class Enemy : Unit
	{
		public List<GameObject> items;

		protected override void Dead()
		{
			base.Dead();
			DropItem();
			Destroy(transform.gameObject);
		}

		private void DropItem()
		{
			foreach (var item in items)
			{
				GameObject currentItem = Instantiate(item);
				currentItem.transform.position = transform.position;
			}
		}
	}
}
