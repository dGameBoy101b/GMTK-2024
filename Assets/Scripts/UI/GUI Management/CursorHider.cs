using UnityEngine;

namespace WinterwireGames.GUIManagement
{
	public class CursorHider : MonoBehaviour
	{
		public bool IsVisible
		{
			get => Cursor.visible;
			set => Cursor.visible = value;
		}
	}
}
