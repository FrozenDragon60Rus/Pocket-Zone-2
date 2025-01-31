using Assets.Script.Stats;
using JetBrains.Annotations;
using System.Linq;
using UnityEngine;

namespace Assets.Script.Controllers
{
	public class Bullet : MonoBehaviour
	{
		public Rigidbody2D rig;
		public WeaponStats stats { get; set; }
		private readonly string[] allowedTags = { "Player", "Ally", "Enemy" };

		private Vector2 startPosition;

		void Start ()
		{
			startPosition = transform.position;
		}

		void FixedUpdate ()
		{
			rig.velocity = stats.bulletSpeed * transform.right;

			if(Vector2.Distance(startPosition, transform.position) > stats.range)
				Destroy(transform.gameObject);
		}

		void OnCollisionEnter2D(Collision2D collision)
		{
			GameObject target = collision.gameObject;

			if (allowedTags.Contains(target.tag))
			{
				var unit = collision.transform.GetComponent<Character.Unit>();
				unit.Damage(stats.damage);
			}

			Destroy(transform.gameObject);
		}
	}
}
