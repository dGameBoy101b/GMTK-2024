using UnityEngine;

public class Explode : MonoBehaviour
{
	[Tooltip("The power of this explosion")]
	public float Power = 1f;

	[Tooltip("The explosion to pawn when this is destroyed")]
	public Explosion Explosion;

	public void DoExplode()
	{
		var explosion_object = Instantiate(this.Explosion.gameObject, this.transform.position, this.transform.rotation);
		var explosion = explosion_object.GetComponent<Explosion>();
		explosion.Explode(this.Power);
	}

	private void OnDestroy()
	{
		this.DoExplode();
	}
}
