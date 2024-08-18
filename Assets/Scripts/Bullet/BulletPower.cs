using UnityEngine;
using UnityEngine.Events;

public class BulletPower : MonoBehaviour
{
	[Tooltip("Invoked with the bullet power")]
	public UnityEvent<float> OnPower = new();

	public void GetPower(Bullet bullet)
	{
		this.OnPower.Invoke(bullet.Power);
	}
}
