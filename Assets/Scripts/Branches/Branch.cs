using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Branch<CompareableType> : MonoBehaviour
	where CompareableType : IEquatable<CompareableType>, IComparable<CompareableType>
{
	[Tooltip("The threshold to check")]
	public CompareableType Threshold;

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
	public UnityEvent<CompareableType> OnCrossThreshold = new();

	public bool DoesCross(CompareableType value)
	{
		return (this.CurrentMode.HasFlag(Mode.Equal) && value.Equals(this.Threshold))
			|| (this.CurrentMode.HasFlag(Mode.NotEqual) && !value.Equals(this.Threshold))
			|| (this.CurrentMode.HasFlag(Mode.GreaterThan) && value.CompareTo(this.Threshold) > 0)
			|| (this.CurrentMode.HasFlag(Mode.LessThan) && value.CompareTo(this.Threshold) < 0);
	}

	public void Check(CompareableType value)
	{
		if (this.DoesCross(value))
			this.OnCrossThreshold.Invoke(value);
	}
}
