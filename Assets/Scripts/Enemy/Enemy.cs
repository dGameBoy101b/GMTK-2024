using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	[FormerlySerializedAs("Target")]
	[Tooltip("What this should try to kill")]
	private Transform _target;
	public Transform Target
	{
		get => this._target;
		set => this._target = value;
	}
}
