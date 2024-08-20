using UnityEngine;

public class Vector2Normaliser : Calculator<Vector2, Vector2>
{
	public override Vector2 Calculate(Vector2 input)
	{
		return input.normalized;
	}
}
