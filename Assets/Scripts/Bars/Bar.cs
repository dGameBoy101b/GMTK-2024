using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
	[Tooltip("The slider to control")]
	public Slider Slider;

	public abstract float Minimum { get; }
	public abstract float Maximum { get; }
	public abstract float Value { get; }

	public void UpdateRange()
	{
		this.Slider.minValue = this.Minimum;
		this.Slider.maxValue = this.Maximum;
		this.UpdateValue();
	}

	public void UpdateValue()
	{
		this.Slider.value = this.Value;
	}

	private void Awake()
	{
		this.UpdateRange();
	}
}
