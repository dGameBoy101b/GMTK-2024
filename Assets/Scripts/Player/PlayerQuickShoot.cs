using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerQuickShoot : MonoBehaviour
{
	[Tooltip("The quick shoot component to control")]
	public QuickShoot QuickShoot;

	public void OnQuickShoot(InputAction.CallbackContext context)
	{
		if (context.started)
			this.QuickShoot.IsShooting = true;
		if (context.canceled)
			this.QuickShoot.IsShooting = false;
	}
}
