using UnityEngine;
using UnityEngine.Events;

namespace WinterwireGames.Events
{
	[AddComponentMenu("Events/Object Lifetime Events")]
	public class ObjectLifetimeEvents : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Invoked when this is loaded and active")]
		private UnityEvent _onAwake = new UnityEvent();

		public UnityEvent OnAwake { get => this._onAwake; }

		[SerializeField]
		[Tooltip("Invoked when this is started")]
		private UnityEvent _onStart = new UnityEvent();

		public UnityEvent OnStart { get => this._onStart; }

		[SerializeField]
		[Tooltip("Invoked when this is enabled")]
		private UnityEvent _enable = new UnityEvent();

		public UnityEvent Enable { get => this._enable; }

		[SerializeField]
		[Tooltip("Invoked when this is disabled")]
		private UnityEvent _disable = new UnityEvent();

		public UnityEvent Disable { get => this._disable; }

		[SerializeField]
		[Tooltip("Invoked when this is destroyed")]
		private UnityEvent _destroy = new UnityEvent();

		public UnityEvent Destroy { get => this._destroy; }

		private void Awake()
		{
			this.OnAwake.Invoke();
		}

		private void Start()
		{
			this.OnStart.Invoke();
		}

		private void OnDestroy()
		{
			this.Destroy.Invoke();
		}

		private void OnEnable()
		{
			this.Enable.Invoke();
		}

		private void OnDisable()
		{
			this.Disable.Invoke();
		}
	}
}
