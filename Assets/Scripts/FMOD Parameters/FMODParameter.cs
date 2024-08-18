using UnityEngine;
using FMODUnity;

public class FMODParameter : MonoBehaviour
{
	public StudioEventEmitter Emitter;

	public string ParameterName;

	private float PreviousValue;

	public void SetValue(float value)
	{
		if (value == this.PreviousValue) return; 				//ignores SetValue function if parameter has already been set to input value
		this.Emitter.SetParameter(this.ParameterName, value);
		this.PreviousValue = value; 							//updates Previous Value for next SetValue() call
	}

	private void Awake()
	{
		this.Emitter = this.GetComponent<StudioEventEmitter>();
	}
}