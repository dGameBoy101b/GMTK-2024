using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
	[Tooltip("The health pool to subtract damage from")]
	public Health Health;

	[Tooltip("Invoked when this takes damage.\nParameter is damage amount")]
	public UnityEvent<float> OnTakeDamage = new();

	public void Damage(Damage damage)
	{
		if (damage == null)
			return;
		var amount = damage.FinalDamage;
		Debug.Log($"Took {amount} damage from {damage.name}", this);
		this.Health.CurrentHealth -= amount;
		this.OnTakeDamage.Invoke(amount);
	}

	public Damage FindDamage(Component other)
	{
		return other.GetComponentInChildren<Damage>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log($"Taking damage from {other.name}", this);
		this.Damage(this.FindDamage(other));
	}
}
