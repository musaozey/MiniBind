using UnityEngine;
using UnityEngine.UI;

namespace MiniBind.Components
{
	public class ImageColorBinding : UIComponentBinding
	{
		protected override void OnValueChanged()
		{
			Color value = GetValue<Color>();
			GetComponent<Image>().color = value;
		}
	}
}