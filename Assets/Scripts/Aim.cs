using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Aim : MonoBehaviour
{
	[SerializeField]
	[FormerlySerializedAs("Direction")]
	[Tooltip("The direction this is aiming")]
	private Vector2 _direction = Vector2.right;
	public Vector2 Direction
	{
		get => this._direction;
		set
		{
			this._direction = value;
			this.OnDirectionChange.Invoke(value);
		}
	}

	public UnityEvent<Vector2> OnDirectionChange = new();

	#region Gizmos
	public void DrawGizmo()
	{
		Gizmos.DrawRay(this.transform.position, this.Direction);
	}

	private void OnDrawGizmosSelected()
	{
		this.DrawGizmo();
	}
	#endregion
}
