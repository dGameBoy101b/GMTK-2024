using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	[Tooltip("The maximum health this can have")]
	public float MaxHealth = 100;

	[Tooltip("Invoked when health increases.\nParameter is current health")]
	public UnityEvent<float> OnIncrease = new();

	[Tooltip("Invoked when this increases to max health")]
	public UnityEvent OnFull = new();

	[Tooltip("Invoked when health decreases.\nParameter is current health")]
	public UnityEvent<float> OnDecrease = new();

	[Tooltip("Invoked when this drops to 0 health")]
	public UnityEvent OnEmpty = new();

	[SerializeField]
	[Tooltip("The health this currently has")]
	private float _currentHealth = 100;
	public float CurrentHealth
	{
		get => this._currentHealth;
		set
		{
			value = Mathf.Clamp(value, 0, this.MaxHealth);
			var old = this._currentHealth;
			this._currentHealth = value;
			if (old < value)
				this.OnIncrease.Invoke(value);
			if (old > value)
				this.OnDecrease.Invoke(value);
			if (old > 0 && value == 0)
				this.OnEmpty.Invoke();
			if (old < this.MaxHealth && value == this.MaxHealth)
				this.OnFull.Invoke();
		}
	}

	public void Increase(float amount) => this.CurrentHealth += amount;
}
