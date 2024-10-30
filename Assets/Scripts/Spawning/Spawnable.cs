using UnityEngine;
using UnityEngine.Events;

public class Spawnable : MonoBehaviour
{
	public UnityEvent<RadialSpawner> OnSpawn = new();
}
