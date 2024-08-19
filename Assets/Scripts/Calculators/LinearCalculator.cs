using UnityEngine;

public class LinearCalculator : Calculator<float,float>
{
	[Tooltip("The flat bonus added to the output")]
	public float Base;

	[Tooltip("The multiplier applied to the input before adding the base")]
	public float Coefficient;

	public override float Calculate(float input) => this.Base + this.Coefficient * input;
}
