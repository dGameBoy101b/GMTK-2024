using UnityEngine;
using UnityEngine.Events;

public class ExplosionPower : MonoBehaviour
{
	[Tooltip("Invoked with the power of the given explosion")]
	public UnityEvent<float> OnPower = new();

	public void GetPower(Explosion explosion)
	{
		this.OnPower.Invoke(explosion.Power);
	}
}
