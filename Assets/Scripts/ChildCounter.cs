using UnityEngine;
using UnityEngine.Events;

public class ChildCounter : MonoBehaviour
{
	[Tooltip("Invoked with the number of children this has every time it changes on update")]
	public UnityEvent<int> OnChildCountChange = new();

	private int? _childCount = null;
	public int? ChildCount 
	{
		get => this._childCount;
		private set
		{
			var old = this._childCount;
			this._childCount = value;
			if (value.HasValue && value != old)
				this.OnChildCountChange.Invoke(value.Value);
		}
	}

	public void UpdateChildCount()
	{
		this.ChildCount = this.transform.childCount;
	}

	private void Update()
	{
		this.UpdateChildCount();
	}
}
