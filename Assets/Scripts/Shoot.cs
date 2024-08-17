using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
	[Tooltip("The aiming component used to determine shot direction")]
	public Aim Aim;

	[Tooltip("The power to shoot bullets with")]
	public float Power = 1;

	[Tooltip("The bullet to instantiate when shooting")]
	public Bullet Bullet;

	[Tooltip("Invoked when this shoots.\nParameter is shot power")]
	public UnityEvent<float> OnShot = new();

	[Tooltip("The minimum duration between shots")]
	public float Cooldown = 1;

	[Tooltip("Whether this is currently cooling down from a previous shot")]
	public bool IsCooling = false;

	[Tooltip("Invoked when this has finished cooling down")]
	public UnityEvent OnCooldownEnd = new();

	public void EndCooldown()
	{
		this.IsCooling = false;
		this.OnCooldownEnd.Invoke();
	}

	public void Shot()
	{
		if (this.IsCooling)
			return;
		this.IsCooling = true;
		this.Invoke(nameof(this.EndCooldown), this.Cooldown);
		var bullet_object = Instantiate(this.Bullet.gameObject);
		var bullet = bullet_object.GetComponent<Bullet>();
		bullet.Shot(this, this.Power, this.Aim.Direction.normalized);
		this.OnShot.Invoke(this.Power);
	}
}
