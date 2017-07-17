using UnityEngine;

namespace MiniBind
{
	public class UIComponentBinding : MonoBehaviour
	{
		private bool isInit = false;
		private bool isSubscribed = false;

		public string originalKey { private set; get; }
		public string key;

		private MiniBind context
		{
			get
			{
				return MBManager.Inst[MBContexts.UI_CONTEXT];
			}
		}

		protected T GetValue<T>()
		{
			return context.GetValue<T>(key);
		}

		void OnEnable()
		{
			SetKey(key);
		}

		void OnDestroy()
		{
			context.UnsubscribeBinding(key, OnValueChanged);
		}

		public string GetKey()
		{
			return key;
		}

		public virtual void SetKey(string newKey)
		{
			if (!isInit)
			{
				originalKey = key;
				isInit = true;
			}
			if (isSubscribed)
			{
				context.UnsubscribeBinding(key, OnValueChanged);
				isSubscribed = false;
			}
			key = newKey;
			context.SubscribeBinding(key, OnValueChanged);
			isSubscribed = true;
		}

		protected virtual void OnValueChanged()
		{

		}
	}
}