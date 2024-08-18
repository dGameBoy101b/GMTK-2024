using FMODUnity;
using System.Collections.Generic;
using UnityEngine;

namespace WinterwireGames.FMODParameters
{
	public class StringFMODParameter : MonoBehaviour
	{
		#region Emitter
		[SerializeField]
		[Tooltip("The emitter whose parameters should be accessed")]
		private StudioEventEmitter _emitter;
		public virtual StudioEventEmitter FindEmitter() => this.GetComponentInParent<StudioEventEmitter>();
		public StudioEventEmitter Emitter
		{
			get
			{
				if (this._emitter == null)
					this._emitter = this.FindEmitter();
				return this._emitter;
			}
			set => this._emitter = value;
		}
		#endregion

		[Tooltip("The name of the parameter to access")]
		public string ParameterName;

		[SerializeField]
		[Tooltip("The labels this expects to find in the FMOD parameter")]
		private List<string> _acceptedValues = new();
		public List<string> AccecptedValues => this._acceptedValues;

		public string Value
		{
			set
			{
				int index = this.AccecptedValues.IndexOf(value);
				if (index == -1)
					throw new KeyNotFoundException(value+" not found");
				this.Emitter.SetParameter(this.ParameterName, index);
			}
		}
	}
}
