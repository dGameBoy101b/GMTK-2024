using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[Tooltip("The slider to control")]
	public Slider Slider;

	[Tooltip("The health component to listen to")]
	public Health Health;

	public void UpdateRange()
	{
		this.Slider.minValue = 0;
		this.Slider.maxValue = this.Health.MaxHealth;
		this.UpdateValue();
	}

	public void UpdateValue()
	{
		this.Slider.value = this.Health.CurrentHealth;
	}

	private void Awake()
	{
		this.UpdateRange();
	}
}
