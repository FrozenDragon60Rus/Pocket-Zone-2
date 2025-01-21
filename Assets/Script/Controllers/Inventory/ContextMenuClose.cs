using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Script.Controllers.Inventory
{
	public class ContextMenuClose : MonoBehaviour
	{
		public Canvas canvas;
		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				// Проверяем, произошло ли нажатие на UI-элемент
				if (!IsPointerOverUIElement())
				{
					Destroy(canvas);
				}
			}
		}

		private bool IsPointerOverUIElement()
		{
			return EventSystem.current.IsPointerOverGameObject();
		}
	}
}
