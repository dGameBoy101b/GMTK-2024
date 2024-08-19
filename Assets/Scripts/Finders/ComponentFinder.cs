using UnityEngine;
using UnityEngine.Events;

public class ComponentFinder<ComponentType> : MonoBehaviour
{
	[Tooltip("Invoked with the found component")]
	public UnityEvent<ComponentType> OnFind = new();

	public virtual ComponentType GetComponent(GameObject game_object)
	{
		return game_object.GetComponent<ComponentType>();
	}

	public void FindComponent(GameObject gameObject)
	{
		var component = this.GetComponent(gameObject);
		this.OnFind.Invoke(component);
	}

	public void FindComponent(Component component)
	{
		this.FindComponent(component.gameObject);
	}
}
