using Assets.Script.Items;
using Assets.Script.Spawn;
using UnityEditor;

namespace Assets.Script.GUI
{
	[CustomEditor(typeof(EnemySpawn))]
	public class EnemySpawnGui : Editor
	{
		public override void OnInspectorGUI()
		{
			var spawn = (EnemySpawn)target;
			var zone = spawn.zone;

			DrawDefaultInspector();

			if (zone == SpawnFigure.Circle)
				spawn.X = EditorGUILayout.FloatField("Радиус", spawn.X);
			if (zone == SpawnFigure.Rectangle)
			{
				spawn.X = EditorGUILayout.FloatField("Ширина", spawn.X);
				spawn.Y = EditorGUILayout.FloatField("Высота", spawn.Y);
			}
		}
	}
}
