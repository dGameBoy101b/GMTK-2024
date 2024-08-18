using UnityEngine;
using UnityEngine.Serialization;

public class Explode : MonoBehaviour
{
	[SerializeField]
	[FormerlySerializedAs("Power")]
	[Tooltip("The power of this explosion")]
	private float _power = 1f;
	public float Power
	{
		get => this._power;
		set => this._power = value;
	}

	[SerializeField]
	[FormerlySerializedAs("Explosion")]
	[Tooltip("The explosion to spawn when this is destroyed")]
	private Explosion _explosion;
	public Explosion Explosion
	{
		get => this._explosion;
		set => this._explosion = value;
	}

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
