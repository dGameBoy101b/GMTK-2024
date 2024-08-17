using UnityEngine;

public class PowerBar : Bar
{
	[Tooltip("The shoot to fetch charge data from")]
	public Shoot Shoot;

	public override float Minimum => 0;

	public override float Maximum => this.Shoot.MaxPower;

	public override float Value => this.Shoot.CurrentPower;
}
