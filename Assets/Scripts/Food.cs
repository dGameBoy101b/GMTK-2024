using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
	[Tooltip("How much this heals when eaten")]
	public float HealthValue = 1f;

	[Tooltip("Invoked when this is eaten")]
	public UnityEvent OnEat = new();

	internal void Eat()
	{
		this.OnEat.Invoke();
		Destroy(this.gameObject);
	}
}
