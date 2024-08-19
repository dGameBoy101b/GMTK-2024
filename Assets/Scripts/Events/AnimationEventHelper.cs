using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHelper : MonoBehaviour
{
    [SerializeField]
	[Tooltip("Invoked when Animation Event triggers it")]
	private UnityEvent _onAnimationEvent = new UnityEvent();

	public UnityEvent OnAnimationEvent
	{
		get => this._onAnimationEvent;
	}

    public void InvokeEvent()
    {
        this.OnAnimationEvent.Invoke();
    }
}
