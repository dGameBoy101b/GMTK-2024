using UnityEngine;
using UnityEngine.Events;

namespace WinterwireGames.SceneManagement
{
	public class LoadedSceneActivator : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Invoked when the currently loading scene becomes ready")]
		private UnityEvent _onReady = new UnityEvent();

		public UnityEvent OnReady { get => this._onReady; }

		private bool wasReady = false;

		public void ActivateLoadedScene()
		{
			if (SceneLoader.IsReady)
				SceneLoader.LoadingOperation.allowSceneActivation = true;
		}

		private void Update()
		{
			if (SceneLoader.IsReady && !this.wasReady)
			{
				this.wasReady = true;
				this.OnReady.Invoke();
			}
		}
	}
}
