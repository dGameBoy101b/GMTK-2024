using UnityEngine;
using UnityEngine.Timeline;
using FMODUnity;

namespace WinterwireGames.TimelineAdapters.FMOD
{
	[RequireComponent(typeof(StudioEventEmitter))]
	public class StudioEventEmitterTimelineAdapter : MonoBehaviour, ITimeControl
	{
		private StudioEventEmitter _emitter = null;
		public StudioEventEmitter Emitter
		{
			get
			{
				if (this._emitter == null)
					this._emitter = this.GetComponent<StudioEventEmitter>();
				return this._emitter;
			}
		}

		public void OnControlTimeStart()
		{
			this.Emitter.Play();
		}

		public void OnControlTimeStop()
		{
			this.Emitter.Stop();
		}

		public void SetTime(double time) {}
	}
}
