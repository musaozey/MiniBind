using System.Collections.Generic;

namespace MiniBind
{
	public class MBManager
	{
		Dictionary<string, MiniBind> contexts = new Dictionary<string, MiniBind>();
		private static MBManager instance;

		public MiniBind this[string id]
		{
			get
			{
				if (!this.contexts.ContainsKey(id))
				{
					return CreateMiniBindInstance(id);
				}

				return this.contexts[id];
			}
		}

		public static MBManager Inst
		{
			get
			{
				if (instance == null)
					instance = new MBManager();

				return instance;
			}
		}

		private MiniBind CreateMiniBindInstance(string id)
		{
			IStorage storage = new Storage();
			MiniBind mb = new MiniBind(storage);
			contexts.Add(id, mb);
		return mb;
		}
	}
}