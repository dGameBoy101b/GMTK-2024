using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
	[Tooltip("The slider to control")]
	public Slider Slider;

	[Tooltip("The shoot to fetch charge data from")]
	public Shoot Shoot;

	public void UpdateRange()
	{
		this.Slider.minValue = 0;
		this.Slider.maxValue = this.Shoot.MaxPower;
		this.UpdateValue();
	}

	public void UpdateValue()
	{
		this.Slider.value = this.Shoot.CurrentPower;
	}

	private void Awake()
	{
		this.UpdateRange();
	}
}
