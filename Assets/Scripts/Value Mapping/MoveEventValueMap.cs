using UnityEngine.EventSystems;
using UnityEngine;

namespace WinterwireGames.ValueMapping
{
	using MoveDirection = UnityEngine.EventSystems.MoveDirection;
	[AddComponentMenu("Value Mapping/Move Event Value Map")]
	public class MoveEventValueMap : ValueMap<MoveDirection>
	{
		public void MapValue(BaseEventData data)
		{
			base.MapValue(ExecuteEvents.ValidateEventData<AxisEventData>(data).moveDir);
		}
	}
}
