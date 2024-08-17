using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace WinterwireGames.Events.Input
{
	[AddComponentMenu("Events/Input/Controls Changed Event")]
	public class ControlsChangedEvent : PlayerInputEvents
	{
		[SerializeField]
		[Tooltip("Invoked when the controls change")]
		private UnityEvent<PlayerInput> _onControlsChanged = new();
		public UnityEvent<PlayerInput> OnControlsChanged => this._onControlsChanged;

		#region Player Input Events Overrides
		protected override void AddListeners(PlayerInput input)
		{
			input.onControlsChanged += this.OnControlsChanged.Invoke;
			input.controlsChangedEvent.AddListener(this.OnControlsChanged.Invoke);
		}

		protected override void RemoveListeners(PlayerInput input)
		{
			input.onControlsChanged -= this.OnControlsChanged.Invoke;
			input.controlsChangedEvent.RemoveListener(this.OnControlsChanged.Invoke);
		}
		#endregion

		#region Unity Messages
		private void OnEnable()
		{
			this.OnControlsChanged.Invoke(this.PlayerInput);
		}
		#endregion
	}
}
