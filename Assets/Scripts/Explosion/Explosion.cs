using UnityEngine;
using UnityEngine.Events;

public class Explosion : MonoBehaviour
{
	[Tooltip("The power of this explosion")]
	public float Power;

	[Tooltip("Invoked when this explodes")]
	public UnityEvent<Explosion> OnExplode = new();

	internal void Explode(float power)
	{
		this.Power = power;
		this.OnExplode.Invoke(this);
	}
}
