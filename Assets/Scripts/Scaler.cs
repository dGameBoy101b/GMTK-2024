using UnityEngine;

public class Scaler : MonoBehaviour
{
	[Tooltip("The transform to control the scale of")]
	public Transform Transform;

	[Tooltip("The base scaling to modify.\nFetched from transform at awake")]
	public Vector3 BaseScale = Vector3.one;

	public void FetchBaseScale()
	{
		this.BaseScale = this.Transform.localScale;
	}

	[Tooltip("The multiplier applied to the input value before adding the base scale")]
	public float Coefficient = 1f;

	public Vector3 CalculateScale(float value) => value * this.Coefficient * Vector3.one + this.BaseScale;

	public void UpdateScale(float value)
	{
		this.Transform.localScale = this.CalculateScale(value);
	}

	private void Awake()
	{
		this.FetchBaseScale();
	}
}
