namespace MiniBind
{
	public interface IStorage
	{
		bool HasKey(string key);
		void AddData(string key, BindData data);
		BindData GetData(string key);
	}
}