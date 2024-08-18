using UnityEngine;

namespace WinterwireGames.SceneManagement
{
	public class VolumeAudioMixerParameter : AudioMixerParameter
	{
		[SerializeField]
		[Tooltip("The coefficient used to convert between decibels and percentage")]
		public float Coefficient = 20f;

		[SerializeField]
		[Tooltip("The decibel value used for 0 percent")]
		public float Minimum = -144f;

		public float PercentageValue
		{
			get => this.Value <= this.Minimum 
				? 0f 
				: Mathf.Pow(10, this.Value / this.Coefficient) * 100f;
			set => this.Value = value == 0 
				? this.Minimum 
				: this.Coefficient * Mathf.Log10(value / 100f);
		}
	}
}
