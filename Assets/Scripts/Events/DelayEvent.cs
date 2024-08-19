using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WinterwireGames.Events
{
	public class DelayEvent : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The number of seconds to wait before invoking this event.\n0 will wait for 1 frame")]
		[Min(0f)]
		private float _delay = 0f;
		public float Delay
		{
			get => this._delay;
			set => this._delay = Mathf.Max(0, value);
		}

		[SerializeField]
		[Tooltip("Invoked when this is invoked after its delay")]
		private UnityEvent _onTimeUp = new();
		public UnityEvent OnTimeUp => this._onTimeUp;

		[SerializeField]
		[Tooltip("Invoked when this is canceled")]
		private UnityEvent _onCancel = new();
		public UnityEvent OnCancel => this._onCancel;

		private readonly List<float> _invocationTimes = new();
		public IReadOnlyCollection<float> InvocationTimes => this._invocationTimes;

		public void Invoke()
		{
			this.Invoke(Time.time);
		}

		public void Invoke(float current_time)
		{
			this._invocationTimes.Add(current_time + this.Delay);
		}

		public void UpdateInvocations(float current_time)
		{
			for (int remove_count = this._invocationTimes.RemoveAll((time) => time <= current_time); 
				remove_count > 0; --remove_count)
				this.OnTimeUp.Invoke();
		}

		public void CancelAll()
		{
			bool did_cancel = this.InvocationTimes.Count > 0;
			this._invocationTimes.Clear();
			if (did_cancel)
				this.OnCancel.Invoke();
		}

		private void Update()
		{
			this.UpdateInvocations(Time.time);
		}

		private void OnDisable()
		{
			this.CancelAll();
		}
	}
}
