using UnityEngine;

public class Vector3MagnitudeAdder : Calculator<float,Vector3>
{
	public Vector3 Base;

	public float Coefficient;

	public override Vector3 Calculate(float value) => this.Coefficient * value * Vector3.one + this.Base;
}
