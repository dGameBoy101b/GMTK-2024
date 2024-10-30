using UnityEngine;

public class Divider : Calculator<float,float>
{
	[SerializeField]
	private float _denominator;
	public float Denominator
	{
		get => this._denominator;
		set => this._denominator = value;
	}

	public override float Calculate(float input)
	{
		return input / this.Denominator;
	}
}
