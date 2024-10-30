using UnityEngine;

public class EnemyAim : MonoBehaviour
{
	[Tooltip("The aim component to control the direction of")]
	public Aim Aim;

	[Tooltip("The enemey component to get the target from")]
	public Enemy Enemy;

	public void UpdateDirection()
	{
		this.Aim.Direction = this.Enemy.Target.transform.position - this.transform.position;
	}
}
