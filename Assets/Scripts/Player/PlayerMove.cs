using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
	[Tooltip("The move component to control")]
	public Move Move;

	public void OnMove(InputAction.CallbackContext context)
	{
		if (context.performed)
			this.Move.CurrentDirection = context.ReadValue<Vector2>();
		if (context.canceled)
			this.Move.CurrentDirection = Vector2.zero;
	}
}
