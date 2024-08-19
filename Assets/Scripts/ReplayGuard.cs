using FMOD.Studio;
using FMODUnity;
using System.Collections.Generic;
using UnityEngine;

public class ReplayGuard : MonoBehaviour
{
	[Tooltip("The emitter to stop replays of")]
	public StudioEventEmitter Emitter;

	public List<PLAYBACK_STATE> BlockedStates = new(new PLAYBACK_STATE[]{PLAYBACK_STATE.PLAYING});

	public bool CanPlay()
	{
		var instance = this.Emitter.EventInstance;
		if (!instance.isValid())
			return true;
		PLAYBACK_STATE state;
		var result = instance.getPlaybackState(out state);
		if (result != FMOD.RESULT.OK)
		{
			Debug.LogWarning($"Failed to check FMOD instance playback state: {result}", this);
			return true;
		}
		return !this.BlockedStates.Contains(state);
	}

	public void Play()
	{
		if (!this.CanPlay())
			return;
		this.Emitter.Play();
	}
}
