using UnityEngine;

public class LookAt2D : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The transform whose rotation should be controlled")]
	private Transform _transform;
	public Transform Transform
	{
		get => this._transform;
		set => this._transform = value;
	}

	[SerializeField]
	[Tooltip("The target to look at")]
	private Transform _target;
	public Transform Target
	{
		get => this._target;
		set => this._target = value;
	}

	public void UpdateRotation()
	{
		var forward = (Vector2)this.Target.position - (Vector2)this.Transform.position;
		var angle = Vector2.SignedAngle(Vector2.right, forward);
		var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		this.Transform.rotation = rotation;
	}

	private void Update()
	{
		this.UpdateRotation();
	}
}
