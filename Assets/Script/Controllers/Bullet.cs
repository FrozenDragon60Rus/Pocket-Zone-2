using Assets.Script.Stats;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Script.Controllers
{
	public class Bullet : MonoBehaviour
	{
		public Rigidbody2D rig;
		public WeaponStats stats { get; set; }

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

			Debug.Log(target.tag);

			if (target.CompareTag("Player") ||
				target.CompareTag("Ally") ||
				target.CompareTag("Enemy"))
			{
				var unit = collision.transform.GetComponent<Character.Unit>();
				unit.Damage(stats.damage);
			}

			Destroy(transform.gameObject);
		}
	}
}
