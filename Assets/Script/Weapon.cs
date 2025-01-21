using Assets.Script.Controllers;
using Assets.Script.Stats;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Items
{
	public class Weapon : MonoBehaviour
	{
		public GameObject bulletPrefab;
		public Transform shootPoint;
		public WeaponStats stats;
		private bool FlagWait = false;

		public void Use()
		{
			if(FlagWait || stats.ammo == 0)
				return;

			// use animation

			stats.ammo--;
			var bulletObject = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
			var bullet = bulletObject.GetComponent<Bullet>();
			bullet.stats = stats;
			FlagWait = true;

			StartCoroutine(Wait());
		}
		public IEnumerator Wait()
		{
			yield return new WaitForSeconds(stats.speed);
			FlagWait = false;
		}
	}
}
