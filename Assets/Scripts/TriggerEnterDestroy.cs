using UnityEngine;
using WinterwireGames.PhysicsHelpers;

public class TriggerEnterDestroy : MonoBehaviour
{
	[Tooltip("The layers to cause this to destroy itself")]
	public LayerMask DestroyMask;

	[Tooltip("The game object to destroy on trigger enter")]
	public GameObject GameObject;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (this.DestroyMask.HasLayer(other.gameObject.layer))
			Destroy(this.GameObject);
	}
}
