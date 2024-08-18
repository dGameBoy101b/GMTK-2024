using UnityEngine;
using UnityEngine.UI;

namespace WinterwireGames.SceneManagement
{
	[RequireComponent(typeof(Slider))]
	public class LoadingBar : MonoBehaviour
	{
		private Slider _slider = null;

		public Slider Slider
		{
			get
			{
				this._slider ??= this.GetComponent<Slider>();
				return this._slider;
			}
		}

		private void InitialiseSlider()
		{
			this.Slider.wholeNumbers = false;
			this.Slider.minValue = 0f;
			this.Slider.maxValue = 1f;
		}

		public void UpdateSlider()
		{
			this.Slider.value = SceneLoader.LoadingOperation is null ? 0f
				: SceneLoader.LoadingOperation.allowSceneActivation
					? SceneLoader.LoadingOperation.progress
					: SceneLoader.LoadingOperation.progress / .9f;
		}

		private void Start()
		{
			this.InitialiseSlider();
		}

		private void Update()
		{
			this.UpdateSlider();
		}
	}
}
