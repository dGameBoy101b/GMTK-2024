using UnityEngine;

public class Vector2Scaler : Calculator<float,  Vector2>
{
	[SerializeField]
	private Vector2 _base;
	public Vector2 Base
	{
		get => this._base;
		set => this._base = value;
	}

	public override Vector2 Calculate(float input)
	{
		return this.Base * input;
	}
}
