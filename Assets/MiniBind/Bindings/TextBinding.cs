using UnityEngine.UI;

namespace MiniBind.Components
{
	public class TextBinding : UIComponentBinding
	{
		protected override void OnValueChanged()
		{
			string value = GetValue<string>();
			GetComponent<Text>().text = value;
		}
	}
}