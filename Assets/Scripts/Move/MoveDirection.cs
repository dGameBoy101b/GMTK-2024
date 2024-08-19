using UnityEngine;
using UnityEngine.Events;

public class MoveDirection : MonoBehaviour
{
	public UnityEvent<Vector2> OnDirection = new();

	public void GetDirection(Move move) => this.OnDirection.Invoke(move.CurrentDirection);
}
