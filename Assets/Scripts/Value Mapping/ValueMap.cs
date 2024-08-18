using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WinterwireGames.ValueMapping
{
	public abstract class ValueMap<KeyType> : SerializedMonoBehaviour
	{
		[SerializeField]
		[OdinSerialize]
		[Tooltip("The values this maps and the events invoked when mapped to them")]
		private Dictionary<KeyType, UnityEvent<KeyType>> _map = new Dictionary<KeyType, UnityEvent<KeyType>>();

		public Dictionary<KeyType, UnityEvent<KeyType>> Map { get => this._map; }

		[SerializeField]
		[Tooltip("Invoked when a key is not found")]
		private UnityEvent<KeyType> _defaultEvent = new UnityEvent<KeyType>();

		public UnityEvent<KeyType> DefaultEvent { get => this._defaultEvent; }

		public virtual void MapValue(KeyType key)
		{
			if (this.Map.ContainsKey(key))
				this.Map[key].Invoke(key);
			else
				this.DefaultEvent.Invoke(key);
		}
	}
}
