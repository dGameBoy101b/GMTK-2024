using UnityEngine;
using UnityEngine.Events;

public class End : MonoBehaviour
{
	[Tooltip("Invoked when this is destroyed")]
	public UnityEvent OnEnd = new();

	private void OnDestroy()
	{
		this.OnEnd.Invoke();
	}
}
