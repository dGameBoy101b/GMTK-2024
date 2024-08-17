using UnityEngine;

public class BulletMove : MonoBehaviour
{
	[Tooltip("The move component to control")]
	public Move Move;

	[Tooltip("The base maximum move speed.\nFetched from the controlled move component")]
	public float BaseSpeed;

	[Tooltip("The multiplier applied to power before adding it to the base speed")]
	public float PowerCoefficient = 1f;

	public void FetchBaseSpeed()
	{
		this.BaseSpeed = this.Move.MaxMoveSpeed;
	}

	public void OnShot(Bullet bullet)
	{
		this.Move.CurrentDirection = bullet.Direction;
		this.Move.MaxMoveSpeed = this.BaseSpeed + bullet.Power * this.PowerCoefficient;
	}

	private void Awake()
	{
		this.FetchBaseSpeed();
	}
}
