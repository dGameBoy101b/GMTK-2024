using UnityEngine;

public class BulletSize : MonoBehaviour
{
	[Tooltip("The transform to control the scale of")]
	public Transform Transform;

	[Tooltip("The scaling applied to the power before multiplying the scale")]
	public float PowerCoefficient = 1f;

	[Tooltip("The base scaling to modify.\nFetched from the current scale on awake")]
	public Vector3 BaseScale = Vector3.one;

	public void FetchBaseScale()
	{
		this.BaseScale = this.Transform.localScale;
		Debug.Log($"Fetched base scale: {this.BaseScale}", this);
	}

	public Vector3 CalculateScale(float power)
	{
		return power * this.PowerCoefficient * Vector3.one + this.BaseScale;
	}

	public void OnShot(Bullet bullet)
	{
		var scale = this.CalculateScale(bullet.Power);
		this.Transform.localScale = scale;
		Debug.Log($"Updated scale: {scale}", this);
	}

	private void Awake()
	{
		this.FetchBaseScale();
	}
}
