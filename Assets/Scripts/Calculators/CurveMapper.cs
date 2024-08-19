using UnityEngine;

public class CurveMapper : Calculator<float, float>
{
	public AnimationCurve Curve = new();

	public override float Calculate(float input)
	{
		return this.Curve.Evaluate(input);
	}
}
