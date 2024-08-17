using UnityEngine;
using UnityEngine.Events;

public abstract class TextDisplay<ValueType> : MonoBehaviour
{
	[Tooltip("Invoked with the converted display text when a value is input")]
	public UnityEvent<string> OnDisplay = new();

	protected virtual string ToText(ValueType value)
	{
		return value.ToString();
	}

	public void UpdateDisplay(ValueType value)
	{
		this.OnDisplay.Invoke(this.ToText(value));
	}
}
