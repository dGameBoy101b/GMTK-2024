using UnityEngine;

public class Aim : MonoBehaviour
{
	[Tooltip("The crosshiar to position")]
	public Transform Crosshair;

	[Tooltip("The direction this is aiming")]
	public Vector2 Direction = Vector2.right;

	[Tooltip("How far the crosshair should be positioned from this")]
	public float Radius = 1f;

	public void UpdateCrosshair()
	{
		this.Crosshair.position = (Vector2)this.transform.position + this.Direction * this.Radius;
	}

	private void Update()
	{
		this.UpdateCrosshair();
	}

	#region Gizmos
	public void DrawGizmo()
	{
		if (this.Crosshair == null)
			return;
		Gizmos.DrawSphere(this.Crosshair.position, .1f);
	}

	private void OnDrawGizmosSelected()
	{
		this.DrawGizmo();
	}
	#endregion
}
