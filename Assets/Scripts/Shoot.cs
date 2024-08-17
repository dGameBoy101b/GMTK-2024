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
	public float MaxCooldown = 1;

	public bool IsCooling => this.RemainingCooldown > 0;

	[SerializeField]
	[Tooltip("How long this still needs to cool down for in seconds")]
	private float _remainingCooldown = 0f;
	public float RemainingCooldown
	{
		get => this._remainingCooldown;
		set
		{
			var old = this._remainingCooldown;
			value = Mathf.Clamp(value, 0, this.MaxCooldown);
			this._remainingCooldown = value;
			if (value < old)
				this.OnCooldown.Invoke(value);
			if (old > 0 && value == 0)
				this.OnCooldownEnd.Invoke();
		}
	}

	[Tooltip("Invoked every frame while this cools down.\nParameter is remaining cooldown time")]
	public UnityEvent<float> OnCooldown = new();

	[Tooltip("Invoked when this has finished cooling down")]
	public UnityEvent OnCooldownEnd = new();

	public void Shot()
	{
		if (this.IsCooling)
			return;
		this.RemainingCooldown = this.MaxCooldown;
		var bullet_object = Instantiate(this.Bullet.gameObject);
		var bullet = bullet_object.GetComponent<Bullet>();
		bullet.Shot(this, this.Power, this.Aim.Direction.normalized);
		this.OnShot.Invoke(this.Power);
	}

	public void UpdateCooldown(float delta_time)
	{
		this.RemainingCooldown -= delta_time;
	}

	private void Update()
	{
		this.UpdateCooldown(Time.deltaTime);
	}
}
