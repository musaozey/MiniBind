using UnityEngine.UI;

namespace MiniBind.Components
{
	public class ButtonInteractableBinding : UIComponentBinding
	{
		protected override void OnValueChanged()
		{
			bool value = GetValue<bool>();
			GetComponent<Button>().interactable = value;
		}
	}
}