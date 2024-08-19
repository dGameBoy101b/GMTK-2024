using UnityEngine;
using UnityEngine.Events;

public class MeleeAttack : MonoBehaviour
{
	[Tooltip("The gameobject to instantiate")]
	public GameObject Hit;

	[SerializeField]
	[Tooltip("The minimum number of seconds between attacks")]
	[Min(0)]
	private float _maxCooldown = 1f;
	public float MaxCooldown
	{ 
		get => this._maxCooldown;
		set => this._maxCooldown = Mathf.Max(0, value);
	}

	[SerializeField]
	[Tooltip("The rate at which this cools down")]
	[Min(0)]
	private float _cooldownRate = 1f;
	public float CooldownRate
	{
		get => this._cooldownRate;
		set => this._cooldownRate = Mathf.Max(0, value);
	}

	[Tooltip("Invoked when this attacks")]
	public UnityEvent OnAttack = new();

	[SerializeField]
	[Tooltip("The number of seconds until this can attack again")]
	[Min(0)]
	private float _remainingCooldown = 0f;
	public float RemainingCooldown
	{
		get => this._remainingCooldown;
		set => this._remainingCooldown = Mathf.Max(0, value);
	}

	public bool IsCooling => this.RemainingCooldown > 0;

	public void Strike(Vector3 position, Quaternion rotation)
	{
		if (this.IsCooling)
			return;
		this.RemainingCooldown = this.MaxCooldown;
		var hit = Instantiate(this.Hit, position, rotation);
		this.OnAttack.Invoke();
	}

	public void Strike(Collision2D collision)
	{
		if (this.IsCooling)
			return;
		var point = collision.GetContact(0).point;
		Vector3 position = new(point.x, point.y, this.transform.position.z);
		Quaternion rotation = Quaternion.LookRotation(position - this.transform.position);
		this.Strike(position, rotation);
	}

	public void UpdateCooldown(float delta_time)
	{
		this.RemainingCooldown -= this.CooldownRate * delta_time;
	}

	private void Update()
	{
		this.UpdateCooldown(Time.deltaTime);
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		this.Strike(collision);
	}
}
