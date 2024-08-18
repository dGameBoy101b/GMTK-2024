using UnityEngine;

public class MoveHealth : MonoBehaviour
{
	[Tooltip("The move component to control")]
	public Move Move;

	[Tooltip("The max speed this should move at")]
	public float BaseSpeed;

	[Tooltip("The multiplier applied to health before adding it to the base speed")]
	public float HealthCoefficient;

	[Tooltip("The health component the current health is fetched from")]
	public Health Health;

	public void UpdateSpeed()
	{
		this.Move.MaxMoveSpeed = this.BaseSpeed + this.HealthCoefficient * this.Health.CurrentHealth;
	}

	private void Awake()
	{
		this.UpdateSpeed();
	}
}
