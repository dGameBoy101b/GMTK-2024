using UnityEngine;

public class Move : MonoBehaviour
{
	[Tooltip("The body to control")]
	public Rigidbody2D Body;

	[Tooltip("How quickly this should move at max speed")]
	[Min(0)]
	public float MaxMoveSpeed = 1f;

	[Tooltip("What direction this is currently moving")]
	public Vector2 CurrentDirection = Vector2.zero;

	private void FixedUpdate()
	{
		this.Body.velocity = this.CurrentDirection * this.MaxMoveSpeed;
	}
}
