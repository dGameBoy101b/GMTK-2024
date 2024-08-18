using UnityEngine;

public class CooldownRadialBar : RadialBar
{
	[Tooltip("The shoot component to get cooldown data from")]
	public Shoot Shoot;

	public override float Minimum => 0;

	public override float Maximum => this.Shoot.MaxCooldown;

	public override float Value => this.Shoot.RemainingCooldown;
}
