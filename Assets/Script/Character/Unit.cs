using Assets.Script.Stats;
using UnityEngine;

namespace Assets.Script.Character
{
	[System.Serializable]
	public abstract class Unit : MonoBehaviour
	{
		public CharacterStats stats = new();
		public Status status = Status.Normal;
		public GameObject hpBar;
		RectTransform hpBarRect;

		protected virtual float Defence { get => stats.defence; }
		protected Vector2 Health => new(HPBarX, 0);
		protected float HPBarX => (stats.maxHealth / 100) * stats.health;

		private float BlockDamage(float damage)
		{
			float percent = Defence / 100;
			return damage - (damage * percent);
		}

		public void Damage(float damage)
		{
			if (status == Status.Dead)
				return;

			float health = stats.health - BlockDamage(damage);
			if (health <= 0)
			{
				stats.health = 0;
				Dead();
			}
			else stats.health = health;

			hpBarRect.sizeDelta = Health;
		}
		public void Heal(float heal)
		{
			if (status == Status.Dead)
				return;

			float health = stats.health + heal;
			if (health > stats.maxHealth)
				stats.health = stats.maxHealth;
			else stats.health = health;

			hpBarRect.sizeDelta = Health;
		}

		public void Rewive(float heal)
		{
			if (status == Status.Dead) 
			{
				status = Status.Normal;
				Heal(heal);
			}

			hpBarRect.sizeDelta = Health;
		}
		protected virtual void Dead() 
		{
			status = Status.Dead;
		}

		private void Start()
		{
			hpBarRect = hpBar.GetComponent<RectTransform>();
		}
	}
}
