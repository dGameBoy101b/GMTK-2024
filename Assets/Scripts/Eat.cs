using UnityEngine;
using UnityEngine.Events;

public class Eat : MonoBehaviour
{
	[Tooltip("The health to add to when food is eaten")]
	public Health Health;

	[Tooltip("Invoked when this eats food.\nParameter is the health value of the eaten food")]
	public UnityEvent<float> OnEat = new();

	public void Consume(Food food)
	{
		var value = food.HealthValue;
		this.Health.CurrentHealth += value;
		this.OnEat.Invoke(value);
		food.Eat();
	}

	public Food FindFood(Component component)
	{
		return component.GetComponentInParent<Food>();
	}

	public void Consume(Component component)
	{
		var food = this.FindFood(component);
		if (food == null)
			return;
		this.Consume(food);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		this.Consume(other);
	}
}
