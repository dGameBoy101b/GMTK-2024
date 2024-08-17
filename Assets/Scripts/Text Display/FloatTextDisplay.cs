using UnityEngine;

public class FloatTextDisplay : TextDisplay<float>
{
	[Tooltip("The format string passed in when converting floats.\nSee the C# documentation on Single.ToString for more info.")]
	public string FormatString = "";

	protected override string ToText(float value)
	{
		return this.FormatString == "" ? value.ToString() : value.ToString(this.FormatString);
	}
}
