using UnityEngine;

public class Knockback : MonoBehaviour
{
	[SerializeField]
	private float _magnitude = 1f;
	public float Magnitude
	{
		get => this._magnitude;
		set
		{
			this._magnitude = value;
			Debug.Log($"Knockback set to {value}", this);
		}
	}

	public void Apply(Rigidbody2D rigidbody)
	{
		var diff = rigidbody.position - (Vector2)transform.position;
		var force = this.Magnitude/* / diff.sqrMagnitude*/ * diff.normalized;
		rigidbody.AddForce(force, ForceMode2D.Impulse);
		Debug.DrawRay(rigidbody.position, force, Color.magenta, .1f);
		Debug.Log($"Knockback applied to {rigidbody.name}: {force.magnitude}", this);
	}

	public Rigidbody2D FindBody(Component component) => component.GetComponentInParent<Rigidbody2D>();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		this.Apply(this.FindBody(collision));
	}
}
