using UnityEngine;

public class Crosshair : MonoBehaviour
{
	[Tooltip("The aim component to fetch the direction from")]
	public Aim Aim;

	[Tooltip("The transform whose position should be controlled")]
	public RectTransform Transform;

	[SerializeField]
	[Tooltip("The camera used to convert from world coordinates to screen coordinates.\nDefaults to the main camera")]
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

	public void UpdateAnchors()
	{
		this.Transform.anchorMin = Vector2.zero;
		this.Transform.anchorMax = Vector2.zero;
	}

	public void UpdatePosition()
	{
		this.Transform.position = this.Camera.WorldToScreenPoint(this.Aim.transform.position + (Vector3)this.Aim.Direction); ;
	}

	private void Awake()
	{
		this.UpdateAnchors();
	}

	private void LateUpdate()
	{
		this.UpdatePosition();
	}
}
