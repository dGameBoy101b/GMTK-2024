using UnityEngine;

public class MoveDirection : MonoBehaviour
{
	[Tooltip("The move component whose direction should be controlled")]
	public Move Move;

	public void UpdateDirection(Vector2 direction)
	{
		this.Move.CurrentDirection = direction;
	}
}
