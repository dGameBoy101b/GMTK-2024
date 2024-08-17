using UnityEngine;

namespace WinterwireGames.PhysicsHelpers
{
	public static class ForceModeHelpers
	{
		public static bool IsInstantaneous(this ForceMode mode)
		{
			return mode == ForceMode.Impulse || mode == ForceMode.VelocityChange;
		}

		public static bool IsAffectedByMass(this ForceMode mode)
		{
			return mode == ForceMode.Force || mode == ForceMode.Impulse;
		}
	}
}
