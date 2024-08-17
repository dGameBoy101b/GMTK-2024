using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
	[Tooltip("The slider to control")]
	public Slider Slider;

	[Tooltip("Invoked when the value is updated.\nParameter is the current value")]
	public UnityEvent<float> OnUpdateValue = new();

	public abstract float Minimum { get; }
	public abstract float Maximum { get; }
	public abstract float Value { get; }

	public void UpdateRange()
	{
		this.Slider.minValue = this.Minimum;
		this.Slider.maxValue = this.Maximum;
		Debug.Log($"Range updated: {this.Minimum} - {this.Maximum}", this);
		this.UpdateValue();
	}

	public void UpdateValue()
	{
		this.Slider.value = this.Value;
		Debug.Log($"Value updated: {this.Value}", this);
		this.OnUpdateValue.Invoke(this.Value);
	}

	private void Awake()
	{
		this.UpdateRange();
	}
}
