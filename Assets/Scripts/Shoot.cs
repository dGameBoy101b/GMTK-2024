using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
	#region Power Charging
	[Tooltip("The maximum power this can charge up to")]
	[Min(0)]
	public float MaxPower = 10f;

	[Tooltip("How quickly power can charge up")]
	[Min(0)]
	public float ChargeRate = 1f;

	[Tooltip("Invoked every frame while this is charging.\nParameter is current charge amount")]
	public UnityEvent<float> OnChargeUp = new();

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
		}
	}

	public void UpdateCharge(float delta_time)
	{
		if (!this.IsCharging)
			return;
		this.CurrentPower += this.ChargeRate * delta_time;
	}
	#endregion

	#region Shooting
	[Tooltip("The aiming component used to determine shot direction")]
	public Aim Aim;

	[Tooltip("The bullet to instantiate when shooting")]
	public Bullet Bullet;

	[Tooltip("Invoked when this shoots.\nParameter is shot power")]
	public UnityEvent<float> OnShot = new();

	public void ReleaseShot()
	{
		var bullet_object = Instantiate(this.Bullet.gameObject);
		var bullet = bullet_object.GetComponent<Bullet>();
		var power = this.CurrentPower;
		this.CurrentPower = 0f;
		bullet.Shot(this, power, this.Aim.Direction.normalized);
		this.OnShot.Invoke(power);
	}
	#endregion

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
				this.ReleaseShot();
		}
	}

	private void Update()
	{
		this.UpdateCharge(Time.deltaTime);
	}
}
