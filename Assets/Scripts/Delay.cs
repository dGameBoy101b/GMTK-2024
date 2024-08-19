using UnityEngine;
using UnityEngine.Events;

public class Delay : MonoBehaviour
{
	[SerializeField]
	[Min(0)]
	[Tooltip("Number of seconds between this starting and completing")]
	private float _duration = 0;
	public float Duration
	{
		get => this._duration;
		set => this._duration = Mathf.Max(0, value);
	}

	[Tooltip("Invoked when this is done")]
	public UnityEvent OnDone = new();

	public void StartTimer()
	{
		this.Invoke(nameof(this.TimerDone), this.Duration);
	}

	private void TimerDone()
	{
		this.OnDone.Invoke();
	}
}
