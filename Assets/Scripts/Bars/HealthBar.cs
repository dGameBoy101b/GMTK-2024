using UnityEngine;

public class HealthBar : Bar
{
	[Tooltip("The health component to listen to")]
	public Health Health;

	public override float Minimum => 0;

	public override float Maximum => this.Health.MaxHealth;

	public override float Value => this.Health.CurrentHealth;
}
