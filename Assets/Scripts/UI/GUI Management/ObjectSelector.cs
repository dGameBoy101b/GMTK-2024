using UnityEngine;
using UnityEngine.EventSystems;

namespace WinterwireGames.GUIManagement
{
	public class ObjectSelector : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The game object to select")]
		public GameObject Selected;

		[SerializeField]
		[Tooltip("Whether this should select its object on enable")]
		public bool ShouldSelectOnEnable = false;

		public void SelectObject()
		{
			EventSystem.current.SetSelectedGameObject(this.Selected);
		}

		private void OnEnable()
		{
			if (this.ShouldSelectOnEnable)
				this.SelectObject();
		}
	}
}
