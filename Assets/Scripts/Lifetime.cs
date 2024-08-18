using UnityEngine;

public class Lifetime : MonoBehaviour
{
	[Tooltip("The game object to destroy")]
	public GameObject GameObject;

	[Tooltip("How long this lives for in seconds")]
	public float BaseLifetime = 1f;

	[Tooltip("The multiplier applied to the input value before adding it to the base lifetime")]
	public float Coefficient = -1f;

	public void StartLife(float value)
	{
		var lifetime = value * this.Coefficient + this.BaseLifetime;
		this.Invoke(nameof(this.Destroy), lifetime);
	}

	public void Destroy()
	{
		Destroy(this.GameObject);
	}
}
