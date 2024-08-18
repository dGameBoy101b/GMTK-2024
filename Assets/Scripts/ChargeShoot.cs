using UnityEngine;
using UnityEngine.Events;

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

	[Tooltip("Invoked when this starts charging")]
	public UnityEvent OnStartCharge = new();

	[Tooltip("Invoked every frame while this is charging.\nParameter is current charge amount")]
	public UnityEvent<float> OnChargeUp = new();

	[Tooltip("How quickly shots should cool down")]
	public float BaseCooldown = 1f;

	[Tooltip("The multiplier applied to the power before adding to the base cooldown")]
	public float PowerCooldownCoefficient = 1f;

	[Tooltip("The cool down duration calculated for the previous shot")]
	public float LastCooldown;

	[Tooltip("Invoked every frame while this cools down.\nParameter is current charge amount")]
	public UnityEvent<float> OnCooldown = new();

	[Tooltip("Invoked when this finishes cooling down")]
	public UnityEvent OnCooldownEnd = new();

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
			if (old == 0 && value > 0)
				this.OnStartCharge.Invoke();
			if (value > old)
				this.OnChargeUp.Invoke(value);
			if (value < old)
				this.OnCooldown.Invoke(value);
			if (old > 0 && value == 0)
				this.OnCooldownEnd.Invoke();
		}
	}

	public void Shot()
	{
		if (this.Shoot.IsCooling)
			return;
		this.LastCooldown = this.CurrentPower * this.PowerCooldownCoefficient + this.BaseCooldown;
		this.Shoot.MaxCooldown = this.LastCooldown;
		this.Shoot.Power = this.CurrentPower;
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
		if (!this.Shoot.IsCooling && this.IsCharging)
			this.CurrentPower += this.ChargeRate * delta_time;
		else
			this.CurrentPower = 0;
	}

	private void Update()
	{
		this.UpdateCharge(Time.deltaTime);
	}
}
