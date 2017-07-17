using System;

namespace MiniBind
{
	public class BindData
	{
		private Action OnValueChangedAction;
		private object value;

		public object GetValue()
		{
			return value;
		}

		public void SetValue(object newValue)
		{
			value = newValue;
			OnValueChanged();
		}

		void OnValueChanged()
		{
			if (OnValueChangedAction != null)
			{
				OnValueChangedAction();
			}
		}

		public void Subscribe(Action subscriber)
		{
			if (subscriber != null)
			{
				OnValueChangedAction += subscriber;
				subscriber();
			}
		}

		public void Unsubscribe(Action subscriber)
		{
			if (subscriber != null)
			{
				OnValueChangedAction -= subscriber;
			}
		}
	}
}