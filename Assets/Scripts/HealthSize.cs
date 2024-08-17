using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSize : MonoBehaviour
{
	[Tooltip("The transform hose scale should be controlled")]
	public Transform Transform;

	[Tooltip("The base scaling applied to the controlled transform.\nFetched on awake")]
	public Vector3 BaseScale = Vector3.one;

	public void FetchBaseScale()
	{
		this.BaseScale = this.Transform.localScale;
	}

	[Tooltip("The health component to fetch the current health from")]
	public Health Health;

	[Tooltip("The multiplier applied to health before adding the base scale")]
	public float HealthCoefficient;

	public void UpdateScale()
	{
		this.Transform.localScale = this.Health.CurrentHealth * this.HealthCoefficient * Vector3.one + this.BaseScale;
	}

	private void Awake()
	{
		this.FetchBaseScale();
		this.UpdateScale();
	}
}
