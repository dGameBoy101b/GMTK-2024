using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WinterwireGames.GUIManagement
{
	public class ScreenResolution : MonoBehaviour
	{
		public int Width
		{
			get => Screen.width;
			set => Screen.SetResolution(value, this.Height, this.FullScreenMode);
		}

		public int Height
		{
			get => Screen.height;
			set => Screen.SetResolution(this.Width, this.Height, this.FullScreenMode);
		}

		public FullScreenMode FullScreenMode
		{
			get => Screen.fullScreenMode;
			set => Screen.SetResolution(this.Width, this.Height, value);
		}

		public bool IsFullScreen
		{
			get => Screen.fullScreen;
			set => Screen.fullScreen = value;
		}
	}
}
