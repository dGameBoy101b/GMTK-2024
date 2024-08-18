using UnityEngine;
using UnityEngine.UI;

public abstract class RadialBar : MonoBehaviour
{
	[Tooltip("The image to control")]
	public Image Image;

	public abstract float Minimum { get; }

	public abstract float Maximum { get; }

	public abstract float Value { get; }

	public void UpdateBar()
	{
		this.Image.fillAmount = (this.Value - this.Minimum) / (this.Maximum - this.Minimum);
	}
}
