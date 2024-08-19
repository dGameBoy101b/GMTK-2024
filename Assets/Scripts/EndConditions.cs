using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndConditions : MonoBehaviour
{
	public UnityEvent OnWin = new();

	public UnityEvent OnLose = new();

	private static readonly HashSet<EndConditions> _instances = new();
	public static IReadOnlyCollection<EndConditions> Instances => _instances;

	public static void InvokeWins()
	{
		foreach (var instance in Instances)
			instance.OnWin.Invoke();
	}

	public static void InvokeLoses() 
	{
		foreach (var instance in Instances)
			instance.OnLose.Invoke();
	}

	public void Win()
	{
		InvokeWins();
	}

	public void Lose()
	{
		InvokeLoses();
	}

	private void Awake()
	{
		_instances.Add(this);
	}

	private void OnDestroy()
	{
		_instances.Remove(this);
	}
}
