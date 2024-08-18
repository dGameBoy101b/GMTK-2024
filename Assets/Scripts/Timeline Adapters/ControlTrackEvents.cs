using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

namespace WinterwireGames.TimelineAdapters
{
	public class ControlTrackEvents : MonoBehaviour, ITimeControl
	{
		#region Start
		[SerializeField]
		[Tooltip("Invoked when a bound control clip starts")]
		private UnityEvent _onStart = new();
		public UnityEvent OnStart => this._onStart;

		public void OnControlTimeStart()
		{
			this.OnStart.Invoke();
		}
		#endregion

		#region Stop
		[SerializeField]
		[Tooltip("Invoked when a bound control clip stops")]
		private UnityEvent _onStop = new();
		public UnityEvent OnStop => this._onStop;

		public void OnControlTimeStop()
		{
			this.OnStop.Invoke();
		}
		#endregion

		#region Update
		[SerializeField]
		[Tooltip("Invoked every frame while a bound control clip is playing.\n"
			+"First parameter is the local clip time.\n"
			+"This is dependent on the update method of the playable director")]
		private UnityEvent<double> _onUpdate = new();
		public UnityEvent<double> OnUpdate => this._onUpdate;

		public void SetTime(double time)
		{
			this.OnUpdate.Invoke(time);
		}
		#endregion
	}
}
