using UnityEngine.UI;

namespace MiniBind.Components
{
	public class TextBinding : UIComponentBinding
	{
		public string format = "{0}";
		protected override void OnValueChanged()
		{
			string value = GetValue<string>();
			GetComponent<Text>().text = string.Format(format, value);
		}
	}
}