using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Assets.Script.Character;
using Assets.Script.Controllers;

namespace Assets.Script.Spawn
{
	public enum SpawnFigure
	{
		Circle,
		Rectangle
	}

	public class EnemySpawn : MonoBehaviour
	{
		public Transform target;
		public List<GameObject> enemyPool;
		private GameObject enemy;
		public SpawnFigure zone;

		public float X { get; set; }
		public float Y { get; set; }

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;

			// Отрисовка зоны спавна
			switch (zone)
			{
				case SpawnFigure.Circle:
					Gizmos.DrawWireSphere(transform.position, X);
					break;
				case SpawnFigure.Rectangle:
					Gizmos.DrawWireCube(transform.position, new Vector3(X, Y, 0));
					break;
				default: 
					break;
			}
		}

		private void Start()
		{
			StartCoroutine(Generate(0f));
		}

		// Случайная позиция внутри зоны спавна по радиусу
		private Vector2 GetSpawnLocationFromRadius() =>
			Random.insideUnitCircle * X;

		// Случайная позиция внутри зоны спавна в прямоугольнике
		private Vector2 GetSpawnLocationFromRect()
		{
			float x = Random.value * X;
			float y = Random.value * Y;
			return new Vector2(x, y);
		}

		// Генерация противника
		public IEnumerator Generate(float time)
		{
			int poolLength = enemyPool.Count;
			int enemyNumber = new System.Random().Next(0, poolLength);

			var position = zone switch
			{
				SpawnFigure.Circle => (Vector2)transform.position + GetSpawnLocationFromRadius(),
				SpawnFigure.Rectangle => (Vector2)transform.position + GetSpawnLocationFromRect(),
				_ => Vector2.zero,
			};

			yield return new WaitForSeconds(time);

			enemy = enemyPool[enemyNumber];
			enemy.transform.position = position;
			enemy = Instantiate(enemy);
			enemy.transform.SetParent(transform);
			enemy.tag = "Enemy";
			
			var controller = enemy.GetComponent<EnemyController>();
			controller.spawn = transform;
			controller.target = target;
		}

	}
}
