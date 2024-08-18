using UnityEngine;

namespace WinterwireGames.ValueMapping
{
	public class PlatformValueMap : ValueMap<RuntimePlatform>
	{
		public void MapCurrentPlatform()
		{
			this.MapValue(Application.platform);
		}
	}
}
