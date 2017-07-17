using UnityEngine;
using UnityEngine.UI;

namespace MiniBind.Components
{
	public class ImageBinding : UIComponentBinding
	{
		protected override void OnValueChanged()
		{
			Sprite value = GetValue<Sprite>();
			GetComponent<Image>().sprite = value;
		}
	}
}