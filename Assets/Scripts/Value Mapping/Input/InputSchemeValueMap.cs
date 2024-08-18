using UnityEngine.InputSystem;
using UnityEngine;

namespace WinterwireGames.ValueMapping.Input
{
	[AddComponentMenu("Value Mapping/Input/Input Scheme Value Map")]
	public class InputSchemeValueMap : ValueMap<string>
	{
		public void MapValue(PlayerInput input)
		{
			base.MapValue(input.currentControlScheme);
		}
	}
}
