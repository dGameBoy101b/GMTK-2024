using UnityEngine;

public class PowerBar : Bar
{
	[Tooltip("The charge shoot to fetch charge data from")]
	public ChargeShoot ChargeShoot;

	public override float Minimum => 0;

	public override float Maximum => this.ChargeShoot.MaxPower;

	public override float Value => this.ChargeShoot.CurrentPower;
}
