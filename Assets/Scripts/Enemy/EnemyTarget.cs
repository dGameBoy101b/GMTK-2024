using UnityEngine;
using UnityEngine.Events;

public class EnemyTarget : MonoBehaviour
{
	[Tooltip("Invoked with the target of the given enemy")]
	public UnityEvent<Transform> OnTarget = new();

	public void GetTarget(Enemy enemy) => this.OnTarget.Invoke(enemy.Target);
}
