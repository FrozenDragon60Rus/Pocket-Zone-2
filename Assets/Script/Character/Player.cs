using Assets.Script.Stats;

namespace Assets.Script.Character
{
	public class Player : Unit
	{
		public Inventory inventory;

		protected override float Defence
		{
			get
			{
				int defence = 0;
				foreach (var key in inventory.equipment.Keys)
				{
					var item = inventory.equipment[key];
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
