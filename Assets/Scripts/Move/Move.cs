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

	private void FixedUpdate()
	{
		this.Body.velocity = this.CurrentDirection * this.MaxMoveSpeed;
	}
}
