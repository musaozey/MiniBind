using System.Collections.Generic;

namespace MiniBind
{
	public class Storage : IStorage
	{
		private readonly Dictionary<string, BindData> dict = new Dictionary<string, BindData>();

		public bool HasKey(string key)
		{
			return dict.ContainsKey(key);
		}

		public void AddData(string key, BindData data)
		{
			if (!HasKey(key))
			{
				dict.Add(key, data);
			}
		}

		public BindData GetData(string key)
		{
			if (HasKey(key))
			{
				return dict[key];
			}
			return null;
		}
	}
}