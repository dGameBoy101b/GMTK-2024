using UnityEngine;
using UnityEngine.Events;

public class Randomiser : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The chance of this succeeding a check")]
	[Range(0f, 1f)]
	private float _chance = 1f;
	public float Chance
	{
		get => this._chance;
		set => this._chance = Mathf.Clamp01(value);
	}

	[Tooltip("Invoked when this success at a check")]
	public UnityEvent OnSuccess = new();

	[Tooltip("Invoked when this fails a check")]
	public UnityEvent OnFailure = new();

	public bool DoesPass()
	{
		if (this.Chance == 0f)
			return false;
		if (this.Chance == 1f)
			return true;
		var random = Random.value;
		return random < this.Chance;
	}

	public void Check()
	{
		if (this.DoesPass())
			this.OnSuccess.Invoke();
		else
			this.OnFailure.Invoke();
	}
}
