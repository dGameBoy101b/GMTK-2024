using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// https://discussions.unity.com/t/ui-inverse-mask/590229/5
public class InvertedMaskImage : Image
{
	public override Material materialForRendering
	{
		get
		{
			Material result = base.materialForRendering;
			result.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
			return result;
		}
	}
}
