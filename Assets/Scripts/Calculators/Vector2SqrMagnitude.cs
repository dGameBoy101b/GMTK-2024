using UnityEngine;

public class Vector2SqrMagnitude : Calculator<Vector2, float>
{
	public override float Calculate(Vector2 input)
	{
		return input.sqrMagnitude;
	}
}
