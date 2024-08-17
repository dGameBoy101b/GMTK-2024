using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace WinterwireGames.Events.Input
{
	[AddComponentMenu("Events/Input/Input Action State Events")]
	public class InputActionStateEvents : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Invoked when an input action is started")]
		private UnityEvent<InputAction.CallbackContext> _onStart = new UnityEvent<InputAction.CallbackContext>();

		public UnityEvent<InputAction.CallbackContext> OnStart { get => this._onStart; }

		[SerializeField]
		[Tooltip("Invoked when an input action is performed")]
		private UnityEvent<InputAction.CallbackContext> _onPerform = new UnityEvent<InputAction.CallbackContext>();

		public UnityEvent<InputAction.CallbackContext> OnPerform { get => this._onPerform; }

		[SerializeField]
		[Tooltip("Invoked when an input action is cancelled")]
		private UnityEvent<InputAction.CallbackContext> _onCancel = new UnityEvent<InputAction.CallbackContext>();

		public UnityEvent<InputAction.CallbackContext> OnCancel { get => this._onCancel; }

		[SerializeField]
		[Tooltip("Invoked when an input is updated")]
		private UnityEvent<InputAction.CallbackContext> _onPassthrough = new UnityEvent<InputAction.CallbackContext>();

		public UnityEvent<InputAction.CallbackContext> OnPassthrough { get => this._onPassthrough; }

		public void Input(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				this.OnStart.Invoke(context);
			}

			if (context.performed)
			{
				this.OnPerform.Invoke(context);
			}
			
			if (context.canceled)
			{
				this.OnCancel.Invoke(context);
			}
			
			this.OnPassthrough.Invoke(context);
		}
	}
}
