using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
	[Tooltip("The bullet to control")]
	public Bullet Bullet;

	[Tooltip("How long this bullet lives for in seconds")]
	public float BaseLifetime = 1f;

	[Tooltip("The multiplier applied to the shot power before adding it to the base lifetime")]
	public float PowerCoefficient = -1f;

	public void OnShot()
	{
		var lifetime = this.Bullet.Power * this.PowerCoefficient + this.BaseLifetime;
		this.Invoke(nameof(this.Destroy), lifetime);
	}

	public void Destroy()
	{
		Destroy(this.Bullet.gameObject);
	}
}
