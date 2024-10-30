using UnityEngine;
using UnityEngine.Events;

public class Random01 : MonoBehaviour
{
	[Tooltip("Invoked when this generates a random number between 0 and 1.\nParameter is the generated number")]
	public UnityEvent<float> OnGenerate = new();

	public void Generate()
	{
		this.OnGenerate.Invoke(Random.value);
	}
}
