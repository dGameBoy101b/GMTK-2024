using UnityEngine;
using UnityEngine.Events;

public class BulletDirection : MonoBehaviour
{
	[Tooltip("Invoked with the direction of the given bullet")]
	public UnityEvent<Vector2> OnDirection = new();

	public void GetDirection(Bullet bullet)
	{
		this.OnDirection.Invoke(bullet.Direction);
	}
}
