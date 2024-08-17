using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ChargeShoot : MonoBehaviour
{
	[Tooltip("The shoot component to control")]
	public Shoot Shoot;

	[Tooltip("The maximum power this can charge up to")]
	[Min(0)]
	public float MaxPower = 10f;

	[Tooltip("How quickly power can charge up")]
	[Min(0)]
	public float ChargeRate = 1f;

	[Tooltip("Invoked every frame while this is charging.\nParameter is current charge amount")]
	public UnityEvent<float> OnChargeUp = new();

	[Tooltip("How quickly shots should cool down")]
	public float BaseCooldown = 1f;

	[Tooltip("The multiplier applied to the power before adding to the base cooldown")]
	public float PowerCooldownCoefficient = 1f;

	[Tooltip("The cool down duration calculated for the previous shot")]
	public float LastCooldown;

	[Tooltip("Invoked every frame while this cools down.\nParameter is current charge amount")]
	[FormerlySerializedAs("OnCoolDown")]
	public UnityEvent<float> OnCooldown = new();

	[SerializeField]
	[Tooltip("The current amount of power this has charged")]
	private float _currentPower = 0f;
	public float CurrentPower
	{
		get => this._currentPower;
		set
		{
			value = Mathf.Clamp(value, 0f, this.MaxPower);
			var old = this._currentPower;
			this._currentPower = value;
			if (old < value)
				this.OnChargeUp.Invoke(value);
			if (value > old)
				this.OnCooldown.Invoke(value);
		}
	}

	public void Shot()
	{
		if (this.Shoot.IsCooling)
			return;
		this.LastCooldown = this.CurrentPower * this.PowerCooldownCoefficient + this.BaseCooldown;
		this.Shoot.Cooldown = this.LastCooldown;
		this.Shoot.Shot();
	}

	[Tooltip("Whether this should be charging a shot")]
	private bool _isCharging = false;
	public bool IsCharging
	{
		get => this._isCharging;
		set
		{
			var old = this._isCharging;
			this._isCharging = value;
			if (old && !value)
				this.Shot();
		}
	}

	public void UpdateCharge(float delta_time)
	{
		if (this.Shoot.IsCooling)
			this.CurrentPower -= this.LastCooldown * delta_time;
		else if (this.IsCharging)
			this.CurrentPower += this.ChargeRate * delta_time;
	}

	private void Update()
	{
		this.UpdateCharge(Time.deltaTime);
	}
}
