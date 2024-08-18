using UnityEngine;
using UnityEngine.Audio;

namespace WinterwireGames.SceneManagement
{
	public class AudioMixerParameter : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The audio mixer to interface with")]
		public AudioMixer Mixer;

		[SerializeField]
		[Tooltip("The name of the exposed parameter this controls")]
		public string ParameterName;

		public float Value
		{
			get
			{
				float value;
				this.Mixer.GetFloat(this.ParameterName, out value);
				return value;
			}
			set
			{
				this.Mixer.SetFloat(this.ParameterName, value);
			}
		}

		public void Clear()
		{
			this.Mixer.ClearFloat(this.ParameterName);
		}
	}
}
