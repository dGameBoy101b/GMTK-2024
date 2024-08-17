using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace WinterwireGames.Events.Input
{
	public abstract class PlayerInputEvents : MonoBehaviour
	{
		#region Player Input Fetching
		[SerializeField]
		[Tooltip("The player input to attach listeners to")]
		private PlayerInput _playerInput = null;
		public PlayerInput PlayerInput
		{
			get
			{
				if (this._playerInput == null)
					this.PlayerInput = this.FindPlayerInput();
				return this._playerInput;
			}
			set
			{
				var old = this._playerInput;
				this._playerInput = value;
				if (!this.isActiveAndEnabled)
					return;
				if (old != null)
					this.Unsubscribe(old);
				if (value != null)
					this.Subscribe(value);
			}
		}

		protected virtual PlayerInput FindPlayerInput() => this.GetComponentInParent<PlayerInput>();
		#endregion

		#region Listener Management
		private readonly HashSet<PlayerInput> _subscribedTo = new();
		public IReadOnlyCollection<PlayerInput> SubscribedTo => this._subscribedTo;

		protected abstract void AddListeners(PlayerInput input);
		protected void Subscribe(PlayerInput input)
		{
			if (input == null)
				throw new ArgumentNullException(nameof(input), "Cannot add listeners to null player input");
			if (this._subscribedTo.Contains(input))
				return;
			this.AddListeners(input);
			this._subscribedTo.Add(input);
		}

		protected abstract void RemoveListeners(PlayerInput input);
		protected void Unsubscribe(PlayerInput input)
		{
			if (input == null || !this._subscribedTo.Contains(input))
				return;
			this.RemoveListeners(input);
			this._subscribedTo.Remove(input);
		}
		#endregion

		#region Unity Messages
		private void OnEnable()
		{
			this.Subscribe(this.PlayerInput);
		}

		private void OnDisable()
		{
			this.Unsubscribe(this.PlayerInput);
		}
		#endregion
	}
}
