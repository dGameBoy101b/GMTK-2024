using UnityEngine;

public class Vector3Scaler : Calculator<float, Vector3>
{
	[SerializeField]
	private Vector3 _base;
	public Vector3 Base
	{
		get => this._base;
		set => this._base = value;
	}

	[SerializeField]
	private float _coefficient = 1f;
	public float Coefficient
	{
		get => this._coefficient;
		set => this._coefficient = value;
	}

	public override Vector3 Calculate(float input)
	{
		return input * this.Coefficient * this.Base;
	}
}
