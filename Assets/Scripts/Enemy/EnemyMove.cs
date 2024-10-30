using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	[Tooltip("The move component to control")]
	public Move Move;

	[Tooltip("The enemy used to fetch the target")]
	public Enemy Enemy;

	public void UpdateDirection()
	{
		this.Move.CurrentDirection = (this.Enemy.Target.position - this.Move.transform.position).normalized;
	}

	private void Update()
	{
		this.UpdateDirection();
	}
}
