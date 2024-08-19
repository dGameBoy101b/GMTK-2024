using UnityEngine;
using UnityEngine.Events;

public class Instantiater : MonoBehaviour
{
	[Tooltip("Invoked when this instantiates something.\nParameter is the instantiated object")]
	public UnityEvent<Object> OnInstantiate = new();

	public void Spawn(Object original)
	{
		var instance = Instantiate(original, this.transform.position, this.transform.rotation);
		this.OnInstantiate.Invoke(instance);
	}
}
