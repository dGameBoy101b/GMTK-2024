using UnityEngine;
using UnityEngine.Events;

public abstract class Calculator<InputType, OutputType> : MonoBehaviour
{
	public UnityEvent<OutputType> OnOutput = new();

	public abstract OutputType Calculate(InputType input);

	public void DoCalculation(InputType input) => this.OnOutput.Invoke(this.Calculate(input));
}
