using UnityEngine;
using UnityEngine.Events;

public class HealthMax : MonoBehaviour
{
	public UnityEvent<float> OnMaxHealth = new();

	public void GetMaxHealth(Health health) => this.OnMaxHealth.Invoke(health.MaxHealth);
}
