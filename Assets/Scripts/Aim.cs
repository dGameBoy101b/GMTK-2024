using UnityEngine;

public class Aim : MonoBehaviour
{
	[Tooltip("The direction this is aiming")]
	public Vector2 Direction = Vector2.right;

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
