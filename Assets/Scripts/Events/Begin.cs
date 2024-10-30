using UnityEngine;
using UnityEngine.Events;

public class Begin : MonoBehaviour
{
	public UnityEvent OnStart = new();

	private void Start()
	{
		this.OnStart.Invoke();
	}
}
