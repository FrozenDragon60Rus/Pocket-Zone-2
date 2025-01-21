using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

namespace Assets.Script
{
	public static class TransformExtension
	{
		public static Transform GetFirstChild(this Transform transform) =>
			transform.GetChild(0);
	}
}
