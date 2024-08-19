using System;
using UnityEngine;
using UnityEngine.Events;

public class IntegerBranch : MonoBehaviour
{
	[Tooltip("The threshold to check")]
	public int Threshold = 0;

	[Flags]
	public enum Mode
	{
		None,
		Equal = 1,
		NotEqual = 1 << 1,
		GreaterThan = 1 << 2,
		LessThan = 1 << 3,
	}
	public Mode CurrentMode;

	[Tooltip("Invoked when the threshold is crossed.\nParameter is the value that crossed the threshold.")]
	public UnityEvent<int> OnCrossThreshold = new();

	public bool DoesCross(int value)
	{
		return (this.CurrentMode.HasFlag(Mode.Equal) && value == this.Threshold)
			|| (this.CurrentMode.HasFlag(Mode.NotEqual) && value != this.Threshold)
			|| (this.CurrentMode.HasFlag(Mode.GreaterThan) && value > this.Threshold)
			|| (this.CurrentMode.HasFlag(Mode.LessThan) && value < this.Threshold);
	}

	public void Check(int value)
	{
		if (this.DoesCross(value))
			this.OnCrossThreshold.Invoke(value);
	}
}
