using System;
using UnityEngine;

namespace WinterwireGames.MaterialParameters
{
	public abstract class MaterialParameter<ValueType> : MonoBehaviour
		where ValueType : IEquatable<ValueType>
	{
		[Tooltip("The material whose parameters should be accessed")]
		public Material Material;

		[Tooltip("The name of the parameter to access")]
		public string ParameterName;

		public enum UpdateMode
		{
			[Tooltip("No change")]
			Off,
			[Tooltip("Pull value from material")]
			Pull,
			[Tooltip("Push value to material")]
			Push
		}
		[Tooltip("Which direction data should flow each frame")]
		public UpdateMode Mode;

		[SerializeField]
		[Tooltip("The cached value")]
		public ValueType Value;

		public bool HasPushed { get; private set; } = false;
		public ValueType LastPushedValue { get; private set; }

		public abstract ValueType MaterialValue { get; set; }

		public void PushValueToMaterial()
		{
			if (this.HasPushed && this.LastPushedValue.Equals(this.Value))
				return;
			this.HasPushed = true;
			this.LastPushedValue = this.Value;
			this.MaterialValue = this.Value;
		}

		public void PullValueFromMaterial()
		{
			this.Value = this.MaterialValue;
		}

		#region Unity Messages
		private void Update()
		{
			switch (this.Mode)
			{
				case UpdateMode.Pull:
					this.PullValueFromMaterial();
					break;
				case UpdateMode.Push:
					this.PushValueToMaterial();
					break;
			}
		}

		private void OnDisable()
		{
			this.HasPushed = false;
		}
		#endregion
	}
}
