using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
	public void DontDestroy(Object obj)
	{
		DontDestroyOnLoad(obj);
	}
}
