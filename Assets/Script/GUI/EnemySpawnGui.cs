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
				spawn.x = EditorGUILayout.FloatField("Радиус", spawn.x);
			if (zone == SpawnFigure.Rectangle)
			{
				spawn.x = EditorGUILayout.FloatField("Ширина", spawn.x);
				spawn.y = EditorGUILayout.FloatField("Высота", spawn.y);
			}
		}
	}
}
