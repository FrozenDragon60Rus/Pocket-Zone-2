using System.IO;
using UnityEngine;

namespace Assets.Script
{
	public class SessionManager
	{
		private string path;

		public SessionManager(string dataPath)
		{
			path = dataPath;
		}

		public void Save(SessionData sessionData)
		{
			string json = JsonUtility.ToJson(sessionData, true); // true для форматированного вывода
			File.WriteAllText(path, json);
		}

		public SessionData Load()
		{
			if (File.Exists(path))
			{
				string json = File.ReadAllText(path);
				SessionData sessionData = JsonUtility.FromJson<SessionData>(json);
				return sessionData;
			}
			else
			{
				Debug.LogWarning("No session file found!");
				return null;
			}
		}
	}
}
