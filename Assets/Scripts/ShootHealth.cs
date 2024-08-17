using UnityEngine;

public class ShootHealth : MonoBehaviour
{
	[Tooltip("The health component to subtract health from")]
	public Health Health;

	[Tooltip("The multiplier applied to power before subtracting health")]
	public float PowerCoefficient = 1f;

	public void OnShot(float power)
	{
		this.Health.CurrentHealth -= this.PowerCoefficient * power;
	}
}
