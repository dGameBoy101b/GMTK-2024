using UnityEngine;

namespace WinterwireGames.GUIManagement
{
	public class CursorLocker : MonoBehaviour
	{
		public bool IsLocked 
		{
			get => Cursor.lockState == CursorLockMode.Locked;
			set
			{
				if (value && LastVisible == null && Cursor.lockState != CursorLockMode.Locked)
					LastVisible = Cursor.visible;
				Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
				if (value)
					Cursor.visible = false;
				if (!value && LastVisible != null)
				{
					Cursor.visible = LastVisible.Value;
					LastVisible = null;
				}
			}
		}

		public static bool? LastVisible { get; private set; } = null;
	}
}
