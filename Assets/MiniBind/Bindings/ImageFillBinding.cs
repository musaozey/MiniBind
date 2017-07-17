using UnityEngine.UI;
using UnityEngine;

namespace MiniBind.Components
{
	//This component has an editor script. If you update public fields, make sure updating editor class.
	public class ImageFillBinding : UIComponentBinding
	{
		public bool isAnimated = false;
		public float animationLength = 0.5f;
		private float time;
		private float currentValue;
		private float targetValue;

		protected override void OnValueChanged()
		{
			if (isAnimated)
			{
				float value = GetValue<float>();
				value = Mathf.Clamp01(value);
				currentValue = targetValue;
				targetValue = value;
				time = 0f;
			}
			else 
			{
				float value = GetValue<float>();
				value = Mathf.Clamp01(value);
				GetComponent<Image>().fillAmount = value;
			}
		}

		private void Update()
		{
			if (isAnimated)
			{
				if (time < 1f)
				{
					GetComponent<Image>().fillAmount = Mathf.Lerp(currentValue, targetValue, time);
					time += Time.deltaTime / animationLength;
				}
				else
				{
					GetComponent<Image>().fillAmount = targetValue;
				}
			}
		}
	}
}