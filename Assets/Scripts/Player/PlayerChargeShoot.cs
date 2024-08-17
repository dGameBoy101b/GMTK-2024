using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChargeShoot : MonoBehaviour
{
	[Tooltip("The charge shoot component to control")]
	public ChargeShoot ChargeShoot;

	public void OnChargeShoot(InputAction.CallbackContext context)
	{
		if (context.started)
			this.ChargeShoot.IsCharging = true;
		if (context.canceled)
			this.ChargeShoot.IsCharging = false;
	}
}
