using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Move : MonoBehaviour
{
	[SerializeField]
	[FormerlySerializedAs("Body")]
	[Tooltip("The body to control")]
	private Rigidbody2D _body;
	public Rigidbody2D Body
	{
		get => this._body;
		set => this._body = value;
	}

	[SerializeField]
	[Tooltip("How quickly this should move at max speed")]
	[FormerlySerializedAs("MaxMoveSpeed")]
	[Min(0)]
	private float _maxMoveSpeed = 1f;
	public float MaxMoveSpeed
	{
		get => this._maxMoveSpeed;
		set => this._maxMoveSpeed = Mathf.Max(0, value);
	}

	[SerializeField]
	[Tooltip("What direction this is currently moving")]
	[FormerlySerializedAs("CurrentDirection")]
	private Vector2 _currentDirection = Vector2.zero;
	public Vector2 CurrentDirection
	{
		get => this._currentDirection;
		set 
		{
			var old = this._currentDirection;
			this._currentDirection = value;
			if (old != value)
				this.OnDirectionChange.Invoke(value);
		}
	}

	[Tooltip("Invoked when the current direction is set")]
	public UnityEvent<Vector2> OnDirectionChange = new();

	[SerializeField]
	[FormerlySerializedAs("_dampingCoefficient")]
	[Tooltip("How quickly this should accelerate")]
	[Min(0)]
	private float _acceleration = Mathf.Infinity;
	public float Acceleration
	{
		get => this._acceleration;
		set => this._acceleration = Mathf.Max(value, 0);
	}

	public Vector2 CalculateForce(float delta_time, Vector2 velocity)
	{
		var difference = this.Target - velocity;
		var max_magnitude = difference.magnitude / delta_time;
		var force = this.Acceleration == Mathf.Infinity
			? difference.normalized * max_magnitude
			: Vector2.ClampMagnitude(difference * this.Acceleration, max_magnitude);
		this.LastForce = force;
		return force;
	}

	public void ApplyForce(float delta_time)
	{
		var force = this.CalculateForce(delta_time, this.Body.velocity);
		this.Body.AddForce(force, ForceMode2D.Force);
	}

	#region Gizmos
	public Vector2 Target => this.CurrentDirection * this.MaxMoveSpeed;

	public Vector2? LastForce { get; private set; } = null;

	public void DrawGizmo()
	{
		if (this.Body == null)
			return;
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(this.Body.position, this.Target);
		Gizmos.color = Color.white;
		Debug.DrawRay(this.Body.position, this.Body.velocity);
		if (this.LastForce == null)
			return;
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay(this.Body.position, this.LastForce.Value);
	}
	#endregion

	private void FixedUpdate()
	{
		this.ApplyForce(Time.fixedDeltaTime);
	}

	private void OnDrawGizmosSelected()
	{
		this.DrawGizmo();
	}
}
