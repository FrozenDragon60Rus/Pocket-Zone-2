﻿using Assets.Script.Stats;
using System;
using UnityEngine;

namespace Assets.Script.Character
{
	[Serializable]
	public class Player : Unit
	{
		public Inventory inventory;

		protected override float Defence
		{
			get
			{
				int defence = 0;
				foreach (var equip in inventory.equipmentControl.equipment)
				{
					var item = equip.collectable;
					if (item.stats.GetType() == typeof(AmunitionStats))
					{
						defence += (item.stats as AmunitionStats).defense;
					}
				}

				return defence;
			}
		}

		protected override void Dead()
		{
			base.Dead();
		}
	}
}
