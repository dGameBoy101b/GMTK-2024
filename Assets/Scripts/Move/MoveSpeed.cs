using UnityEngine;

public class MoveSpeed : MonoBehaviour
{
	[Tooltip("The move component whose speed should be controlled")]
	public Move Move;

	[Tooltip("The base movement speed to use.\nFetched from move on awake")]
	public float BaseSpeed = 0f;

	public void FetchBaseSpeed()
	{
		this.BaseSpeed = this.Move.MaxMoveSpeed;
	}

	[Tooltip("The multiplier applied to the inpt value before adding the base move speed")]
	public float Coefficient = 1f;

	public float CalculateMoveSpeed(float value) => value * this.Coefficient + this.BaseSpeed;

	public void UpdateMoveSpeed(float value)
	{
		this.Move.MaxMoveSpeed = this.CalculateMoveSpeed(value);
	}

	private void Awake()
	{
		this.FetchBaseSpeed();
	}
}
