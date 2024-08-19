using UnityEngine;
using UnityEngine.Events;

public class HealthCurrent : MonoBehaviour
{
	public UnityEvent<float> OnCurrentHealth = new();

	public void GetCurrentHealth(Health health) => this.OnCurrentHealth.Invoke(health.CurrentHealth);
}
