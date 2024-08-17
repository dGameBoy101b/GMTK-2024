using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
	[Tooltip("The shoot component to control")]
	public Shoot Shoot;

	public void OnShoot(InputAction.CallbackContext context)
	{
		if (context.started)
			this.Shoot.IsCharging = true;
		if (context.canceled)
			this.Shoot.IsCharging = false;
	}
}
