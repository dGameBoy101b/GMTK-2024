using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
	[Tooltip("What shot this")]
	public Shoot Source = null;

	[Tooltip("The amount of power this was shot with")]
	public float Power = 0f;

	[Tooltip("The direction this was shot")]
	public Vector2 Direction = Vector2.zero;

	[Tooltip("Invoked when this has been shot.\nParameter is this")]
	public UnityEvent<Bullet> OnShot = new();

	internal void Shot(Shoot source, float power, Vector2 direction)
	{
		this.Source = source;
		this.Power = power;
		this.Direction = direction; 
		this.transform.position = source.transform.position;
		this.transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
		this.OnShot.Invoke(this);
	}
}
