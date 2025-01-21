namespace Assets.Script.Stats
{
	[System.Serializable]
	public class WeaponStats : Stats
	{
		public float reloadSpeed;
		public int ammoCapacity;
		public int ammo;
		public int damage;
		public float range;
		// Скорость удара/ скорострельность
		public float speed;
		public float bulletSpeed;
		public AmmoType ammoType;
	}
}