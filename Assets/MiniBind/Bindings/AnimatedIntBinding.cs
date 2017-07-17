using UnityEngine.UI;
using UnityEngine;

namespace MiniBind.Components
{
	//TODO: needs refactoring
	public class AnimatedIntBinding : UIComponentBinding
	{
		private float time;
		public float fillAnimationLength;
		private int currentValue;
		private int targetValue;

		protected override void OnValueChanged()
		{
			int value = GetValue<int>();
			currentValue = targetValue;
			targetValue = value;
			time = 0f;
		}
		private void Update()
		{
			if (time < 1f)
			{
				GetComponent<Text>().text = ((int)Mathf.Lerp(currentValue, targetValue, time)).ToString();
				time += Time.deltaTime / fillAnimationLength;
			}
			else 
			{ 
				GetComponent<Text>().text = targetValue.ToString();
			}
		}
	}
}