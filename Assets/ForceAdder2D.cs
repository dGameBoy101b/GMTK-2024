using UnityEngine;

public class ForceAdder2D : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The body to apply forces to")]
	private Rigidbody2D _body;
	public Rigidbody2D Body
	{
		get => this._body;
		set => this._body = value;
	}

	[SerializeField]
	[Tooltip("The mode used to apply forces")]
	private ForceMode2D _mode;
	public ForceMode2D Mode
	{
		get => this._mode;
		set => this._mode = value;
	}

	public void AddForce(Vector2 force)
	{
		this.Body.AddForce(force, this.Mode);
	}
}
