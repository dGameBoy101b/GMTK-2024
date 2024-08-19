using UnityEngine;
using UnityEngine.Events;

public class QuickShoot : MonoBehaviour
{
	[Tooltip("The shoot component to control")]
	public Shoot Shoot;

	[Tooltip("The minimum duration between shots")]
	public float Cooldown = .1f;

	[Tooltip("The power put into each shot")]
	public float Power = 1f;

	[Tooltip("Whether this is currently shooting")]
	public bool IsShooting = false;

	[Tooltip("Invoked when this shoots a shot")]
	public UnityEvent OnShot = new();

	public void TryShot()
	{
		if (!this.IsShooting || this.Shoot.IsCooling)
			return;
		this.Shoot.Power = this.Power;
		this.Shoot.MaxCooldown = this.Cooldown;
		this.Shoot.Shot();
		this.OnShot.Invoke();
	}

	public void Update()
	{
		this.TryShot();
	}
}
