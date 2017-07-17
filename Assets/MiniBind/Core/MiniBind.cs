using System;

namespace MiniBind
{
	public class MiniBind
	{
		IStorage storage;

		public MiniBind(IStorage storage)
		{
			this.storage = storage;
		}

		public void SetValue(string key, object value)
		{
			if (storage.HasKey(key))
			{
				BindData data = storage.GetData(key);
				data.SetValue(value);
			}
			else
			{
				BindData data = new BindData();
				data.SetValue(value);
				storage.AddData(key, data);
			}
		}

		public T GetValue<T>(string key)
		{
			if (storage.HasKey(key))
			{
				BindData data = storage.GetData(key);
				object value = data.GetValue();

				try
				{
					if (typeof(string).IsAssignableFrom(typeof(T))) 
					{
						return (T)Convert.ChangeType(value.ToString(), typeof(T));
					}
					T castedValue = (T)value;
					return castedValue;
				}
				catch (Exception e)
				{
					if (e.GetType().Equals(typeof(InvalidCastException)))
					{
						UnityEngine.Debug.LogError(string.Format("<b>Key: {0}\n</b>Cannot cast from source type to destination type. <b>CastType: {1}</b>", key, typeof(T)));
					}
				}
			}
			return default(T);
		}

		public void SubscribeBinding(string key, Action action)
		{
			if (storage.HasKey(key))
			{
				BindData data = storage.GetData(key);
				data.Subscribe(action);
			}
			else
			{
				BindData data = new BindData();
				data.SetValue(null);
				data.Subscribe(action);
				storage.AddData(key, data);
			}
		}

		public void UnsubscribeBinding(string key, Action action)
		{
			if (storage.HasKey(key))
			{
				BindData data = storage.GetData(key);
				data.Unsubscribe(action);
			}
		}
	}
}