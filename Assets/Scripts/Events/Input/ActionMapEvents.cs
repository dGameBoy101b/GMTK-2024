using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace WinterwireGames.Events.Input
{
	[AddComponentMenu("Events/Input/Action Map Events")]
	public class ActionMapEvents : PlayerInputEvents
	{
		#region Listeners List
		[Serializable]
		public struct InputActionListener
		{
			#region InputAction Fetching
			[Tooltip("The input action path used to search for an action.\n<map>/<action> is the preferred form but <action> still works")]
			public string Path;

			public InputAction GetAction(PlayerInput input) => input.actions[this.Path];
			#endregion

			#region Listeners
			[SerializeField]
			[Tooltip("Invoked every time the associated input action is updated.")]
			private UnityEvent<InputAction.CallbackContext> _onUpdate;
			public UnityEvent<InputAction.CallbackContext> OnUpdate => this._onUpdate;

			public void AddListeners(PlayerInput input)
			{
				var action = this.GetAction(input);
				if (action == null)
					throw new KeyNotFoundException(this.Path + " input action not found");
				action.started += this.OnUpdate.Invoke;
				action.performed += this.OnUpdate.Invoke;
				action.canceled += this.OnUpdate.Invoke;
			}

			public void RemoveListeners(PlayerInput input)
			{
				var action = this.GetAction(input);
				if (action == null)
					throw new KeyNotFoundException(this.Path + " input action not found");
				action.started -= this.OnUpdate.Invoke;
				action.performed -= this.OnUpdate.Invoke;
				action.canceled -= this.OnUpdate.Invoke;
			}
			#endregion

			public InputActionListener(string path = null)
			{
				this.Path = path ?? string.Empty;
				this._onUpdate = new();
			}
		}

		[Tooltip("The actions to listen to")]
		public List<InputActionListener> Listeners = new();
		#endregion

		#region Player Input Events Overrides
		protected override void AddListeners(PlayerInput input)
		{
			foreach (var listener in this.Listeners)
			{
				try
				{
					listener.AddListeners(input);
				}
				catch (KeyNotFoundException x)
				{
					Debug.LogError(x, this);
				}
			}
		}

		protected override void RemoveListeners(PlayerInput input)
		{
			foreach (var listener in this.Listeners)
			{
				try
				{
					listener.RemoveListeners(input);
				}
				catch (KeyNotFoundException x)
				{
					Debug.LogError(x, this);
				}
			}
		}
		#endregion
	}
}
