using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
	[Tooltip("The aim component to control")]
	public Aim Aim;

	[SerializeField]
	[Tooltip("The camera used to convert pointer positions to world space.\nDefaults to the main camera")]
	private Camera _camera;
	public Camera Camera
	{
		get 
		{ 
			if (this._camera == null) 
				this._camera = Camera.main; 
			return this._camera; 
		}
		set => this._camera = value;
	}

	[Tooltip("Whether the player is currently using a pointer to aim")]
	public bool IsPointer = false;

	[Tooltip("The last screen position the pointer was")]
	public Vector2 PointerScreenPosition = Vector2.zero;

	public void OnAim(InputAction.CallbackContext context)
	{
		if (!context.performed)
			return;
		this.IsPointer = context.control.device is Pointer;
		var value = context.ReadValue<Vector2>();
		if (this.IsPointer)
		{
			this.PointerScreenPosition = value;
		}
		this.Aim.Direction = this.IsPointer
			? this.CalculatePointerDirection(value)
			: value.normalized;
	}

	public Vector2 CalculatePointerDirection(Vector2 pointer_position)
	{
		Vector3 screen = new(
			pointer_position.x,
			pointer_position.y,
			Vector3.Dot(this.Aim.transform.position - this.Camera.transform.position, this.Camera.transform.forward));
		var world = this.Camera.ScreenToWorldPoint(screen);
		return (world - this.Aim.transform.position) / this.Aim.Radius;
	}

	public void UpdateDirection()
	{
		if (!this.IsPointer)
			return;
		this.Aim.Direction = this.CalculatePointerDirection(this.PointerScreenPosition);
	}

	private void Update()
	{
		this.UpdateDirection();
	}
}
