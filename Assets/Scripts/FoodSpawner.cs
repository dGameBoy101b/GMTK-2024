using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodSpawner : MonoBehaviour
{
	#region Food
	[Tooltip("The food objects to randomly spawn")]
	public List<Food> Foods = new();

	public Food PickFood()
	{
		if (Foods.Count < 1)
			return null;
		int index = Random.Range(0, this.Foods.Count - 1);
		return this.Foods[index];
	}

	[SerializeField]
	[Tooltip("The maximum number of food allowed to exist")]
	[Min(0)]
	private int _maxCount = 10;
	public int MaxCount
	{
		get => this._maxCount;
		set => this._maxCount = Mathf.Max(0, value);
	}

	[Tooltip("Whether old food should be destroyed to make room for new food")]
	public bool ShouldDestroyOld = false;

	public int CurrentCount => this.transform.childCount;

	public bool IsCountReady => this.ShouldDestroyOld || this.CurrentCount < this.MaxCount;

	public bool NeedToDestroyOld => this.ShouldDestroyOld && this.CurrentCount >= this.MaxCount;

	public Vector3? LastDestroyPosition { get; private set; } = null;

	public void DestoryOldFood()
	{
		if (!this.NeedToDestroyOld)
		{
			this.LastDestroyPosition = null;
			return;
		}
		var index = Random.Range(0, this.transform.childCount - 1);
		var to_destroy = this.transform.GetChild(index).gameObject;
		this.LastDestroyPosition = to_destroy.transform.position;
		Destroy(to_destroy);
	}

	public void DrawDestroyGizmo()
	{
		if (this.LastDestroyPosition == null || this.Origin == null)
			return;
		Gizmos.color = Color.red;
		Gizmos.DrawLine(this.Origin.position, this.LastDestroyPosition.Value);
	}
	#endregion

	#region Delay
	[SerializeField]
	[Tooltip("The minimum duration between spawning each piece of food")]
	[Min(0)]
	private float _minDelay = .1f;
	public float MinDelay
	{
		get => this._minDelay;
		set => this._minDelay = Mathf.Max(0, value);
	}

	[SerializeField]
	[Tooltip("The number of seconds until this can spawn again")]
	[Min(0)]
	private float _remainingDelay = 0f;
	public float RemainingDelay
	{
		get => this._remainingDelay;
		set => this._remainingDelay = Mathf.Max(0, value);
	}

	public void UpdateDelay(float delta_time)
	{
		this.RemainingDelay -= delta_time;
	}

	public bool IsDelayReady => this.RemainingDelay <= 0;
	#endregion

	#region Position
	[Tooltip("The object around which to spawn food")]
	public Transform Origin;

	[SerializeField]
	[Tooltip("The minimum distance food is spawned from the origin")]
	[Min(0)]
	private float _minRadius = 5;
	public float MinRadius
	{
		get => this._minRadius;
		set => this._minRadius = Mathf.Max(0, value);
	}

	[SerializeField]
	[Tooltip("The maximum distance food is spawned from the origin")]
	[Min(0)]
	private float _maxRadius = 10f;
	public float MaxRadius
	{
		get => this._maxRadius;
		set => this._maxRadius = Mathf.Max(0, value);
	}

	public Vector3 PickPosition()
	{
		var radius = Random.Range(this.MinRadius, this.MaxRadius);
		var angle = Random.Range(0, 360);
		var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		var direction = rotation * Vector3.right * radius;
		return this.Origin.position + direction;
	}

	public void DrawPositionGizmo()
	{
		if (this.Origin == null)
			return;
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(this.Origin.position, this.MinRadius);
		Gizmos.DrawWireSphere(this.Origin.position, this.MaxRadius);
	}
	#endregion

	#region Spawning
	[Tooltip("Invoked when this spawns food.\nParameter is the spawned food")]
	public UnityEvent<Food> OnSpawn = new();

	public Vector3? LastSpawnPosition { get; private set; } = null;

	public void SpawnFood()
	{
		if (!this.IsDelayReady || !this.IsCountReady)
			return;
		this.RemainingDelay = this.MinDelay;
		this.DestoryOldFood();
		var original_food = this.PickFood();
		var position = this.PickPosition();
		var food_object = Instantiate(original_food.gameObject, position, Quaternion.identity, this.transform);
		var food = food_object.GetComponent<Food>();
		this.LastSpawnPosition = position;
		this.OnSpawn.Invoke(food);
	}

	public void DrawSpawnGizmo()
	{
		if (this.LastSpawnPosition == null || this.Origin == null)
			return;
		Gizmos.color = Color.green;
		Gizmos.DrawLine(this.Origin.position, this.LastSpawnPosition.Value);
	}
	#endregion

	#region Unity Messages
	private void Update()
	{
		this.UpdateDelay(Time.deltaTime);
		this.SpawnFood();
	}

	private void OnDrawGizmosSelected()
	{
		this.DrawPositionGizmo();
		this.DrawSpawnGizmo();
		this.DrawDestroyGizmo();
	}
	#endregion
}
