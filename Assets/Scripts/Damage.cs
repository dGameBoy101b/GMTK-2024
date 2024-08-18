using UnityEngine;

public class Damage : MonoBehaviour
{
	[Tooltip("A flat bonus to damage")]
	public float BaseDamage = 1f;

	[Tooltip("The multiplier applied to the input value before adding the base")]
	public float Coefficient = 1f;

	[Tooltip("The final calculated damage.\nCalculated with a value of 0 on awake")]
	public float FinalDamage = 1f;

	public float CalculateDamage(float value) => this.Coefficient * value + this.BaseDamage;

	public void SetDamage(float value)
	{
		this.FinalDamage = this.CalculateDamage(value);
	}

	private void Awake()
	{
		this.SetDamage(0);
	}
}
