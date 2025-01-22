using Assets.Script.Character;
using System.Collections;
using UnityEngine;

namespace Assets.Script.Controllers
{
	public class EnemyController : MonoBehaviour
	{
		public Transform target;
		public Unit unit;
		public float maxDistance;
		public Transform spawn;

		private bool haveTarget = true;
		private bool FlagAtack = false;

		void Update()
		{
			if(unit.status == Status.Normal && 
				haveTarget == true)
			{
				MoveToTarget();
			}
		}

		public void Atack()
		{
			if (FlagAtack)
				return;

			var player = target.GetComponent<Player>();
			player.Damage(unit.stats.damage);

			if (player.status == Status.Dead)
				haveTarget = false;

			FlagAtack = true;

			StartCoroutine(Wait());
		}

		public IEnumerator Wait()
		{
			yield return new WaitForSeconds(3f);

			FlagAtack = false;
		}

		private void MoveToTarget()
		{
			var distance = Vector2.Distance(transform.position, target.position);
			var speed = unit.stats.speed * Time.deltaTime;
			if (distance > maxDistance)
				transform.position = Vector3.MoveTowards(transform.position, spawn.position, speed);
			else if (distance > 1)
				transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
			else
				Atack();
		}
	}
}
